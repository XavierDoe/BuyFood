using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using webapi.Models;
using MongoDB.Driver;
using System.Configuration;
using webapi.Repositories;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path for appsettings.json
           .AddJsonFile("appsettings.json") // Add the appsettings.json file
           .Build();
var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDb"));
builder.Services.AddSingleton<IMongoClient>(mongoClient);

builder.Services.AddControllers();
builder.Services.AddTransient<ICafeteria, CafeteriaI>();
builder.Services.AddTransient<IFactura, FacturaI>();
builder.Services.AddTransient<ICliente, ClienteI>();
builder.Services.AddTransient<IPedido, PedidoI>();
builder.Services.AddTransient<IProducto, ProductoI>();
builder.Services.AddTransient<IVendedor, VendedorI>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
