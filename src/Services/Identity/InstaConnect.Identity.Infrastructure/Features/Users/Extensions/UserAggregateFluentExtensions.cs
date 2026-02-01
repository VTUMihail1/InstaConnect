using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

public static class UserAggregateFluentExtensions
{
    public static IAggregateFluent<User> Match(
        this IAggregateFluent<User> aggregate,
        UserFilterQuery filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

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

    public static IAggregateFluent<UserResponse> ProjectToResponse(
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
