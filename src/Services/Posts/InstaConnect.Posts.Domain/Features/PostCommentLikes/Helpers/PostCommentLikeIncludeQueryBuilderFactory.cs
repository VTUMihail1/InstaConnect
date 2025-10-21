using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Helpers;

public class PostCommentLikeIncludeQueryBuilderFactory : IPostCommentLikeIncludeQueryBuilderFactory
{
    public PostCommentLikeIncludeQueryBuilder Create()
    {
        return new PostCommentLikeIncludeQueryBuilder([]);
    }
}
