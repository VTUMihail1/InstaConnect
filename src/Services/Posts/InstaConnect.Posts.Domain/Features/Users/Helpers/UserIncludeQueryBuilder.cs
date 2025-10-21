using InstaConnect.Users.Domain.Features.Users.Abstractions;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Users.Domain.Features.Users.Helpers;

public class UserIncludeQueryBuilder
{
    private readonly ICollection<UserIncludeProperty> _includeProperties;

    internal UserIncludeQueryBuilder(ICollection<UserIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public UserIncludeQueryBuilder WithFollows()
    {
        _includeProperties.Add(UserIncludeProperty.Follows);

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

    public UserIncludeQuery Build()
    {
        return new UserIncludeQuery(_includeProperties);
    }
}
