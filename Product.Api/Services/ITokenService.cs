using System.Security.Claims;

namespace Product.Api.Services;

public interface ITokenService
{
    string GenerateSecurityToken(
        string id,
        string email,
        IEnumerable<string> roles,
        IEnumerable<Claim> userClaims);
}