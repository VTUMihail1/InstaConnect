using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Infrastructure.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Identity.Infrastructure;

public class IdentityContext : DbContext
{
    public IdentityContext(DbContextOptions options) : base(options)
    { }

    public DbSet<User> Users { get; set; }

    public DbSet<UserClaim> UserClaims { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public DbSet<EmailConfirmationToken> EmailConfirmationTokens { get; set; }

    public DbSet<ForgotPasswordToken> ForgotPasswordTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(IdentityInfrastructureReference.Assembly);

        modelBuilder.ApplyTransactionalOutboxEntityConfiguration();
    }
}
