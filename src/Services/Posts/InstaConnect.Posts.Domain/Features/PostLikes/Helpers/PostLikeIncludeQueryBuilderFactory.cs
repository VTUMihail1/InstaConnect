using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Helpers;

public class PostLikeIncludeQueryBuilderFactory : IPostLikeIncludeQueryBuilderFactory
{
    public PostLikeIncludeQueryBuilder Create()
    {
        return new PostLikeIncludeQueryBuilder([]);
    }
}
