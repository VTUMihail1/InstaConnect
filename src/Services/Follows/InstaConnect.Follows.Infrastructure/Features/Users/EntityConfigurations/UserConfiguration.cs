using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.Users.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .HasMaxLength(UserConfigurations.IdMaxLength)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(u => u.FirstName)
            .HasMaxLength(UserConfigurations.FirstNameMaxLength)
            .IsRequired();

        builder
            .Property(u => u.LastName)
            .HasMaxLength(UserConfigurations.LastNameMaxLength)
            .IsRequired();

        builder
            .Property(u => u.Email)
            .HasMaxLength(UserConfigurations.EmailMaxLength)
            .IsRequired();

        builder
            .Property(u => u.Name)
            .HasMaxLength(UserConfigurations.NameMaxLength)
            .IsRequired();

        builder
            .Property(u => u.ProfileImage)
            .HasMaxLength(UserConfigurations.ProfileImageMaxLength);

        builder.HasMany(f => f.Follows)
                .WithOne(u => u.Follower)
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(f => f.Follows)
                .WithOne(u => u.Following)
                .HasForeignKey(f => f.FollowingId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
