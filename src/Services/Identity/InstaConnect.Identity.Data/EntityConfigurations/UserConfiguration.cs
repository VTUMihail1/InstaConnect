using InstaConnect.Identity.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Identity.Data.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("user");

        builder
            .Property(p => p.Id)
            .HasColumnName("id");

        builder
            .Property(p => p.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(p => p.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(p => p.Email)
            .HasColumnName("email");

        builder
            .Property(p => p.IsEmailConfirmed)
            .HasColumnName("is_email_confirmed");

        builder
            .Property(p => p.PasswordHash)
            .HasColumnName("password_hash");

        builder
            .Property(p => p.UserName)
            .HasColumnName("user_name");

        builder
            .Property(t => t.CreatedAt)
            .HasColumnName("created_at");

        builder
            .Property(t => t.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasMany(u => u.UserClaims)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Tokens)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
