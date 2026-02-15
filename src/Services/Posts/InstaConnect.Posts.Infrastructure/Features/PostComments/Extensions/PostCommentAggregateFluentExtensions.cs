using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

internal static class PostCommentAggregateFluentExtensions
{
    public static IAggregateFluent<PostComment> Match(
        this IAggregateFluent<PostComment> aggregate,
        PostCommentsFilterQuery filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<PostComment> Match(
        this IAggregateFluent<PostComment> aggregate,
        PostCommentsForUserFilterQuery filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<PostComment> Match(
        this IAggregateFluent<PostComment> aggregate,
        PostCommentId filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<PostCommentResponse> ProjectToFullResponse(
        this IAggregateFluent<PostComment> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<PostComment>.Projection.Expression(
            p => new PostCommentResponse(
                p.Id,
                p.UserId,
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
                p.PostCommentLikes.Any(
                            pl => pl.Id.UserId.Id.ToLower() == currentUserId),
                p.CreatedAtUtc,
                p.UpdatedAtUtc));

        return aggregate.Project(projection);
    }

    public static IAggregateFluent<PostCommentResponse> ProjectToResponseWithoutUser(
        this IAggregateFluent<PostComment> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<PostComment>.Projection.Expression(
            p => new PostCommentResponse(
                p.Id,
                p.UserId,
                p.Content,
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
                p.PostCommentLikes.Any(
                            pl => pl.Id.UserId.Id.ToLower() == currentUserId),
                p.CreatedAtUtc,
                p.UpdatedAtUtc));

        return aggregate.Project(projection);
    }

    public static IAggregateFluent<PostCommentResponse> ProjectToResponseWithoutPost(
        this IAggregateFluent<PostComment> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<PostComment>.Projection.Expression(
            p => new PostCommentResponse(
                p.Id,
                p.UserId,
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
                null,
                p.PostCommentLikes.Any(
                            pl => pl.Id.UserId.Id.ToLower() == currentUserId),
                p.CreatedAtUtc,
                p.UpdatedAtUtc));

        return aggregate.Project(projection);
    }
}
