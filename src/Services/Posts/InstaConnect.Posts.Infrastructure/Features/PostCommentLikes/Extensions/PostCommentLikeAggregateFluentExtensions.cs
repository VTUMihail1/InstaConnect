using System.Linq.Expressions;
using System.Runtime.CompilerServices;

using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

using MongoDB.Bson;
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

    public static IAggregateFluent<PostCommentLikeResponse> ProjectToFullResponse(
        this IAggregateFluent<PostCommentLike> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<PostCommentLike>.Projection
            .Expression(
            p => new PostCommentLikeResponse(
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
                new PostCommentResponse(
                    p.PostComment!.Id,
                    p.PostComment.UserId,
                    p.PostComment.Content,
                       new UserResponse(
                            p.PostComment.User!.Id,
                            p.PostComment.User.FirstName,
                            p.PostComment.User.LastName,
                            p.PostComment.User.Email,
                            p.PostComment.User.Name,
                            p.PostComment.User.ProfileImage,
                            p.PostComment.User.CreatedAtUtc,
                            p.PostComment.User.UpdatedAtUtc),
                        new PostResponse(
                            p.PostComment.Post!.Id,
                            p.PostComment.Post.UserId,
                            p.PostComment.Post.Title,
                            p.PostComment.Post.Content,
                                new UserResponse(
                                    p.PostComment.Post.User!.Id,
                                    p.PostComment.Post.User.FirstName,
                                    p.PostComment.Post.User.LastName,
                                    p.PostComment.Post.User.Email,
                                    p.PostComment.Post.User.Name,
                                    p.PostComment.Post.User.ProfileImage,
                                    p.PostComment.Post.User.CreatedAtUtc,
                                    p.PostComment.Post.User.UpdatedAtUtc),
                            p.PostComment.Post.PostLikes != null && p.PostComment.Post.PostLikes.Any(
                                pl => pl.Id.UserId.Id.ToLower() == currentUserId),
                            p.PostComment.Post.CreatedAtUtc,
                            p.PostComment.Post.UpdatedAtUtc),
                    p.PostComment.PostCommentLikes != null && p.PostComment.PostCommentLikes.Any(
                        pl => pl.Id.UserId.Id.ToLower() == currentUserId),
                    p.PostComment.CreatedAtUtc,
                    p.PostComment.UpdatedAtUtc),
                p.CreatedAtUtc));

        return aggregate.Project(projection);
    }

    public static IAggregateFluent<PostCommentLikeResponse> ProjectToResponseWithoutUser(
        this IAggregateFluent<PostCommentLike> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<PostCommentLike>.Projection
            .Expression(
            p => new PostCommentLikeResponse(
                p.Id,
                null,
                new PostCommentResponse(
                    p.PostComment!.Id,
                    p.PostComment.UserId,
                    p.PostComment.Content,
                       new UserResponse(
                            p.PostComment.User!.Id,
                            p.PostComment.User.FirstName,
                            p.PostComment.User.LastName,
                            p.PostComment.User.Email,
                            p.PostComment.User.Name,
                            p.PostComment.User.ProfileImage,
                            p.PostComment.User.CreatedAtUtc,
                            p.PostComment.User.UpdatedAtUtc),
                        new PostResponse(
                            p.PostComment.Post!.Id,
                            p.PostComment.Post.UserId,
                            p.PostComment.Post.Title,
                            p.PostComment.Post.Content,
                                new UserResponse(
                                    p.PostComment.Post.User!.Id,
                                    p.PostComment.Post.User.FirstName,
                                    p.PostComment.Post.User.LastName,
                                    p.PostComment.Post.User.Email,
                                    p.PostComment.Post.User.Name,
                                    p.PostComment.Post.User.ProfileImage,
                                    p.PostComment.Post.User.CreatedAtUtc,
                                    p.PostComment.Post.User.UpdatedAtUtc),
                            p.PostComment.Post.PostLikes != null && p.PostComment.Post.PostLikes.Any(
                                pl => pl.Id.UserId.Id.ToLower() == currentUserId),
                            p.PostComment.Post.CreatedAtUtc,
                            p.PostComment.Post.UpdatedAtUtc),
                    p.PostComment.PostCommentLikes != null && p.PostComment.PostCommentLikes.Any(
                        pl => pl.Id.UserId.Id.ToLower() == currentUserId),
                    p.PostComment.CreatedAtUtc,
                    p.PostComment.UpdatedAtUtc),
                p.CreatedAtUtc));

        return aggregate.Project(projection);
    }

    public static IAggregateFluent<PostCommentLikeResponse> ProjectToResponseWithoutPostComment(
        this IAggregateFluent<PostCommentLike> aggregate,
        CurrentUserQuery currentUser)
    {
        var projection = Builders<PostCommentLike>.Projection
            .Expression(
            p => new PostCommentLikeResponse(
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
