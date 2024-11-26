using InstaConnect.Follows.Domain.Features.Users.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Follows.Infrastructure.Features.Users.EntityConfigurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
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
            .Property(p => p.UserName)
            .HasColumnName("user_name");

        builder
            .Property(p => p.ProfileImage)
            .HasColumnName("profile_image");

        builder.HasMany(f => f.Followings)
                .WithOne(u => u.Following)
                .HasForeignKey(f => f.FollowingId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(f => f.Followers)
                    .WithOne(u => u.Follower)
                    .HasForeignKey(f => f.FollowerId)
                    .OnDelete(DeleteBehavior.Restrict);
    }
}
