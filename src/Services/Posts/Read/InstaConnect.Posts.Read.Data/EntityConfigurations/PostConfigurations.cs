﻿using InstaConnect.Posts.Read.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Posts.Read.Data.EntityConfigurations;

public class PostConfigurations : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .ToTable("post");

        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(p => p.Title)
            .HasColumnName("title")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(p => p.Content)
            .HasColumnName("content")
            .HasMaxLength(5000)
            .IsRequired();

        builder
            .Property(p => p.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .HasColumnName("created_at");

        builder
            .Property(t => t.UpdatedAt)
            .HasColumnName("updated_at");

        builder
            .HasMany(p => p.PostLikes)
            .WithOne(pl => pl.Post)
            .HasForeignKey(pl => pl.PostId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(pl => pl.User)
            .WithMany(p => p.Posts)
            .HasForeignKey(pl => pl.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(p => p.PostComments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}