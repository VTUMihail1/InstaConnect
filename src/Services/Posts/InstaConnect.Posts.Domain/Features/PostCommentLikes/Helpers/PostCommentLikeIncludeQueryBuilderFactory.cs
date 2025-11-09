namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

public class PostCommentLikeIncludeQueryBuilderFactory : IPostCommentLikeIncludeQueryBuilderFactory
{
    public PostCommentLikeIncludeQueryBuilder Create()
    {
        return new PostCommentLikeIncludeQueryBuilder([]);
    }
}
