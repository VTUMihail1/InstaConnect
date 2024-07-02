using InstaConnect.Follows.Data.Write.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Follows.Data.Write.EntityConfigurations;

public class FollowConfiguration : IEntityTypeConfiguration<Follow>
{
    public void Configure(EntityTypeBuilder<Follow> builder)
    {
        builder
            .ToTable("follow");

        builder
            .HasKey(f => f.Id);

        builder
            .Property(f => f.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(f => f.FollowerId)
            .HasColumnName("follower_id")
            .IsRequired();

        builder.Property(f => f.FollowingId)
            .HasColumnName("following_id")
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .HasColumnName("created_at");

        builder
            .Property(t => t.UpdatedAt)
            .HasColumnName("updated_at");
    }
}
