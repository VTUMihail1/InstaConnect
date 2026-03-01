using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostValidationExceptionAssertions
{
    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdatePostCommandRequest, string, UpdatePostCommandResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        DeletePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetPostByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostByIdQueryRequest, string, GetPostByIdQueryResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForContentAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddPostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddPostCommandRequest, string, AddPostCommandResponse>(
            p => p.Content,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForContentAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdatePostCommandRequest, string, UpdatePostCommandResponse>(
            p => p.Content,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForTitleAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsForUserQueryRequest, string, GetAllPostsForUserQueryResponse>(
            p => p.Title,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForTitleAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddPostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddPostCommandRequest, string, AddPostCommandResponse>(
            p => p.Title,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForTitleAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdatePostCommandRequest, string, UpdatePostCommandResponse>(
            p => p.Title,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForTitleAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsQueryRequest, string, GetAllPostsQueryResponse>(
            p => p.Title,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsForUserQueryRequest, string, GetAllPostsForUserQueryResponse>(
            p => p.UserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddPostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddPostCommandRequest, string, AddPostCommandResponse>(
            p => p.UserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdatePostCommandRequest, string, UpdatePostCommandResponse>(
            p => p.UserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        DeletePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync(
            p => p.UserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetPostByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostByIdQueryRequest, string, GetPostByIdQueryResponse>(
            p => p.CurrentUserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsQueryRequest, string, GetAllPostsQueryResponse>(
            p => p.CurrentUserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsForUserQueryRequest, string, GetAllPostsForUserQueryResponse>(
            p => p.CurrentUserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserNameAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsQueryRequest, string, GetAllPostsQueryResponse>(
            p => p.UserName,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsQueryRequest, int, GetAllPostsQueryResponse>(
            p => p.Page,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsForUserQueryRequest, int, GetAllPostsForUserQueryResponse>(
            p => p.Page,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsQueryRequest, int, GetAllPostsQueryResponse>(
            p => p.PageSize,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsForUserQueryRequest, int, GetAllPostsForUserQueryResponse>(
            p => p.PageSize,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsQueryRequest, CommonSortOrder, GetAllPostsQueryResponse>(
            p => p.SortOrder,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsForUserQueryRequest, CommonSortOrder, GetAllPostsForUserQueryResponse>(
            p => p.SortOrder,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<PostsSortTerm> messageTransformer,
        GetAllPostsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsQueryRequest, PostsSortTerm, GetAllPostsQueryResponse>(
            p => p.SortTerm,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<PostsForUserSortTerm> messageTransformer,
        GetAllPostsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsForUserQueryRequest, PostsForUserSortTerm, GetAllPostsForUserQueryResponse>(
            p => p.SortTerm,
            messageTransformer,
            request,
            cancellationToken);
    }
}
