using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Aforo255.Cross.Discovery.Mvc;
using Aforo255.Cross.Event.Src;
using Aforo255.Cross.Http.Src;
using Aforo255.Cross.Tracing.Src;
using Consul;
using MediatR;
using MicroserviceArchitecture.Deposit.Messages.CommandHandlers;
using MicroserviceArchitecture.Deposit.Messages.Commands;
using MicroserviceArchitecture.Deposit.Repositories;
using MicroserviceArchitecture.Deposit.Services;
using Microsoft.EntityFrameworkCore;
using Steeltoe.Extensions.Configuration.ConfigServer;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddConfigServer(builder.Environment.EnvironmentName);

// Add services to the container.

builder.Services.AddControllers();

Console.WriteLine(builder.Configuration["cnpostgres"]);

builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        //opt.UseNpgsql(builder.Configuration["postgres:cn"]);
        opt.UseNpgsql(builder.Configuration["cnpostgres"]);
    });

builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddRabbitMQ();

builder.Services.AddTransient<IRequestHandler<TransactionCreateCommand, bool>, TransactionCommandHandler>();
builder.Services.AddTransient<IRequestHandler<NotificationCreateCommand, bool>, NotificationCommandHandler>();

builder.Services.AddProxyHttp();

builder.Services.AddSingleton<IServiceId, ServiceId>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddConsul();

builder.Services.AddFabio();

builder.Services.AddJaeger();
builder.Services.AddOpenTracing();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

var serviceId = app.UseConsul();
var consulClient = app.Services.GetRequiredService<IConsulClient>();
app.Lifetime.ApplicationStopped.Register(() =>
{
    consulClient.Agent.ServiceDeregister(serviceId);
});


app.Run();
