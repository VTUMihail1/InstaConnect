using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

internal static class UserAggregateFluentExtensions
{
    extension(IAggregateFluent<User> aggregate)
    {
        public IAggregateFluent<User> Match(UserId filter)
        {
            return aggregate.Match(filter.GetFilter());
        }

        public IAggregateFluent<User> Match(Name filter)
        {
            return aggregate.Match(filter.GetFilter());
        }

        public IAggregateFluent<User> Match(Email filter)
        {
            return aggregate.Match(filter.GetFilter());
        }

        public IAggregateFluent<UserResponse> ProjectToFullResponse(CurrentUserQuery currentUser)
        {
            var projection = Builders<User>.Projection.Expression(
                 u => new UserResponse(
                             u.Id,
                             u.FirstName,
                             u.LastName,
                             u.Email,
                             u.Name,
                             u.ProfileImage,
                             u.CreatedAtUtc,
                             u.UpdatedAtUtc));

            return aggregate.Project(projection);
        }
    }
}
