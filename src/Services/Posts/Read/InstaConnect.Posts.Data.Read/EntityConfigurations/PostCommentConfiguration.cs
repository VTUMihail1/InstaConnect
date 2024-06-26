using InstaConnect.Posts.Data.Read.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Posts.Data.Read.EntityConfigurations;

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
            .Property(pc => pc.PostId)
            .HasColumnName("post_id")
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .HasColumnName("created_at");

        builder
            .Property(t => t.UpdatedAt)
            .HasColumnName("updated_at");

        builder
            .HasOne(pl => pl.User)
            .WithMany(p => p.PostComments)
            .HasForeignKey(pl => pl.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(pc => pc.Post)
            .WithMany(p => p.PostComments)
            .HasForeignKey(pc => pc.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
