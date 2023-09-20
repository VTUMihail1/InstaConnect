using InstaConnect.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Data.EntityConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("comment");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(p => p.Content)
                .HasColumnName("content")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.UserId)
                .HasColumnName("user_id")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.PostId)
                .HasColumnName("post_id")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.CommentId)
                .HasColumnName("comment_id")
                .HasMaxLength(255);

            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Comments)
                .WithOne()
                .HasForeignKey(c => c.CommentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
