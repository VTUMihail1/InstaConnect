using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.Features.PostLikes.Models;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
public static class PostLikeMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostLikesApiRequest request,
        PostLike postLike,
        User user,
        CancellationToken cancellationToken)
    {

        var postLikeQueryResponse = new PostLikeQueryResponse(
            postLike.Id,
            new(
                user.Id,
                user.Name,
                user.ProfileImage));
        var postLikeQueryResponses = new List<PostLikeQueryResponse>() { postLikeQueryResponse };

        var response = new GetAllPostLikesQueryResponse(
            postLikeQueryResponses,
            request.Pagination.Page,
            request.Pagination.PageSize,
            postLikeQueryResponses.Count,
            false,
            false);

        applicationSender
            .SendAsync(PostLikeMatcher.IsGetAllPostLikesQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostLikeByIdApiRequest request,
        PostLike postLike,
        User user,
        CancellationToken cancellationToken)
    {
        var response = new GetPostLikeByIdQueryResponse(
            new(
                postLike.Id,
                new(
                    user.Id,
                    user.Name,
                    user.ProfileImage)));

        applicationSender
            .SendAsync(PostLikeMatcher.IsGetPostLikeByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender applicationSender,
        AddPostLikeApiRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var response = new AddPostLikeCommandResponse(postLike.Id, postLike.UserId, postLike.CreatedAt, postLike.UpdatedAt);

        applicationSender
            .SendAsync(PostLikeMatcher.IsAddPostLikeCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetAllQuery(
        this IPostLikeService postLikeService,
        GetAllPostLikesQueryRequest request,
        PostLike postLike,
        User user,
        CancellationToken cancellationToken)
    {
        var postLikes = new List<PostLike>() { postLike };
        var response = new PostLikeCollection(
            postLikes,
            request.Pagination.Page,
            request.Pagination.PageSize,
            postLikes.Count,
            false,
            false);

        postLikeService
            .GetAllAsync(PostLikeMatcher.IsGetAllPostLikesQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IPostLikeService postLikeService,
        GetPostLikeByIdQueryRequest request,
        PostLike postLike,
        User user,
        CancellationToken cancellationToken)
    {
        postLikeService
            .GetByIdAsync(PostLikeMatcher.IsGetPostLikeByIdQuery(request), cancellationToken)
            .ReturnsResponse(postLike);
    }

    public static void SetupAddCommand(
        this IPostLikeService postLikeService,
        AddPostLikeCommandRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        postLikeService
            .AddAsync(PostLikeMatcher.IsAddPostLikeCommand(request), cancellationToken)
            .ReturnsResponse(postLike);
    }
}
