using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

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

    public static IAggregateFluent<PostCommentResponse> ProjectToResponse(
        this IAggregateFluent<PostComment> aggregate,
        CurrentUserQuery currentUser)
    {
        var projection = Builders<PostComment>.Projection.Expression(
            p => new PostCommentResponse(
                p.Id,
                p.UserId,
                p.Content,
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
                p.PostCommentLikes.Any(
                            pl => pl.Id.UserId.Id.ToLower() ==
                                  currentUser.Id.Id.ToLower()),
                p.CreatedAtUtc,
                p.UpdatedAtUtc));

        return aggregate.Project(projection);
    }
}
