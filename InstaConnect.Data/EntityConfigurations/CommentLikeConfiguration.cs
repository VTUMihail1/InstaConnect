using InstaConnect.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Data.EntityConfigurations
{
    public class CommentLikeConfiguration : IEntityTypeConfiguration<CommentLike>
    {
        public void Configure(EntityTypeBuilder<CommentLike> builder)
        {
            builder.ToTable("comment_like");

            builder.HasKey(cl => cl.Id);

            builder.Property(cl => cl.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(cl => cl.UserId)
                .HasColumnName("user_id")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(cl => cl.PostCommentId)
                .HasColumnName("comment_id")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(cl => cl.CreatedAt).HasColumnName("created_at");
            builder.Property(cl => cl.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(cl => cl.User)
                .WithMany(u => u.CommentLikes)
                .HasForeignKey(cl => cl.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cl => cl.PostComment)
                .WithMany(pc => pc.CommentLikes)
                .HasForeignKey(cl => cl.PostCommentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
