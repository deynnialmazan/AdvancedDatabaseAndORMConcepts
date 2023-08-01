using BasicECommerce.Data;
using BasicECommerce.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BasicECommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceConnectionString"));
});

builder.Services.Configure<JsonOptions>(options => {
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

//	Endpoint: A means of viewing all Customers, with their associated addresses
app.MapGet("/customers/all/addresses", (BasicECommerceContext context) =>
{
    HashSet<CustomerAddress> cas = context.CustomerAddress.ToHashSet();
    HashSet<Address> addresses = context.Address.ToHashSet(); 
    return Results.Ok(context.Customer.ToHashSet()); 
});

//	A means of creating a new Product
//	A customer must make an order to a specific address for a specific product.
//	The API must verify that the customer is associated with the posted address
app.MapPost("/products/create", (BasicECommerceContext context, string name) => {
    try
    {
        if (context.Product.Any(p => p.Name.ToLower().Equals(name.ToLower())))
        {
            return Results.Conflict($"Product with name '{name}' already exists.");
        }

        Product newProduct = new Product { Name = name };

        context.Product.Add(newProduct);
        context.SaveChanges();

        Console.WriteLine(newProduct.Id);
        return Results.Created($"/products/{newProduct.Id}", newProduct);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }

});

app.Run();