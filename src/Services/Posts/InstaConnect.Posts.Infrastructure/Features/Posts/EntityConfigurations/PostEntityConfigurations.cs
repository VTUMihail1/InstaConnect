namespace InstaConnect.Posts.Infrastructure.Features.Posts.EntityConfigurations;

public class PostEntityConfigurations : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasMaxLength(PostConfigurations.IdMaxLength)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(p => p.Title)
            .HasMaxLength(PostConfigurations.TitleMaxLength)
            .IsRequired();

        builder
            .Property(p => p.Content)
            .HasMaxLength(PostConfigurations.ContentMaxLength)
            .IsRequired();

        builder
            .Property(p => p.UserId)
            .HasMaxLength(UserConfigurations.IdMaxLength)
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .IsRequired();

        builder
            .Property(t => t.UpdatedAt)
            .IsRequired();

        builder
            .HasMany(p => p.PostLikes)
            .WithOne(pl => pl.Post)
            .HasForeignKey(pl => pl.PostId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(pl => pl.User)
            .WithMany(p => p.Posts)
            .HasForeignKey(pl => pl.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(p => p.PostComments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
