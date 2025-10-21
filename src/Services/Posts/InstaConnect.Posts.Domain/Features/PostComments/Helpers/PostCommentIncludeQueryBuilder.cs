using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Helpers;

public class PostCommentIncludeQueryBuilder
{
    private readonly ICollection<PostCommentIncludeProperty> _includeProperties;

    internal PostCommentIncludeQueryBuilder(ICollection<PostCommentIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public PostCommentIncludeQueryBuilder WithUser()
    {
        _includeProperties.Add(PostCommentIncludeProperty.User);

        return this;
    }

    public PostCommentIncludeQueryBuilder WithLikes()
    {
        _includeProperties.Add(PostCommentIncludeProperty.Likes);

        return this;
    }

    public PostCommentIncludeQuery Build()
    {
        return new PostCommentIncludeQuery(_includeProperties);
    }
}
