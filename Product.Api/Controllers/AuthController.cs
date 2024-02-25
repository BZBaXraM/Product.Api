using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Api.DTOs;
using Product.Api.Models;
using Product.Api.Services;

namespace Product.Api.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _service;

    public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        ITokenService service)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _service = service;
    }


    [HttpPost("register")]
    public async Task<ActionResult<AuthTokenDto>> Register([FromBody] RegisterRequestDto request)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser is not null)
        {
            return Conflict("User with same email already exists");
        }

        var user = new AppUser
        {
            UserName = request.Email,
            Email = request.Email,
            RefreshToken = Guid.NewGuid().ToString("N").ToLower()
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return await GenerateToken(user);
    }


    [HttpPost("login")]
    public async Task<ActionResult<AuthTokenDto>> Login([FromBody] LoginRequestDto request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Unauthorized();
        }

        var canSignIn = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!canSignIn.Succeeded)
        {
            return Unauthorized();
        }

        var role = await _userManager.GetRolesAsync(user);
        var userClaims = await _userManager.GetClaimsAsync(user);

        var accessToken = _service.GenerateSecurityToken(user.Id, user.UserName!, role, userClaims);
        var refreshToken = Guid.NewGuid().ToString("N").ToLower();
        user.RefreshToken = refreshToken;
        await _userManager.UpdateAsync(user);

        return new AuthTokenDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }


    [HttpPost("refresh")]
    public async Task<ActionResult<AuthTokenDto>> Refresh(
        [FromBody] RefreshTokenRequest request)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken);
        if (user is null)
        {
            return Unauthorized();
        }

        return await GenerateToken(user);
    }


    private async Task<AuthTokenDto> GenerateToken(AppUser user)
    {
        var role = await _userManager.GetRolesAsync(user);
        var userClaims = await _userManager.GetClaimsAsync(user);

        var accessToken = _service.GenerateSecurityToken(user.Id, user.UserName!,
            role, userClaims);
        var refreshToken = user.RefreshToken;

        await _userManager.UpdateAsync(user);

        return new AuthTokenDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken!
        };
    }
}