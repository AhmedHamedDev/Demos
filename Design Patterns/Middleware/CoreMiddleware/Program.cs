using CoreMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient("name")
     .AddHttpMessageHandler<HttpClientMiddleware>()
     .AddHttpMessageHandler<HttpClientMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<CustomMiddleware>();

app.Use(async (httpContext, next) =>
{
    // do something before 
    await next();
    // do something after
});


app.UseAuthorization();

app.MapControllers();

app.Run();
