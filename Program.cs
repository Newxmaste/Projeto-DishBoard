using Microsoft.EntityFrameworkCore;
using DishApi.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("=== INICIANDO APLICAÇÃO ===");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine("=== CONTROLLERS ADICIONADOS ===");

builder.Services.AddDbContext<DishBoardContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddDbContext<DishBoardProdContext>(options =>
// {
//     var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//     Console.WriteLine($"Connection String: {connectionString ?? "NÃO ENCONTRADA"}");
//     if (!string.IsNullOrEmpty(connectionString))
//     {
//         options.UseSqlServer(connectionString);
//     }
// });
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

var app = builder.Build();

Console.WriteLine("=== APP CONSTRUÍDO ===");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


// Debug: Listar endpoints após mapeamento
try
{
    var endpointDataSource = app.Services.GetService<Microsoft.AspNetCore.Routing.EndpointDataSource>();
    if (endpointDataSource != null)
    {
        var endpoints = endpointDataSource.Endpoints;
        Console.WriteLine("=== ENDPOINTS REGISTRADOS ===");
        foreach (var endpoint in endpoints)
        {
            if (endpoint is Microsoft.AspNetCore.Routing.RouteEndpoint routeEndpoint)
            {
                Console.WriteLine($"- {routeEndpoint.RoutePattern.RawText}");
            }
        }
        Console.WriteLine("=============================");
    }
    else
    {
        Console.WriteLine("=== ENDPOINT DATA SOURCE NÃO ENCONTRADO ===");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"=== ERRO AO LISTAR ENDPOINTS: {ex.Message} ===");
}

Console.WriteLine("=== APLICAÇÃO INICIADA ===");

app.Run();