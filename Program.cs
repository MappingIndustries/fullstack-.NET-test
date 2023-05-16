using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VocabularyVault.Data;
using VocabularyVault.Services;
using VocabularyVault.VaultManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseUrl")) });
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("VocabularyVaultDb"));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddScoped<IVaultRepo, VaultRepo>();
builder.Services.AddScoped<ISeacrhDictionary, SearchDictionary>();
builder.Services.AddScoped<IVaultOperation, VaultOperation>();
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
