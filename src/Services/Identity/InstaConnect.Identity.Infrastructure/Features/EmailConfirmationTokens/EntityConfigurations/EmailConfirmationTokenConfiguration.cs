using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.EntityConfigurations;

public class EmailConfirmationTokenConfiguration : IEntityTypeConfiguration<EmailConfirmationToken>
{
    public void Configure(EntityTypeBuilder<EmailConfirmationToken> builder)
    {
        builder
            .ToTable("email_confirmation_token");

        builder
            .HasKey(t => t.Id);

        builder
            .Property(t => t.Id)
            .HasColumnName("id")
            .HasMaxLength(255)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(t => t.Value)
            .HasColumnName("value")
            .HasMaxLength(1000)
            .IsRequired();

        builder
            .Property(t => t.ValidUntil)
            .HasColumnName("is_valid_until")
            .IsRequired();

        builder
            .Property(t => t.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .HasColumnName("created_at");

        builder
            .Property(t => t.UpdatedAt)
            .HasColumnName("updated_at");

        builder
            .HasOne(t => t.User)
            .WithMany(u => u.EmailConfirmationTokens)
            .HasForeignKey(t => t.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
