using Aforo255.Cross.Event.Src;
using Aforo255.Cross.Event.Src.Bus;
using MediatR;
using MicroserviceArchitecture.Notification.Messages.EventHandlers;
using MicroserviceArchitecture.Notification.Messages.Events;
using MicroserviceArchitecture.Notification.Repositories;
using MicroserviceArchitecture.Notification.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        opt.UseMySql(builder.Configuration["mariadb:cn"],
            new MariaDbServerVersion(new Version(10, 10, 2)))
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
    });


builder.Services.AddScoped<IMailService, MailService>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddRabbitMQ();

builder.Services.AddTransient<NotificationEventHandler>();
builder.Services.AddTransient<IEventHandler<NotificationCreatedEvent>, NotificationEventHandler>();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

ConfigureEventBus(app);

app.Run();

void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<NotificationCreatedEvent, NotificationEventHandler>();
}
