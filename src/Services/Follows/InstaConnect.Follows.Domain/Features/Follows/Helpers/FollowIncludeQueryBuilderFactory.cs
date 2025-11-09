namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowIncludeQueryBuilderFactory : IFollowIncludeQueryBuilderFactory
{
    public FollowIncludeQueryBuilder Create()
    {
        return new FollowIncludeQueryBuilder([]);
    }
}
