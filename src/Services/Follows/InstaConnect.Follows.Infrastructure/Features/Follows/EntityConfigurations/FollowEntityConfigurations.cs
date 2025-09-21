using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.EntityConfigurations;

public class FollowEntityConfigurations : IEntityTypeConfiguration<Follow>
{
    public void Configure(EntityTypeBuilder<Follow> builder)
    {
        builder
            .Property(p => p.FollowerId)
            .HasMaxLength(UserConfigurations.IdMaxLength)
            .IsRequired();

        builder
            .Property(p => p.FollowingId)
            .HasMaxLength(UserConfigurations.IdMaxLength)
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .IsRequired();

        builder
            .Property(t => t.UpdatedAt)
            .IsRequired();

        builder
            .HasOne(pl => pl.Follower)
            .WithMany(p => p.Follows)
            .HasForeignKey(pl => pl.FollowerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(pl => pl.Following)
            .WithMany(p => p.Follows)
            .HasForeignKey(pl => pl.FollowingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
