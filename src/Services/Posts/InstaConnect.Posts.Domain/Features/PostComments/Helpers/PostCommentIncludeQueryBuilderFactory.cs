namespace InstaConnect.Posts.Domain.Features.PostComments.Helpers;

public class PostCommentIncludeQueryBuilderFactory : IPostCommentIncludeQueryBuilderFactory
{
    public PostCommentIncludeQueryBuilder Create()
    {
        return new PostCommentIncludeQueryBuilder([]);
    }
}
