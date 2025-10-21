using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Helpers;

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

    public PostLikeIncludeQuery Build()
    {
        return new PostLikeIncludeQuery(_includeProperties);
    }
}
