using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

internal static class FollowAggregateFluentExtensions
{
    extension(IAggregateFluent<Follow> aggregate)
    {
        public IAggregateFluent<Follow> Match(FollowsFilterQuery filter)
        {
            return aggregate.Match(filter.GetFilter());
        }

        public IAggregateFluent<Follow> Match(FollowsForFollowingFilterQuery filter)
        {
            return aggregate.Match(filter.GetFilter());
        }

        public IAggregateFluent<Follow> Match(FollowId filter)
        {
            return aggregate.Match(filter.GetFilter());
        }

        public IAggregateFluent<FollowResponse> ProjectToFullResponse(CurrentUserQuery currentUser)
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

        public IAggregateFluent<FollowResponse> ProjectToResponseWithoutFollower(CurrentUserQuery currentUser)
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

        public IAggregateFluent<FollowResponse> ProjectToResponseWithoutFollowing(CurrentUserQuery currentUser)
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
}
