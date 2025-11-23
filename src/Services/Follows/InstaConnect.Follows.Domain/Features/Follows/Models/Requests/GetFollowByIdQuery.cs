namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetFollowByIdQuery(FollowId Id)
{
    public FollowIncludeQuery? Include { get; private set; }

    public GetFollowByIdQuery AddInclude(FollowIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
