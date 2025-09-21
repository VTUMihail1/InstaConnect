using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.EntityConfigurations;

public class ForgotPasswordTokenEntityConfigurations : IEntityTypeConfiguration<ForgotPasswordToken>
{
    public void Configure(EntityTypeBuilder<ForgotPasswordToken> builder)
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
            .HasMaxLength(ForgotPasswordTokenConfigurations.ValueMaxLength)
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
