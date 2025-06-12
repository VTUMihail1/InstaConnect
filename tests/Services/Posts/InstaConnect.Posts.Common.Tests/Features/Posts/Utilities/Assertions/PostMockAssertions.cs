using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

using NSubstitute;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;

public static class PostMockAssertions
{
    public static void ShouldReceiveOneGet(this IPostFactory postFactory, AddPostCommand command)
    {
        postFactory.Received(1).Get(command.CurrentUserId, command.Title, command.Content);
    }

    public static async Task ShouldReceiveOneSaveChangesAsync(this IUnitOfWork unitOfWork, CancellationToken cancellationToken)
    {
        await unitOfWork.Received(1).SaveChangesAsync(cancellationToken);
    }

    public static async Task ShouldReceiveOneGetAllAsync(this IPostReadRepository postReadRepository, GetAllPostsQuery query, CancellationToken cancellationToken)
    {
        await postReadRepository.Received(1).GetAllAsync(PostMatcher.IsPostQueryParameters(query), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(this IPostReadRepository postReadRepository, GetPostByIdQuery query, CancellationToken cancellationToken)
    {
        await postReadRepository.Received(1).GetByIdAsync(query.Id, cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(this IPostWriteRepository postWriteRepository, GetPostByIdQuery query, CancellationToken cancellationToken)
    {
        await postWriteRepository.Received(1).GetByIdAsync(query.Id, cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(this IPostReadRepository postReadRepository, Post post, CancellationToken cancellationToken)
    {
        await postReadRepository.Received(1).GetByIdAsync(post.Id, cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(this IPostWriteRepository postWriteRepository, Post post, CancellationToken cancellationToken)
    {
        await postWriteRepository.Received(1).GetByIdAsync(post.Id, cancellationToken);
    }

    public static void ShouldReceiveOneAdd(this IPostWriteRepository postWriteRepository, Post post, AddPostCommand command)
    {
        postWriteRepository.Received(1).Add(PostMatcher.IsPost(post, command));
    }

    public static void ShouldReceiveOneUpdate(this IPostWriteRepository postWriteRepository, Post post, UpdatePostCommand command)
    {
        postWriteRepository.Received(1).Update(PostMatcher.IsPost(post, command));
    }

    public static void ShouldReceiveOneUpdate(this IPostService postService, Post post, UpdatePostCommand command)
    {
        postService.Received(1).Update(post, command.Title, command.Content);
    }

    public static void ShouldReceiveOneDelete(this IPostWriteRepository postWriteRepository, Post post)
    {
        postWriteRepository.Received(1).Delete(PostMatcher.IsPost(post));
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IInstaConnectSender postWriteRepository,
        GetAllPostsRequest request,
        CancellationToken cancellationToken)
    {
        await postWriteRepository.Received(1).SendAsync(PostMatcher.IsGetAllPostsQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IInstaConnectSender postWriteRepository,
        GetPostByIdRequest request,
        CancellationToken cancellationToken)
    {
        await postWriteRepository.Received(1).SendAsync(PostMatcher.IsGetPostByIdQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IInstaConnectSender postWriteRepository,
        AddPostRequest request,
        CancellationToken cancellationToken)
    {
        await postWriteRepository.Received(1).SendAsync(PostMatcher.IsAddPostCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IInstaConnectSender postWriteRepository,
        UpdatePostRequest request,
        CancellationToken cancellationToken)
    {
        await postWriteRepository.Received(1).SendAsync(PostMatcher.IsUpdatePostCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IInstaConnectSender postWriteRepository,
        DeletePostRequest request,
        CancellationToken cancellationToken)
    {
        await postWriteRepository.Received(1).SendAsync(PostMatcher.IsDeletePostCommand(request), cancellationToken);
    }
}
