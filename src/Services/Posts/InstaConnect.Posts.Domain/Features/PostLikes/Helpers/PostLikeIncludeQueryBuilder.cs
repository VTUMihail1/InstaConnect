using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

public class PostLikeIncludeQueryBuilder
{
    private readonly ICollection<PostLikeIncludeProperty> _includeProperties;

    internal PostLikeIncludeQueryBuilder(ICollection<PostLikeIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public PostLikeIncludeQueryBuilder WithUser()
    {
        _includeProperties.Add(PostLikeIncludeProperty.User);

        return this;
    }

    public CommonIncludeQuery<PostLikeIncludeProperty> Build()
    {
        return new(_includeProperties);
    }
}
