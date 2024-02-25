using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Product.Api.Models;

namespace Product.Api.Data;

public class AuthContext(DbContextOptions<AuthContext> options) : IdentityDbContext<AppUser>(options)
{
    public override DbSet<AppUser> Users => Set<AppUser>();
}