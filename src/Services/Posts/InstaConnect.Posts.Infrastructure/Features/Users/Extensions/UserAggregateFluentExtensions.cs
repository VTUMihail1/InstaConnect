using System.Linq.Expressions;

using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

internal static class UserAggregateFluentExtensions
{
    public static IAggregateFluent<User> Match(
        this IAggregateFluent<User> aggregate,
        UserId filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<User> Match(
        this IAggregateFluent<User> aggregate,
        Name filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<User> Match(
        this IAggregateFluent<User> aggregate,
        Email filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<UserResponse> ProjectToFullResponse(
        this IAggregateFluent<User> aggregate,
        CurrentUserQuery currentUser)
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
