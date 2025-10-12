using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;

public class PostIncludeQueryBuilder
{
    private readonly ICollection<PostIncludeProperty> _includeProperties;

    internal PostIncludeQueryBuilder(ICollection<PostIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public PostIncludeQueryBuilder WithUser()
    {
        _includeProperties.Add(PostIncludeProperty.User);

        return this;
    }

    public PostIncludeQueryBuilder WithLikes()
    {
        _includeProperties.Add(PostIncludeProperty.Likes);

        return this;
    }

    public PostIncludeQueryBuilder WithComments()
    {
        _includeProperties.Add(PostIncludeProperty.Comments);

        return this;
    }

    public PostIncludeQuery Build()
    {
        return new PostIncludeQuery(_includeProperties);
    }
}
