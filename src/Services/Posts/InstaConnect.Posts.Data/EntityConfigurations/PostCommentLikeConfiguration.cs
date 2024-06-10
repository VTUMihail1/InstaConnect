using InstaConnect.Posts.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Posts.Data.EntityConfigurations;

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
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(cl => cl.PostCommentId)
            .HasColumnName("comment_id")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .HasColumnType("timestamp(6)")
            .HasColumnName("created_at");

        builder
            .Property(t => t.UpdatedAt)
            .HasColumnType("timestamp(6)")
            .HasColumnName("updated_at");

        builder
            .HasOne(cl => cl.PostComment)
            .WithMany(pc => pc.CommentLikes)
            .HasForeignKey(cl => cl.PostCommentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
