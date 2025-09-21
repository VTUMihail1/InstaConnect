using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.EntityConfigurations;

public class RefreshTokenEntityConfigurations : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder
            .HasKey(p => p.Value);

        builder
            .Property(p => p.Id)
            .HasMaxLength(UserConfigurations.IdMaxLength)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(p => p.Value)
            .HasMaxLength(RefreshTokenConfigurations.ValueMaxLength)
            .IsRequired();

        builder
            .Property(p => p.ExpiresAt)
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .IsRequired();

        builder
            .Property(t => t.UpdatedAt)
            .IsRequired();
    }
}
