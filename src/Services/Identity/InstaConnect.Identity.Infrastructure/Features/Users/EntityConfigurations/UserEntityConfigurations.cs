using InstaConnect.Identity.Domain.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Identity.Infrastructure.Features.Users.EntityConfigurations;

public class UserEntityConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasMaxLength(UserConfigurations.IdMaxLength)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(p => p.Name)
            .HasMaxLength(UserConfigurations.NameMaxLength)
            .IsRequired();

        builder
            .Property(p => p.FirstName)
            .HasMaxLength(UserConfigurations.FirstNameMaxLength)
            .IsRequired();

        builder
            .Property(p => p.LastName)
            .HasMaxLength(UserConfigurations.LastNameMaxLength)
            .IsRequired();

        builder
            .Property(p => p.ProfileImage)
            .HasMaxLength(UserConfigurations.ProfileImageMaxLength)
            .IsRequired();

        builder
            .Property(p => p.ProfileImage)
            .HasMaxLength(UserConfigurations.ProfileImageMaxLength)
            .IsRequired();

        builder
            .Property(p => p.PasswordHash)
            .HasMaxLength(UserConfigurations.PasswordHashMaxLength)
            .IsRequired();

        builder
            .Property(p => p.IsEmailConfirmed)
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .IsRequired();

        builder
            .Property(t => t.UpdatedAt)
            .IsRequired();

        builder
            .HasMany(p => p.Claims)
            .WithOne()
            .HasForeignKey(pl => pl.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(p => p.Claims)
            .WithOne()
            .HasForeignKey(pl => pl.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(p => p.EmailConfirmationTokens)
            .WithOne()
            .HasForeignKey(pl => pl.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(p => p.ForgotPasswordTokens)
            .WithOne()
            .HasForeignKey(pl => pl.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
