using Batch4.Api.PayrollManagementSystem;
using Batch4.Api.PayrollManagementSystem.DataAccess.Db;
using Batch4.Api.PayrollManagementSystem.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(context =>
{
    context.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")!);
}, ServiceLifetime.Transient, ServiceLifetime.Transient);
builder.Services.AddServices();

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

app.CustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
