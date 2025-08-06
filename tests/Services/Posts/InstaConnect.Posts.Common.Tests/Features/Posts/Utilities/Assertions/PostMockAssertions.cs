using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

using NSubstitute;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;

public static class PostMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetAllPostsApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostMatcher.IsGetAllPostsQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetPostByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostMatcher.IsGetPostByIdQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        AddPostApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostMatcher.IsAddPostCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        UpdatePostApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostMatcher.IsUpdatePostCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        DeletePostApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostMatcher.IsDeletePostCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetAllAsync(
        this IPostService postService,
        GetAllPostsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postService.Received(1).GetAllAsync(PostMatcher.IsGetAllPostsQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(
        this IPostService postService,
        GetPostByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postService.Received(1).GetByIdAsync(PostMatcher.IsGetPostByIdQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneAddAsync(
        this IPostService postService,
        AddPostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postService.Received(1).AddAsync(PostMatcher.IsAddPostCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneUpdateAsync(
        this IPostService postService,
        UpdatePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postService.Received(1).UpdateAsync(PostMatcher.IsUpdatePostCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IPostService postService,
        DeletePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postService.Received(1).DeleteAsync(PostMatcher.IsDeletePostCommand(request), cancellationToken);
    }
}
