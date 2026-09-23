using GestionLibreria.Domain.Interfaces;
using GestionLibreria.Infrastructure.Repositories;
using GestionLibreria.Application.Interfaces;
using GestionLibreria.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/opeapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
