using InstaConnect.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Data.EntityConfigurations
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

            builder.HasOne(f => f.Following)
                .WithMany(u => u.Followings)
                .HasForeignKey(f => f.FollowingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Follower)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
