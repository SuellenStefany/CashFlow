using CashFlow.Transaction.Application.Interfaces;
using CashFlow.Transaction.Application.Services;
using CashFlow.Transaction.Infrastructure.Config;
using CashFlow.Transaction.Infrastructure.Data;
using CashFlow.Transaction.Infrastructure.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<MongoDbSettings>(
builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<DCEntryContext>();
//Add Services and Repositories
builder.Services.AddScoped<IDebitEntryRepository, DebitEntryRepository>();
builder.Services.AddScoped<IDebitEntryService, DebitEntryService>();

builder.Services.AddScoped<ICreditEntryRepository, CreditEntryRepository>();
builder.Services.AddScoped<ICreditEntryService, CreditEntryService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
