using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetFollowByIdQuery(FollowId Id)
    : IIncludableQuery<FollowIncludeProperty>
{
    public CommonIncludeQuery<FollowIncludeProperty>? Include { get; private set; }

    public GetFollowByIdQuery AddInclude(CommonIncludeQuery<FollowIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
