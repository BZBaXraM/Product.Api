using Microsoft.EntityFrameworkCore;

namespace Product.Api.Data;

public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
{
    public virtual DbSet<Models.Product> Products => Set<Models.Product>();
}