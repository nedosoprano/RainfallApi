using Microsoft.OpenApi.Models;
using Rainfall.Application.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0",
        Title = "Rainfall Api",
        Description = "An API which provides rainfall reading data",
    });

    options.AddServer(new OpenApiServer()
    {
        Url = "https://localhost:3000",
        Description = "Rainfall Api"
    });

    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), includeControllerXmlComments: true);
    options.EnableAnnotations();
    options.MapType<decimal>(() => new OpenApiSchema { Type = "number", Format = "decimal" });
    options.MapType<int>(() => new OpenApiSchema { Type = "number"});
});
builder.Services.AddApplicationDependencies();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();

app.Run();
