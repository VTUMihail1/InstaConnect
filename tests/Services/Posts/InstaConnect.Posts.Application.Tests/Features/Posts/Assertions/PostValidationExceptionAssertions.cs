using InstaConnect.Common.Application.Abstractions;

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

    public static async Task ShouldThrowInvalidValidationExceptionForSortPropertyAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<PostSortProperty> messageTransformer,
        GetAllPostsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostsQueryRequest, PostSortProperty, GetAllPostsQueryResponse>(
            p => p.SortProperty,
            messageTransformer,
            request,
            cancellationToken);
    }
}
