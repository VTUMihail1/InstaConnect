using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.EntityConfigurations;

public class EmailConfirmationTokenEntityConfigurations : IEntityTypeConfiguration<EmailConfirmationToken>
{
    public void Configure(EntityTypeBuilder<EmailConfirmationToken> builder)
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
            .HasMaxLength(EmailConfirmationTokenConfigurations.ValueMaxLength)
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
