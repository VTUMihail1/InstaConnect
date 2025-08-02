using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.EntityConfigurations;

public class PostCommentLikeEntityConfigurations : IEntityTypeConfiguration<PostCommentLike>
{
    public void Configure(EntityTypeBuilder<PostCommentLike> builder)
    {
        builder
            .HasKey(p => p.CommentLikeId);

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
            .Property(p => p.CommentLikeId)
            .HasMaxLength(PostCommentLikeConfigurations.IdMaxLength)
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
            .HasOne(pcl => pcl.User)
            .WithMany(p => p.PostCommentLikes)
            .HasForeignKey(pcl => pcl.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
