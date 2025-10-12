using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;

public class PostIncludeQueryBuilderFactory : IPostIncludeQueryBuilderFactory
{
    public PostIncludeQueryBuilder Create()
    {
        return new PostIncludeQueryBuilder([]);
    }
}
