using Microsoft.EntityFrameworkCore;
using Product.Api.Data;
using Product.Api.Models;

namespace Product.Api.Services;

public class ProductService(ProductContext context) : IAsyncProductService
{
    public async Task<Models.Product?> GetProductByIdAsync(Guid id)
    {
        var item = await context.Products.FindAsync(id);
        return new Models.Product { Id = item!.Id, Name = item.Name, Price = item.Price };
    }

    public async Task<IEnumerable<Models.Product>> GetProductsAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<IEnumerable<Vegetables>> GetVegetablesAsync()
    {
        return await context.Vegetables.ToListAsync();
    }

    public async Task<Models.Product> CreateProductAsync(Models.Product product)
    {
        var newProduct = new Models.Product
        {
            Id = Guid.NewGuid(),
            Name = product.Name,
            Price = product.Price,
            Image = product.Image
        };
        context.Products.Add(newProduct);
        await context.SaveChangesAsync();

        return newProduct;
    }

    public async Task<Vegetables> CreateVegetableAsync(Vegetables vegetable)
    {
        var newVegetable = new Vegetables
        {
            Id = Guid.NewGuid(),
            Name = vegetable.Name,
            Price = vegetable.Price,
            Image = vegetable.Image,
        };
        context.Vegetables.Add(newVegetable);
        await context.SaveChangesAsync();

        return newVegetable;
    }

    public async Task<Models.Product> DeleteAllProductsAsync()
    {
        var products = await context.Products.ToListAsync();
        context.Products.RemoveRange(products);
        await context.SaveChangesAsync();

        return new Models.Product
        {
            Id = Guid.Empty,
            Name = string.Empty,
            Price = 0
        };
    }
}