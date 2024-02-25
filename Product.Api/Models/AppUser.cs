using Microsoft.AspNetCore.Identity;

namespace Product.Api.Models;

public class AppUser : IdentityUser
{
    /// <summary>
    /// This property is used to define the RefreshToken property.
    /// </summary>
    public string? RefreshToken { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}