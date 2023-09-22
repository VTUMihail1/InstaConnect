using InstaConnect.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Data.EntityConfigurations
{
    public class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
    {
        public void Configure(EntityTypeBuilder<PostLike> builder)
        {
            builder.ToTable("post_like");

            builder.HasKey(pl => pl.Id);

            builder.Property(pl => pl.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(pl => pl.UserId)
                .HasColumnName("user_id")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(pl => pl.PostId)
                .HasColumnName("post_id")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(pl => pl.CreatedAt).HasColumnName("created_at");
            builder.Property(pl => pl.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(pl => pl.User)
                .WithMany(u => u.PostLikes)
                .HasForeignKey(pl => pl.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pl => pl.Post)
                .WithMany(p => p.PostLikes)
                .HasForeignKey(pl => pl.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
