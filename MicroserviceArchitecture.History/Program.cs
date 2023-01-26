using MicroserviceArchitecture.History;
using MicroserviceArchitecture.History.Repositories;
using MicroserviceArchitecture.History.Services;

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

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
