using System.Linq.Expressions;

using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Infrastructure.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

using Microsoft.AspNetCore.DataProtection.KeyManagement;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

internal static class PostAggregateFluentExtensions
{
    public static IAggregateFluent<Post> Match(
        this IAggregateFluent<Post> aggregate,
        PostsFilterQuery filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<Post> Match(
        this IAggregateFluent<Post> aggregate,
        PostsForUserFilterQuery filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<Post> Match(
        this IAggregateFluent<Post> aggregate,
        PostId filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<PostResponse> ProjectToFullResponse(
        this IAggregateFluent<Post> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<Post>.Projection.Expression(
             p => new PostResponse(
                 p.Id,
                 p.UserId,
                 p.Title,
                 p.Content,
                 new UserResponse(
                     p.User!.Id,
                     p.User.FirstName,
                     p.User.LastName,
                     p.User.Email,
                     p.User.Name,
                     p.User.ProfileImage,
                     p.User.CreatedAtUtc,
                     p.User.UpdatedAtUtc),
                 p.PostLikes.Any(
                     pl => pl.Id.UserId.Id.ToLower() == currentUserId),
                 p.CreatedAtUtc,
                 p.UpdatedAtUtc));

        return aggregate.Project(projection);
    }

    public static IAggregateFluent<PostResponse> ProjectToResponseWithoutUser(
        this IAggregateFluent<Post> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<Post>.Projection.Expression(
             p => new PostResponse(
                 p.Id,
                 p.UserId,
                 p.Title,
                 p.Content,
                 null,
                 p.PostLikes.Any(
                     pl => pl.Id.UserId.Id.ToLower() == currentUserId),
                 p.CreatedAtUtc,
                 p.UpdatedAtUtc));

        return aggregate.Project(projection);
    }
}
