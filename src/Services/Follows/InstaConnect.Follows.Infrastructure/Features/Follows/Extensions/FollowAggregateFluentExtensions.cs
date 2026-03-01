using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

internal static class FollowAggregateFluentExtensions
{
    public static IAggregateFluent<Follow> Match(
        this IAggregateFluent<Follow> aggregate,
        FollowsForFollowerFilterQuery filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<Follow> Match(
        this IAggregateFluent<Follow> aggregate,
        FollowsForFollowingFilterQuery filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<Follow> Match(
        this IAggregateFluent<Follow> aggregate,
        FollowId filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<FollowResponse> ProjectToFullResponse(
        this IAggregateFluent<Follow> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<Follow>.Projection.Expression(
             p => new FollowResponse(
                 p.Id,
                 new UserResponse(
                     p.Follower!.Id,
                     p.Follower.FirstName,
                     p.Follower.LastName,
                     p.Follower.Email,
                     p.Follower.Name,
                     p.Follower.ProfileImage,
                     p.Follower.CreatedAtUtc,
                     p.Follower.UpdatedAtUtc),
                 new UserResponse(
                     p.Following!.Id,
                     p.Following.FirstName,
                     p.Following.LastName,
                     p.Following.Email,
                     p.Following.Name,
                     p.Following.ProfileImage,
                     p.Following.CreatedAtUtc,
                     p.Following.UpdatedAtUtc),
                 p.Id.FollowerId.Id.ToLower() == currentUserId,
                 p.CreatedAtUtc));

        return aggregate.Project(projection);
    }

    public static IAggregateFluent<FollowResponse> ProjectToResponseWithoutFollower(
        this IAggregateFluent<Follow> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<Follow>.Projection.Expression(
             p => new FollowResponse(
                 p.Id,
                 null,
                 new UserResponse(
                     p.Following!.Id,
                     p.Following.FirstName,
                     p.Following.LastName,
                     p.Following.Email,
                     p.Following.Name,
                     p.Following.ProfileImage,
                     p.Following.CreatedAtUtc,
                     p.Following.UpdatedAtUtc),
                 p.Id.FollowerId.Id.ToLower() == currentUserId,
                 p.CreatedAtUtc));

        return aggregate.Project(projection);
    }

    public static IAggregateFluent<FollowResponse> ProjectToResponseWithoutFollowing(
        this IAggregateFluent<Follow> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<Follow>.Projection.Expression(
             p => new FollowResponse(
                 p.Id,
                 new UserResponse(
                     p.Follower!.Id,
                     p.Follower.FirstName,
                     p.Follower.LastName,
                     p.Follower.Email,
                     p.Follower.Name,
                     p.Follower.ProfileImage,
                     p.Follower.CreatedAtUtc,
                     p.Follower.UpdatedAtUtc),
                 null,
                 p.Id.FollowerId.Id.ToLower() == currentUserId,
                 p.CreatedAtUtc));

        return aggregate.Project(projection);
    }
}
