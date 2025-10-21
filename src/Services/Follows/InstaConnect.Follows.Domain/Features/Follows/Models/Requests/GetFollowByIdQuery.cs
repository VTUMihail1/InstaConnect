using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

public record GetFollowByIdQuery(string FollowerId, string FollowingId)
{
    public FollowIncludeQuery? Include { get; private set; }

    public GetFollowByIdQuery AddInclude(FollowIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
