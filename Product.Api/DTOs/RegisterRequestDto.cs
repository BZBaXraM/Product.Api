using System.ComponentModel.DataAnnotations;

namespace Product.Api.DTOs;

public class RegisterRequestDto
{
    /// <summary>
    /// This property is used to define the Username property.
    /// </summary>
    [DataType(DataType.EmailAddress)]
    public required string Email { get; init; } = string.Empty;

    /// <summary>
    /// This property is used to define the Password property.
    /// </summary>
    [DataType(DataType.Password)]
    public required string Password { get; init; } = string.Empty;
}