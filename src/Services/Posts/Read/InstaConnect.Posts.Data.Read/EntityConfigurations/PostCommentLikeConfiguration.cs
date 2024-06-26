﻿using InstaConnect.Posts.Data.Read.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Posts.Data.Read.EntityConfigurations;

public class PostCommentLikeConfiguration : IEntityTypeConfiguration<PostCommentLike>
{
    public void Configure(EntityTypeBuilder<PostCommentLike> builder)
    {
        builder
            .ToTable("post_comment_like");

        builder
            .HasKey(cl => cl.Id);

        builder
            .Property(cl => cl.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(cl => cl.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder
            .Property(cl => cl.PostCommentId)
            .HasColumnName("comment_id")
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .HasColumnName("created_at");

        builder
            .Property(t => t.UpdatedAt)
            .HasColumnName("updated_at");

        builder
            .HasOne(pl => pl.User)
            .WithMany(p => p.PostCommentLikes)
            .HasForeignKey(pl => pl.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(cl => cl.PostComment)
            .WithMany(pc => pc.CommentLikes)
            .HasForeignKey(cl => cl.PostCommentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
