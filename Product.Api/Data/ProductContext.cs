using Microsoft.EntityFrameworkCore;

namespace Product.Api.Data;

public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
{
    public virtual DbSet<Models.Product> Products => Set<Models.Product>();
    public virtual DbSet<Models.Vegetables> Vegetables => Set<Models.Vegetables>();
    
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