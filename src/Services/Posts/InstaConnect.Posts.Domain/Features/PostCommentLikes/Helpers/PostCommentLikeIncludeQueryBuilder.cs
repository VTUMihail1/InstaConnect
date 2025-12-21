using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

public class PostCommentLikeIncludeQueryBuilder
{
    private readonly ICollection<PostCommentLikeIncludeProperty> _includeProperties;

    internal PostCommentLikeIncludeQueryBuilder(ICollection<PostCommentLikeIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public PostCommentLikeIncludeQueryBuilder WithUser()
    {
        _includeProperties.Add(PostCommentLikeIncludeProperty.User);

        return this;
    }

    public CommonIncludeQuery<PostCommentLikeIncludeProperty> Build()
    {
        return new(_includeProperties);
    }
}
