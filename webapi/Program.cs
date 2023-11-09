using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using webapi.Models;
using webapi.Data;
using MongoDB.Driver;
using System.Configuration;
using webapi.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<webapiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("webapiContext") ?? throw new InvalidOperationException("Connection string 'webapiContext' not found.")));

// Add services to the container.
IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path for appsettings.json
           .AddJsonFile("appsettings.json") // Add the appsettings.json file
           .Build();
var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDb"));
builder.Services.AddSingleton<IMongoClient>(mongoClient);

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductoContext>(pro => pro.UseInMemoryDatabase("ProductoList"));
builder.Services.AddDbContext<FacturaContext>(pro => pro.UseInMemoryDatabase("FacturaList"));
builder.Services.AddDbContext<CafeteriaContext>(pro => pro.UseInMemoryDatabase("CafeteriaList"));
builder.Services.AddDbContext<ClienteContext>(pro => pro.UseInMemoryDatabase("ClienteList"));
builder.Services.AddDbContext<PedidoContext>(pro => pro.UseInMemoryDatabase("PedidoList"));
builder.Services.AddDbContext<VendedorContext>(pro => pro.UseInMemoryDatabase("VendedorList"));
builder.Services.AddTransient<ICafeteria, CafeteriaI>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
