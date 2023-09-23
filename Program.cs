using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Webshop.Api;
using Webshop.Api.Contracts;
using Webshop.Api.Orders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OrdersDbContext>(options =>
{
    options.UseSqlServer(connectionString,
        action => action.MigrationsHistoryTable(HistoryRepository.DefaultTableName,
        "orders"));
});

builder.Services.AddDbContext<ProductsDbContext>(options =>
{
    options.UseSqlServer(connectionString,
        action => action.MigrationsHistoryTable(HistoryRepository.DefaultTableName,
        "products"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/products", async (ProductsDbContext productsDbContext) =>
{
   var products = await productsDbContext.Products
    .Select(x => x.Id)
    .ToListAsync();

    return Results.Ok(products);
})
.WithName("GetProductIds")
.WithOpenApi();

app.MapPost("/orders", async (
    SubmitOrderRequest request,
    ProductsDbContext productsDbContext,
    OrdersDbContext ordersDbContext) =>
{
    var products = await productsDbContext.Products
     .Where(x => request.ProductIds.Contains(x.Id))
     .AsNoTracking()
     .ToListAsync();

    if (products.Count != request.ProductIds.Count)
    {
        return Results.BadRequest("Some products are missing");
    }

    var order = new Order
    {
        Id = Guid.NewGuid(),
        TotalPrice = products.Sum(x => x.Price),
        LineItems = products.Select(x => new LineItem
        {
            Id = Guid.NewGuid(),
            Price = x.Price,
            ProductId = x.Id
        }).ToList()
    };

    ordersDbContext.Orders.Add(order);
    await ordersDbContext.SaveChangesAsync();

    return Results.Ok(order);
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
