using InstaConnect.Users.Domain.Features.Users.Abstractions;

namespace InstaConnect.Users.Domain.Features.Users.Helpers;

public class UserIncludeQueryBuilderFactory : IUserIncludeQueryBuilderFactory
{
    public UserIncludeQueryBuilder Create()
    {
        return new UserIncludeQueryBuilder([]);
    }
}
