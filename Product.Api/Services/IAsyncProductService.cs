using Product.Api.Models;

namespace Product.Api.Services;

public interface IAsyncProductService
{
    Task<Models.Product?> GetProductByIdAsync(Guid id);
    Task<IEnumerable<Models.Product>> GetProductsAsync();
    Task<IEnumerable<Vegetables>> GetVegetablesAsync();
    Task<Models.Product> CreateProductAsync(Models.Product product);
    Task<Vegetables> CreateVegetableAsync(Vegetables vegetable);
    Task<Models.Product> DeleteAllProductsAsync();
}