using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.Users.Helpers;

public class UserIncludeQueryBuilder
{
    private readonly ICollection<UserIncludeProperty> _includeProperties;

    internal UserIncludeQueryBuilder(ICollection<UserIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public UserIncludeQueryBuilder WithPosts()
    {
        _includeProperties.Add(UserIncludeProperty.Posts);

        return this;
    }

    public UserIncludeQueryBuilder WithPostLikes()
    {
        _includeProperties.Add(UserIncludeProperty.PostLikes);

        return this;
    }

    public UserIncludeQueryBuilder WithPostComments()
    {
        _includeProperties.Add(UserIncludeProperty.PostComments);

        return this;
    }

    public UserIncludeQueryBuilder WithPostCommentLikes()
    {
        _includeProperties.Add(UserIncludeProperty.PostCommentLikes);

        return this;
    }

    public CommonIncludeQuery<UserIncludeProperty> Build()
    {
        return new(_includeProperties);
    }
}
