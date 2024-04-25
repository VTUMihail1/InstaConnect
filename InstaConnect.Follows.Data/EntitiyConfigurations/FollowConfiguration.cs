﻿using InstaConnect.Follows.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Follows.Data.EntitiyConfigurations
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.ToTable("follow");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(f => f.FollowerId)
                .HasColumnName("follower_id")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(f => f.FollowingId)
                .HasColumnName("following_id")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(f => f.CreatedAt).HasColumnName("created_at");
            builder.Property(f => f.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
