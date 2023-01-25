using Aforo255.Cross.Token.Src;
using MicroserviceArchitecture.Security.Repositories;
using MicroserviceArchitecture.Security.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        opt.UseMySQL(builder.Configuration["mysql:cn"]);
    });

builder.Services.AddScoped<IAccessService, AccessService>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("jwt"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
