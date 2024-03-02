using Product.Api.Models;

namespace Product.Api.Services;

public interface IAsyncProductService
{
    Task<Models.Product?> GetProductByIdAsync(Guid id);
    Task<IEnumerable<Models.Product>> GetProductsAsync();
    Task<IEnumerable<Vegetables>> GetVegetablesAsync();
    Task<IEnumerable<Sweet>> GetSweetsAsync();
    Task<IEnumerable<Bread>> GetBreadsAsync();
    Task<IEnumerable<Fruit>> GetFruitsAsync();
    Task<IEnumerable<Drink>> GetDrinksAsync();
    Task<Models.Product> CreateProductAsync(Models.Product product);
    Task<Vegetables> CreateVegetableAsync(Vegetables vegetable);
    Task<Sweet> CreateSweetAsync(Sweet sweet);
    Task<Bread> CreateBreadAsync(Bread bread);
    Task<Fruit> CreateFruitAsync(Fruit fruit);
    Task<Drink> CreateDrinkAsync(Drink drink);
    Task<Models.Product> DeleteAllProductsAsync();
}