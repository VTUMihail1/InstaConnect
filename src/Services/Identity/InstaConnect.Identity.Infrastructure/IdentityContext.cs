using InstaConnect.Shared.Infrastructure.Extensions;

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
