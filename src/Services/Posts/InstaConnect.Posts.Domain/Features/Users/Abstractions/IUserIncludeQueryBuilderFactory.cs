using InstaConnect.Posts.Domain.Features.Users.Helpers;

namespace InstaConnect.Posts.Domain.Features.Users.Abstractions;

public interface IUserIncludeQueryBuilderFactory
{
    UserIncludeQueryBuilder Create();
}