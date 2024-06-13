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

    public DbSet<UserClaim> UserClaims { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TokenConfiguration());
        modelBuilder.ApplyConfiguration(new UserClaimConfiguration());
    }
}
