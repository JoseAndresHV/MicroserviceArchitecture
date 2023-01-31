using Aforo255.Cross.Cache.Src;
using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Aforo255.Cross.Discovery.Mvc;
using Aforo255.Cross.Event.Src;
using Aforo255.Cross.Event.Src.Bus;
using Aforo255.Cross.Tracing.Src;
using Consul;
using MediatR;
using MicroserviceArchitecture.History;
using MicroserviceArchitecture.History.Messages.EventHandlers;
using MicroserviceArchitecture.History.Messages.Events;
using MicroserviceArchitecture.History.Repositories;
using MicroserviceArchitecture.History.Services;
using Steeltoe.Extensions.Configuration.ConfigServer;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddConfigServer(builder.Environment.EnvironmentName);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<MongoSettings>(opt =>
{
    opt.Connection = builder.Configuration.GetSection("cnmongo").Value;
    opt.DatabaseName = builder.Configuration.GetSection("mongo:database").Value;
});

builder.Services.AddScoped<IHistoryService, HistoryService>();

builder.Services.AddScoped<IMongoDBContext, MongoDBContext>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddRabbitMQ();

builder.Services.AddTransient<TransactionEventHandler>();
builder.Services.AddTransient<IEventHandler<TransactionCreatedEvent>, TransactionEventHandler>();

builder.Services.AddSingleton<IServiceId, ServiceId>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddConsul();

builder.Services.AddFabio();

builder.Services.AddRedis();

builder.Services.AddJaeger();
builder.Services.AddOpenTracing();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

ConfigureEventBus(app);

var serviceId = app.UseConsul();
var consulClient = app.Services.GetRequiredService<IConsulClient>();
app.Lifetime.ApplicationStopped.Register(() =>
{
    consulClient.Agent.ServiceDeregister(serviceId);
});

app.Run();

void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<TransactionCreatedEvent, TransactionEventHandler>();
}
