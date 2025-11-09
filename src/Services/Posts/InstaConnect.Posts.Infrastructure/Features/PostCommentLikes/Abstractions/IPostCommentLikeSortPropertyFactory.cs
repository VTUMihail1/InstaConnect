namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;
public interface IPostCommentLikeSortPropertyFactory
{
    IPostCommentLikeSortProperty Create(PostCommentLikeSortProperty sortProperty);
}
