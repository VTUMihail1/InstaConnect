using InstaConnect.Common.Application.Abstractions;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Delete;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Update;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

using NSubstitute;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;

public static class PostCommentMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetAllPostCommentsApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostCommentMatcher.IsGetAllPostCommentsQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetPostCommentByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostCommentMatcher.IsGetPostCommentByIdQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        AddPostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostCommentMatcher.IsAddPostCommentCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        UpdatePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostCommentMatcher.IsUpdatePostCommentCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        DeletePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(PostCommentMatcher.IsDeletePostCommentCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetAllAsync(
        this IPostCommentService postCommentService,
        GetAllPostCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.Received(1).GetAllAsync(PostCommentMatcher.IsGetAllPostCommentsQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(
        this IPostCommentService postCommentService,
        GetPostCommentByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.Received(1).GetByIdAsync(PostCommentMatcher.IsGetPostCommentByIdQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneAddAsync(
        this IPostCommentService postCommentService,
        AddPostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.Received(1).AddAsync(PostCommentMatcher.IsAddPostCommentCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneUpdateAsync(
        this IPostCommentService postCommentService,
        UpdatePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.Received(1).UpdateAsync(PostCommentMatcher.IsUpdatePostCommentCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IPostCommentService postCommentService,
        DeletePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.Received(1).DeleteAsync(PostCommentMatcher.IsDeletePostCommentCommand(request), cancellationToken);
    }
}
