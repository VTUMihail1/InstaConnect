﻿namespace InstaConnect.Follows.Infrastructure.Features.Follows.EntityConfigurations;

internal class FollowConfiguration : IEntityTypeConfiguration<Follow>
{
    public void Configure(EntityTypeBuilder<Follow> builder)
    {
        builder
            .ToTable("follow");

        builder
            .HasKey(f => f.Id);

        builder
            .Property(f => f.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(f => f.FollowerId)
            .HasColumnName("follower_id")
            .IsRequired();

        builder.Property(f => f.FollowingId)
            .HasColumnName("following_id")
            .IsRequired();

        builder.HasOne(f => f.Following)
                .WithMany(u => u.Followings)
                .HasForeignKey(f => f.FollowingId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.Follower)
            .WithMany(u => u.Followers)
            .HasForeignKey(f => f.FollowerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
