using Microsoft.EntityFrameworkCore;
using VFXFinancialV2.Application.Features.ExchangeRate.Create.Repository;
using VFXFinancialV2.Application.Features.ExchangeRate.Get.Repository;
using VFXFinancialV2.Application.Features.ExchangeRate.Update.Repository;
using VFXFinancialV2.Application.Features.ExchangeRate.Delete.Repository;
using VFXFinancialV2.Application.Infrastructure.Persistence;
using VFXFinancialV2.Application.Features.ExchangeRate.SyncFromExternalApi;
using VFXFinancialV2.Application.Features.ExchangeRate.SyncFromExternalApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opitons =>
{
    opitons.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Dependency injection - Repository
builder.Services.AddScoped<ICreateExchangeRateRepository, CreateExchangeRateRepository>();
builder.Services.AddScoped<IGetExchangeRateRepository, GetExchangeRateRepository>();
builder.Services.AddScoped<IUpdateExchangeRateRepository, UpdateExchangeRateRepository>();
builder.Services.AddScoped<IDeleteExchangeRateRepository, DeleteExchangeRateRepository>();
builder.Services.AddScoped<ICreateExchangeRateFromExternalRepository, CreateExchangeRateFromExternalRepository>();

// Dependency injection - Services
builder.Services.AddScoped<ISyncFromExternalApiService, SyncFromExternalApiService>();

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
