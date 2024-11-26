using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Identity.Infrastructure;

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
