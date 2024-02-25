using System.ComponentModel.DataAnnotations;

namespace Product.Api.DTOs;

public class LoginRequestDto
{
    /// <summary>
    /// Email
    /// </summary>
    [DataType(DataType.EmailAddress)]
    public required string Email { get; init; } = string.Empty;

    /// <summary>
    /// Password
    /// </summary>
    [DataType(DataType.Password)]
    public required string Password { get; init; } = string.Empty;
}