namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

public class PostLikeIncludeQueryBuilderFactory : IPostLikeIncludeQueryBuilderFactory
{
    public PostLikeIncludeQueryBuilder Create()
    {
        return new PostLikeIncludeQueryBuilder([]);
    }
}
