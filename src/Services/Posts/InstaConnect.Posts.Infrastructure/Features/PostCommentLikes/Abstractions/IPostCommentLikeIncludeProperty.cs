namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeIncludeProperty : IIncludeProperty<PostCommentLike>
{
    public PostCommentLikeIncludeProperty IncludeProperty { get; }
}
