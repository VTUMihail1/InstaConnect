using InstaConnect.Posts.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Posts.Data.EntityConfigurations;

public class PostCommentConfiguration : IEntityTypeConfiguration<PostComment>
{
    public void Configure(EntityTypeBuilder<PostComment> builder)
    {
        builder
            .ToTable("post_comment");

        builder
            .HasKey(pc => pc.Id);

        builder
            .Property(pc => pc.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(pc => pc.Content)
            .HasColumnName("content")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(pc => pc.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder
            .Property(pc => pc.UserName)
            .HasColumnName("user_name")
            .IsRequired();

        builder
            .Property(pc => pc.PostId)
            .HasColumnName("post_id")
            .IsRequired();

        builder
            .Property(pc => pc.PostCommentId)
            .HasColumnName("comment_id")
            .HasMaxLength(255);

        builder
            .Property(t => t.CreatedAt)
            .HasColumnName("created_at");

        builder
            .Property(t => t.UpdatedAt)
            .HasColumnName("updated_at");

        builder
            .HasOne(pc => pc.Post)
            .WithMany(p => p.PostComments)
            .HasForeignKey(pc => pc.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(c => c.PostComments)
            .WithOne()
            .HasForeignKey(c => c.PostCommentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
