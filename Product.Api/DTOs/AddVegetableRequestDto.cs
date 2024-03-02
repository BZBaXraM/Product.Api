namespace Product.Api.DTOs;

public class AddVegetableRequestDto
{
    public required string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string? Image { get; set; }
}