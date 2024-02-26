using Microsoft.EntityFrameworkCore;
using Product.Api.Data;

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
}