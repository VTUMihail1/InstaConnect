using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Helpers;

public class PostCommentIncludeQueryBuilderFactory : IPostCommentIncludeQueryBuilderFactory
{
    public PostCommentIncludeQueryBuilder Create()
    {
        return new PostCommentIncludeQueryBuilder([]);
    }
}
