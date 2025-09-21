using InstaConnect.Identity.Domain.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.EntityConfigurations;

public class UserClaimEntityConfigurations : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder
            .HasKey(p => p.Claim);

        builder
            .Property(p => p.Id)
            .HasMaxLength(UserConfigurations.IdMaxLength)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(p => p.Claim)
            .HasMaxLength(UserClaimConfigurations.ClaimMaxLength)
            .IsRequired();

        builder
            .Property(p => p.Value)
            .HasMaxLength(UserClaimConfigurations.ValueMaxLength)
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .IsRequired();

        builder
            .Property(t => t.UpdatedAt)
            .IsRequired();
    }
}
