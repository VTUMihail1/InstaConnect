using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
public static class PostMockSetups
{
    public static void SetupGet(
        this IPostFactory postFactory,
        User user,
        Post addPost)
    {
        postFactory.Create(user.Id, addPost.Title, addPost.Content).ReturnsResponse(addPost);
    }

    public static void SetupUpdate(
        this IPostService postService,
        Post post,
        Post updatePost)
    {
        postService.WhenDo(x => x.Update(post, updatePost.Title, updatePost.Content), () => post = updatePost);
    }

    public static void SetupGetByIdAsync(this IPostWriteRepository postWriteRepository, Post post, CancellationToken cancellationToken)
    {
        postWriteRepository.GetByIdAsync(post.Id, cancellationToken).ReturnsResponse(post);
    }

    public static void SetupGetByIdAsync(this IPostReadRepository postReadRepository, Post post, CancellationToken cancellationToken)
    {
        postReadRepository.GetByIdAsync(post.Id, cancellationToken).ReturnsResponse(post);
    }

    public static void SetupGetAllAsync(
        this IPostReadRepository postReadRepository,
        GetAllPostsQuery query,
        PostCollection response,
        CancellationToken cancellationToken)
    {
        postReadRepository
            .GetAllAsync(PostMatcher.IsPostQueryParameters(query), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetAllQuery(
        this IApplicationSender applicationSender,
        GetAllPostsApiRequest request,
        GetAllPostsQueryResponse response,
        CancellationToken cancellationToken)
    {
        applicationSender
            .SendAsync(PostMatcher.IsGetAllPostsQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IApplicationSender applicationSender,
        GetPostByIdApiRequest request,
        GetPostByIdQueryResponse response,
        CancellationToken cancellationToken)
    {
        applicationSender
            .SendAsync(PostMatcher.IsGetPostByIdQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommand(
        this IApplicationSender applicationSender,
        AddPostApiRequest request,
        AddPostCommandResponse response,
        CancellationToken cancellationToken)
    {
        applicationSender
            .SendAsync(PostMatcher.IsAddPostCommand(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupUpdateCommand(
        this IApplicationSender applicationSender,
        UpdatePostApiRequest request,
        UpdatePostCommandResponse response,
        CancellationToken cancellationToken)
    {
        applicationSender
            .SendAsync(PostMatcher.IsUpdatePostCommand(request), cancellationToken)
            .ReturnsResponse(response);
    }
}
