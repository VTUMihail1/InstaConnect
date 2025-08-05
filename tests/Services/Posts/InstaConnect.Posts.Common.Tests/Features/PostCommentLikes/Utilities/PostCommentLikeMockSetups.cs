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
    public static void SetupGetAllQuery(
        this IApplicationSender applicationSender,
        GetAllPostCommentLikesApiRequest request,
        PostCommentLike postCommentLike,
        User user,
        CancellationToken cancellationToken)
    {

        var postCommentLikeQueryResponse = new PostCommentLikeQueryResponse(
            postCommentLike.Id,
            postCommentLike.CommentId,
            postCommentLike.CommentLikeId,
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
            .SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IApplicationSender applicationSender,
        GetPostCommentLikeByIdApiRequest request,
        PostCommentLike postCommentLike,
        User user,
        CancellationToken cancellationToken)
    {
        var response = new GetPostCommentLikeByIdQueryResponse(
            new(postCommentLike.Id,
                postCommentLike.CommentId,
                postCommentLike.CommentLikeId,
                new(
                    user.Id,
                    user.Name,
                    user.ProfileImage)));

        applicationSender
            .SendAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommand(
        this IApplicationSender applicationSender,
        AddPostCommentLikeApiRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var response = new AddPostCommentLikeCommandResponse(postCommentLike.Id, postCommentLike.CommentId, postCommentLike.CommentLikeId, postCommentLike.CreatedAt, postCommentLike.UpdatedAt);

        applicationSender
            .SendAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommand(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetAllRequest(
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
            .GetAllAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdRequest(
        this IPostCommentLikeService postCommentLikeService,
        GetPostCommentLikeByIdQueryRequest request,
        PostCommentLike postCommentLike,
        User user,
        CancellationToken cancellationToken)
    {
        postCommentLikeService
            .GetByIdAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdRequest(request), cancellationToken)
            .ReturnsResponse(postCommentLike);
    }

    public static void SetupAddRequest(
        this IPostCommentLikeService postCommentLikeService,
        AddPostCommentLikeCommandRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        postCommentLikeService
            .AddAsync(PostCommentLikeMatcher.IsAddPostCommentLikeRequest(request), cancellationToken)
            .ReturnsResponse(postCommentLike);
    }
}
