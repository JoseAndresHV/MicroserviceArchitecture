using Aforo255.Cross.Token.Src;
using Aforo255.Cross.Tracing.Src;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false);

// Add services to the container.

var services = builder.Services;

services.AddJwtCustomized();
services.AddOcelot();

services.AddJaeger();
services.AddOpenTracing();

services.AddCors();

var clientPolicy = "_clientPolicy";
services.AddCors(o => o.AddPolicy(clientPolicy, builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
services.AddRouting(r => r.SuppressCheckForUnhandledSecurityMetadata = true);

//builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseAuthorization();

//app.MapControllers();

app.UseOcelot().Wait();

app.UseCors(clientPolicy);
app.Use((context, next) =>
{
    context.Items["__CorsMiddlewareInvoked"] = true;
    return next();
});

app.Run();
