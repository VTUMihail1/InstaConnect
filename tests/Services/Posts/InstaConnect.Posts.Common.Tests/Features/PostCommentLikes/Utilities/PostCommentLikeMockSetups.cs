using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Models;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostCommentLikesApiRequest request,
        PostCommentLike postCommentLike,
        User user,
        CancellationToken cancellationToken)
    {

        var postCommentLikeQueryResponse = new PostCommentLikeQueryResponse(
            postCommentLike.Id,
            postCommentLike.CommentId,
            new(
                user.Id,
                user.Name,
                user.ProfileImage));
        var postCommentLikeQueryResponses = new List<PostCommentLikeQueryResponse>() { postCommentLikeQueryResponse };

        var response = new GetAllPostCommentLikesQueryResponse(
            postCommentLikeQueryResponses,
            request.Pagination.Page,
            request.Pagination.PageSize,
            postCommentLikeQueryResponses.Count,
            false,
            false);

        applicationSender
            .SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostCommentLikeByIdApiRequest request,
        PostCommentLike postCommentLike,
        User user,
        CancellationToken cancellationToken)
    {
        var response = new GetPostCommentLikeByIdQueryResponse(
            new(postCommentLike.Id,
                postCommentLike.CommentId,
                new(
                    user.Id,
                    user.Name,
                    user.ProfileImage)));

        applicationSender
            .SendAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender applicationSender,
        AddPostCommentLikeApiRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var response = new AddPostCommentLikeCommandResponse(postCommentLike.Id, postCommentLike.CommentId, postCommentLike.UserId, postCommentLike.CreatedAt, postCommentLike.UpdatedAt);

        applicationSender
            .SendAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetAllQuery(
        this IPostCommentLikeService postCommentLikeService,
        GetAllPostCommentLikesQueryRequest request,
        PostCommentLike postCommentLike,
        User user,
        CancellationToken cancellationToken)
    {
        var postCommentLikes = new List<PostCommentLike>() { postCommentLike };
        var response = new PostCommentLikeCollection(
            postCommentLikes,
            request.Pagination.Page,
            request.Pagination.PageSize,
            postCommentLikes.Count,
            false,
            false);

        postCommentLikeService
            .GetAllAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IPostCommentLikeService postCommentLikeService,
        GetPostCommentLikeByIdQueryRequest request,
        PostCommentLike postCommentLike,
        User user,
        CancellationToken cancellationToken)
    {
        postCommentLikeService
            .GetByIdAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQuery(request), cancellationToken)
            .ReturnsResponse(postCommentLike);
    }

    public static void SetupAddCommand(
        this IPostCommentLikeService postCommentLikeService,
        AddPostCommentLikeCommandRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        postCommentLikeService
            .AddAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommand(request), cancellationToken)
            .ReturnsResponse(postCommentLike);
    }
}
