namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetFollowByIdQuery(FollowId Id)
    : IIncludableQuery<FollowIncludeProperty>
{
    public FollowInclude Include { get; private set; }

    public GetFollowByIdQuery AddInclude(CommonInclude<FollowIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
