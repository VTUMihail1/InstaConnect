using System.Linq.Expressions;

using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

internal static class PostLikeAggregateFluentExtensions
{
    public static IAggregateFluent<PostLike> Match(
        this IAggregateFluent<PostLike> aggregate,
        PostLikesFilterQuery filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<PostLike> Match(
        this IAggregateFluent<PostLike> aggregate,
        PostLikesForUserFilterQuery filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<PostLike> Match(
        this IAggregateFluent<PostLike> aggregate,
        PostLikeId filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<PostLikeResponse> ProjectToResponse(
        this IAggregateFluent<PostLike> aggregate,
        CurrentUserQuery currentUser)
    {
        var projection = Builders<PostLike>.Projection.Expression(
            p => new PostLikeResponse(
                p.Id,
                p.User == null
                    ? null
                    : new UserResponse(
                        p.User!.Id,
                        p.User.FirstName,
                        p.User.LastName,
                        p.User.Email,
                        p.User.Name,
                        p.User.ProfileImage,
                        p.User.CreatedAtUtc,
                        p.User.UpdatedAtUtc),
                p.Post == null
                    ? null
                    : new PostResponse(
                        p.Post.Id,
                        p.Post.UserId,
                        p.Post.Title,
                        p.Post.Content,
                        p.Post.User == null
                            ? null
                            : new UserResponse(
                                p.Post.User!.Id,
                                p.Post.User.FirstName,
                                p.Post.User.LastName,
                                p.Post.User.Email,
                                p.Post.User.Name,
                                p.Post.User.ProfileImage,
                                p.Post.User.CreatedAtUtc,
                                p.Post.User.UpdatedAtUtc),
                        p.Post.PostLikes.Any(
                            pl => pl.Id.UserId.Id.ToLower() ==
                                  currentUser.Id.Id.ToLower()),
                        p.Post.CreatedAtUtc,
                        p.Post.UpdatedAtUtc),
                p.CreatedAtUtc));

        return aggregate.Project(projection);
    }
}
