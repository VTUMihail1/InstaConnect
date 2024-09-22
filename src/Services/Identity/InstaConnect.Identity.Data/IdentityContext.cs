using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Identity.Data;

public class IdentityContext : DbContext
{
    public IdentityContext(DbContextOptions options) : base(options)
    { }

    public DbSet<User> Users { get; set; }

    public DbSet<EmailConfirmationToken> EmailConfirmationTokens { get; set; }

    public DbSet<ForgotPasswordToken> ForgotPasswordTokens { get; set; }

    public DbSet<UserClaim> UserClaims { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var currentAssembly = typeof(IdentityContext).Assembly;

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);

        modelBuilder.ApplyTransactionalOutboxEntityConfiguration();
    }
}
