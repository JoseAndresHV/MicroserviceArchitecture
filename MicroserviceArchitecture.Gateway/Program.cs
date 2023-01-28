using Aforo255.Cross.Token.Src;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false);

// Add services to the container.

var services = builder.Services;

services.AddJwtCustomized();
services.AddOcelot();

//builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseAuthorization();

//app.MapControllers();

app.UseOcelot().Wait();

app.Run();
