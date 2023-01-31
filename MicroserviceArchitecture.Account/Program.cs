using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Aforo255.Cross.Discovery.Mvc;
using Aforo255.Cross.Tracing.Src;
using Consul;
using MicroserviceArchitecture.Account.Repositories;
using MicroserviceArchitecture.Account.Services;
using Microsoft.EntityFrameworkCore;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddConfigServer(builder.Environment.EnvironmentName);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        //opt.UseSqlServer(builder.Configuration["sqlserver:cn"]);
        opt.UseSqlServer(builder.Configuration["cnsql"]);
    });

builder.Services.AddScoped<IAccountService, AccountService>();

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
