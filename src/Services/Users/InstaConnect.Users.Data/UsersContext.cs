using InstaConnect.Shared.Data;
using InstaConnect.Users.Data.EntityConfigurations;
using InstaConnect.Users.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Users.Data;

public class UsersContext : BaseDbContext
{
    public UsersContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Token> Tokens { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<RoleClaim> RoleClaims { get; set; }

    public DbSet<UserClaim> UserClaims { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<UserLogin> UserLogins { get; set; }

    public DbSet<UserToken> UserTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TokenConfiguration());
        modelBuilder.ApplyConfiguration(new UserLoginConfiguration());
        modelBuilder.ApplyConfiguration(new UserTokenConfiguration());
        modelBuilder.ApplyConfiguration(new RoleClaimConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserClaimConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
    }
}
