using InstaConnect.PostComments.Common.Features.PostComments.Utilities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.EntityConfigurations;

public class PostCommentEntityConfigurations : IEntityTypeConfiguration<PostComment>
{
    public void Configure(EntityTypeBuilder<PostComment> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasMaxLength(PostConfigurations.IdMaxLength)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(p => p.CommentId)
            .HasMaxLength(PostCommentConfigurations.IdMaxLength)
            .IsRequired();

        builder
            .Property(p => p.UserId)
            .HasMaxLength(UserConfigurations.IdMaxLength)
            .IsRequired();

        builder
            .Property(p => p.Content)
            .HasMaxLength(PostCommentConfigurations.ContentMaxLength)
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .IsRequired();

        builder
            .Property(t => t.UpdatedAt)
            .IsRequired();

        builder
            .HasOne(pl => pl.User)
            .WithMany(p => p.PostComments)
            .HasForeignKey(pl => pl.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(p => p.Likes)
            .WithOne()
            .HasForeignKey(pl => pl.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
