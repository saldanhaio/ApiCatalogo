using ApiCatalogo.Context;
using ApiCatalogo.Filters;
using ApiCatalogo.Logging;
using APICatalogo.Extensions;
using APICatalogo.Logging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string mysqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection)));

builder.Services.AddScoped<ApiLoggingFilter>();

builder.Logging.AddProvider(new CustomLoggerProvider(
    new CustomLoggerProviderCOnfiguration
    {
        LogLevel = LogLevel.Information,
       
    }));

// Adiciona o serviço de controladores
builder.Services.AddControllers();

// Adiciona o serviço de autorização
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();