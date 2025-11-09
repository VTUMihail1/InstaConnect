namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class UserIncludeQueryBuilderFactory : IUserIncludeQueryBuilderFactory
{
    public UserIncludeQueryBuilder Create()
    {
        return new UserIncludeQueryBuilder([]);
    }
}
