using GestionLibreria.Domain.Interfaces;
using GestionLibreria.Infrastructure.Repositories;
using GestionLibreria.Application.Interfaces;
using GestionLibreria.Application.Services;
using GestionLibreria.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("GestionLibreriaDb") 
    ?? throw new InvalidOperationException("Connection string 'GestionLibreriaDb' not found.");

builder.Services.AddDbContext<GestionLibreriaDbContext>(options =>
    options.UseSqlServer(connectionString));

// Infrastructure: Repositories.
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Application: Use Cases.
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
