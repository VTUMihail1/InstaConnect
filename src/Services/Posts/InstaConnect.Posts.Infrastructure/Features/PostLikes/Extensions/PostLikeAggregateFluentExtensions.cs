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

    public static IAggregateFluent<PostLikeResponse> ProjectToFullResponse(
        this IAggregateFluent<PostLike> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<PostLike>.Projection.Expression(
            p => new PostLikeResponse(
                p.Id,
                new UserResponse(
                    p.User!.Id,
                    p.User.FirstName,
                    p.User.LastName,
                    p.User.Email,
                    p.User.Name,
                    p.User.ProfileImage,
                    p.User.CreatedAtUtc,
                    p.User.UpdatedAtUtc),
                new PostResponse(
                    p.Post!.Id,
                    p.Post.UserId,
                    p.Post.Title,
                    p.Post.Content,
                        new UserResponse(
                            p.Post.User!.Id,
                            p.Post.User.FirstName,
                            p.Post.User.LastName,
                            p.Post.User.Email,
                            p.Post.User.Name,
                            p.Post.User.ProfileImage,
                            p.Post.User.CreatedAtUtc,
                            p.Post.User.UpdatedAtUtc),
                    p.Post.PostLikes.Any(
                        pl => pl.Id.UserId.Id.ToLower() == currentUserId),
                    p.Post.CreatedAtUtc,
                    p.Post.UpdatedAtUtc),
                p.CreatedAtUtc));

        return aggregate.Project(projection);
    }

    public static IAggregateFluent<PostLikeResponse> ProjectToResponseWithoutUser(
        this IAggregateFluent<PostLike> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<PostLike>.Projection.Expression(
            p => new PostLikeResponse(
                p.Id,
                null,
                new PostResponse(
                    p.Post!.Id,
                    p.Post.UserId,
                    p.Post.Title,
                    p.Post.Content,
                        new UserResponse(
                            p.Post.User!.Id,
                            p.Post.User.FirstName,
                            p.Post.User.LastName,
                            p.Post.User.Email,
                            p.Post.User.Name,
                            p.Post.User.ProfileImage,
                            p.Post.User.CreatedAtUtc,
                            p.Post.User.UpdatedAtUtc),
                    p.Post.PostLikes.Any(
                        pl => pl.Id.UserId.Id.ToLower() == currentUserId),
                    p.Post.CreatedAtUtc,
                    p.Post.UpdatedAtUtc),
                p.CreatedAtUtc));

        return aggregate.Project(projection);
    }

    public static IAggregateFluent<PostLikeResponse> ProjectToResponseWithoutPost(
        this IAggregateFluent<PostLike> aggregate,
        CurrentUserQuery currentUser)
    {
        var projection = Builders<PostLike>.Projection.Expression(
            p => new PostLikeResponse(
                p.Id,
                new UserResponse(
                    p.User!.Id,
                    p.User.FirstName,
                    p.User.LastName,
                    p.User.Email,
                    p.User.Name,
                    p.User.ProfileImage,
                    p.User.CreatedAtUtc,
                    p.User.UpdatedAtUtc),
                null,
                p.CreatedAtUtc));

        return aggregate.Project(projection);
    }
}
