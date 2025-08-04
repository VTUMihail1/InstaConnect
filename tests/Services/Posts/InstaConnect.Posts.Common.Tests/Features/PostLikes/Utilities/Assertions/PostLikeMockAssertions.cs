using InstaConnect.Common.Application.Abstractions;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

using NSubstitute;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;

public static class PostLikeMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetAllPostLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostLikeMatcher.IsGetAllPostLikesQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetPostLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostLikeMatcher.IsGetPostLikeByIdQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        AddPostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostLikeMatcher.IsAddPostLikeCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        DeletePostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostLikeMatcher.IsDeletePostLikeCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetAllAsync(
        this IPostLikeService postLikeService,
        GetAllPostLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postLikeService.Received(1).GetAllAsync(PostLikeMatcher.IsGetAllPostLikesRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(
        this IPostLikeService postLikeService,
        GetPostLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postLikeService.Received(1).GetByIdAsync(PostLikeMatcher.IsGetPostLikeByIdRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneAddAsync(
        this IPostLikeService postLikeService,
        AddPostLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postLikeService.Received(1).AddAsync(PostLikeMatcher.IsAddPostLikeRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IPostLikeService postLikeService,
        DeletePostLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postLikeService.Received(1).DeleteAsync(PostLikeMatcher.IsDeletePostLikeRequest(request), cancellationToken);
    }
}
