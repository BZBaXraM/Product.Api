namespace Product.Api.Services;

public interface IAsyncProductService
{
    Task<Models.Product?> GetProductByIdAsync(Guid id);
    Task<IEnumerable<Models.Product>> GetProductsAsync();
}