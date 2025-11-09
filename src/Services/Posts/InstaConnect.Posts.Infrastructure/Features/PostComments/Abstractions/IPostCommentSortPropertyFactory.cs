namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
public interface IPostCommentSortPropertyFactory
{
    IPostCommentSortProperty Create(PostCommentSortProperty sortProperty);
}
