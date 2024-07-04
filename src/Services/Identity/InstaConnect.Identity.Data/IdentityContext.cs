using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Identity.Data;

public class IdentityContext : DbContext
{
    public IdentityContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Token> Tokens { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserClaim> UserClaims { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var currentAssembly = typeof(IdentityContext).Assembly;

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);

        modelBuilder.ApplyTransactionalOutboxEntityConfiguration();
    }
}
