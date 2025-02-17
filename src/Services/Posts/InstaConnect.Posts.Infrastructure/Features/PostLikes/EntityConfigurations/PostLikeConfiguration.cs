namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.EntityConfigurations;

public class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
{
    public void Configure(EntityTypeBuilder<PostLike> builder)
    {
        builder
            .ToTable("post_like");

        builder
            .HasKey(pl => pl.Id);

        builder
            .Property(pl => pl.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(pl => pl.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder
            .Property(pl => pl.PostId)
            .HasColumnName("post_id")
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .HasColumnName("created_at");

        builder
            .Property(t => t.UpdatedAt)
            .HasColumnName("updated_at");

        builder
            .HasOne(pl => pl.Post)
            .WithMany(p => p.PostLikes)
            .HasForeignKey(pl => pl.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(pl => pl.User)
            .WithMany(p => p.PostLikes)
            .HasForeignKey(pl => pl.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
