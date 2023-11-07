﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using webapi.Models;
using webapi.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<webapiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("webapiContext") ?? throw new InvalidOperationException("Connection string 'webapiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductoContext>(pro => pro.UseInMemoryDatabase("ProductoList"));
builder.Services.AddDbContext<FacturaContext>(pro => pro.UseInMemoryDatabase("FacturaList"));
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
