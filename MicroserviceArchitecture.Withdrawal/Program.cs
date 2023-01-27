using Aforo255.Cross.Event.Src;
using Aforo255.Cross.Http.Src;
using MediatR;
using MicroserviceArchitecture.Withdrawal.Messages.CommandHandlers;
using MicroserviceArchitecture.Withdrawal.Messages.Commands;
using MicroserviceArchitecture.Withdrawal.Repositories;
using MicroserviceArchitecture.Withdrawal.Services;
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
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddRabbitMQ();

builder.Services.AddTransient<IRequestHandler<TransactionCreateCommand, bool>, TransactionCommandHandler>();
builder.Services.AddTransient<IRequestHandler<NotificationCreateCommand, bool>, NotificationCommandHandler>();

builder.Services.AddProxyHttp();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
