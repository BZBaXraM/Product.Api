namespace Product.Api.DTOs;

public class AuthTokenDto
{
    /// <summary>
    ///   AccessToken
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;
    /// <summary>
    ///  RefreshToken
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;
}