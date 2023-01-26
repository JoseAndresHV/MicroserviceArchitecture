using Aforo255.Cross.Event.Src;
using Aforo255.Cross.Event.Src.Bus;
using MediatR;
using MicroserviceArchitecture.History;
using MicroserviceArchitecture.History.Messages.EventHandlers;
using MicroserviceArchitecture.History.Messages.Events;
using MicroserviceArchitecture.History.Repositories;
using MicroserviceArchitecture.History.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<MongoSettings>(opt =>
{
    opt.Connection = builder.Configuration.GetSection("mongo:cn").Value;
    opt.DatabaseName = builder.Configuration.GetSection("mongo:database").Value;
});

builder.Services.AddScoped<IHistoryService, HistoryService>();

builder.Services.AddScoped<IMongoDBContext, MongoDBContext>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddRabbitMQ();

builder.Services.AddTransient<TransactionEventHandler>();
builder.Services.AddTransient<IEventHandler<TransactionCreatedEvent>, TransactionEventHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

ConfigureEventBus(app);

app.Run();


void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<TransactionCreatedEvent, TransactionEventHandler>();
}
