using System.Linq.Expressions;

using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

internal static class PostCommentLikeAggregateFluentExtensions
{
    public static IAggregateFluent<PostCommentLike> Match(
        this IAggregateFluent<PostCommentLike> aggregate,
        PostCommentLikesFilterQuery filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<PostCommentLike> Match(
        this IAggregateFluent<PostCommentLike> aggregate,
        PostCommentLikesForUserFilterQuery filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<PostCommentLike> Match(
        this IAggregateFluent<PostCommentLike> aggregate,
        PostCommentLikeId filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<PostCommentLikeResponse> ProjectToResponse(
        this IAggregateFluent<PostCommentLike> aggregate,
        CurrentUserQuery currentUser)
    {
        var projection = Builders<PostCommentLike>.Projection.Expression(
            p => new PostCommentLikeResponse(
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
                p.PostComment == null
                    ? null
                    : new PostCommentResponse(
                        p.PostComment.Id,
                        p.PostComment.UserId,
                        p.PostComment.Content,
                        p.PostComment.User == null
                            ? null
                            : new UserResponse(
                                p.PostComment.User!.Id,
                                p.PostComment.User.FirstName,
                                p.PostComment.User.LastName,
                                p.PostComment.User.Email,
                                p.PostComment.User.Name,
                                p.PostComment.User.ProfileImage,
                                p.PostComment.User.CreatedAtUtc,
                                p.PostComment.User.UpdatedAtUtc),
                        p.PostComment.Post == null
                            ? null
                            : new PostResponse(
                                p.PostComment.Post.Id,
                                p.PostComment.Post.UserId,
                                p.PostComment.Post.Title,
                                p.PostComment.Post.Content,
                                p.PostComment.Post.User == null
                                    ? null
                                    : new UserResponse(
                                        p.PostComment.Post.User!.Id,
                                        p.PostComment.Post.User.FirstName,
                                        p.PostComment.Post.User.LastName,
                                        p.PostComment.Post.User.Email,
                                        p.PostComment.Post.User.Name,
                                        p.PostComment.Post.User.ProfileImage,
                                        p.PostComment.Post.User.CreatedAtUtc,
                                        p.PostComment.Post.User.UpdatedAtUtc),
                                p.PostComment.Post.PostLikes.Any(
                                    pl => pl.Id.UserId.Id.ToLower() ==
                                          currentUser.Id.Id.ToLower()),
                                p.PostComment.Post.CreatedAtUtc,
                                p.PostComment.Post.UpdatedAtUtc),
                        p.PostComment.PostCommentLikes.Any(
                            pl => pl.Id.UserId.Id.ToLower() ==
                                  currentUser.Id.Id.ToLower()),
                        p.PostComment.CreatedAtUtc,
                        p.PostComment.UpdatedAtUtc),
                p.CreatedAtUtc));

        return aggregate.Project(projection);
    }
}
