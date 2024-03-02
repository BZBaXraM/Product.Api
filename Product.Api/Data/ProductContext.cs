using Microsoft.EntityFrameworkCore;

namespace Product.Api.Data;

public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
{
    public virtual DbSet<Models.Product> Products => Set<Models.Product>();
    public virtual DbSet<Models.Vegetables> Vegetables => Set<Models.Vegetables>();
    public virtual DbSet<Models.Sweet> Sweets => Set<Models.Sweet>();
    public virtual DbSet<Models.Bread> Breads => Set<Models.Bread>();
    public virtual DbSet<Models.Fruit> Fruits => Set<Models.Fruit>();
    public virtual DbSet<Models.Drink> Drinks => Set<Models.Drink>();

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     var products = new List<Models.Product>
    //     {
    //         new()
    //         {
    //             Id = Guid.NewGuid(),
    //             Name = "Product 1",
    //             Price = 100,
    //             Image = "https://via.placeholder.com/150"
    //         },
    //         
    //     };
    // }
}