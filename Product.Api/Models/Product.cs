namespace Product.Api.Models;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string? Image { get; set; }
}