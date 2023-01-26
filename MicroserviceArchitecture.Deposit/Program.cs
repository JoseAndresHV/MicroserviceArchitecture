using Aforo255.Cross.Event.Src;
using MediatR;
using MicroserviceArchitecture.Deposit.Messages.CommandHandlers;
using MicroserviceArchitecture.Deposit.Messages.Commands;
using MicroserviceArchitecture.Deposit.Repositories;
using MicroserviceArchitecture.Deposit.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        opt.UseNpgsql(builder.Configuration["postgres:cn"]);
    });

builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddRabbitMQ();

builder.Services.AddTransient<IRequestHandler<TransactionCreateCommand, bool>, TransactionCommandHandler>();
builder.Services.AddTransient<IRequestHandler<NotificationCreateCommand, bool>, NotificationCommandHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
