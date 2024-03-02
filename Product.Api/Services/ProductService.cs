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

    public async Task<IEnumerable<Sweet>> GetSweetsAsync()
    {
        return await context.Sweets.ToListAsync();
    }

    public async Task<IEnumerable<Bread>> GetBreadsAsync()
    {
        return await context.Breads.ToListAsync();
    }

    public async Task<IEnumerable<Fruit>> GetFruitsAsync()
    {
        return await context.Fruits.ToListAsync();
    }

    public async Task<IEnumerable<Drink>> GetDrinksAsync()
    {
        return await context.Drinks.ToListAsync();
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
            Image = vegetable.Image
        };
        context.Vegetables.Add(newVegetable);
        await context.SaveChangesAsync();

        return newVegetable;
    }

    public async Task<Sweet> CreateSweetAsync(Sweet sweet)
    {
        var newSweet = new Sweet
        {
            Id = Guid.NewGuid(),
            Name = sweet.Name,
            Price = sweet.Price,
            Image = sweet.Image,
        };

        context.Sweets.Add(newSweet);
        await context.SaveChangesAsync();

        return newSweet;
    }

    public async Task<Bread> CreateBreadAsync(Bread bread)
    {
        var newBread = new Bread
        {
            Id = Guid.NewGuid(),
            Name = bread.Name,
            Price = bread.Price,
            Image = bread.Image,
        };

        context.Breads.Add(newBread);
        await context.SaveChangesAsync();

        return newBread;
    }

    public async Task<Fruit> CreateFruitAsync(Fruit fruit)
    {
        var newFruit = new Fruit
        {
            Id = Guid.NewGuid(),
            Name = fruit.Name,
            Price = fruit.Price,
            Image = fruit.Image,
        };

        context.Fruits.Add(newFruit);
        await context.SaveChangesAsync();

        return newFruit;
    }

    public async Task<Drink> CreateDrinkAsync(Drink drink)
    {
        var newDrink = new Drink
        {
            Id = Guid.NewGuid(),
            Name = drink.Name,
            Price = drink.Price,
            Image = drink.Image
        };

        context.Drinks.Add(newDrink);
        await context.SaveChangesAsync();

        return newDrink;
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