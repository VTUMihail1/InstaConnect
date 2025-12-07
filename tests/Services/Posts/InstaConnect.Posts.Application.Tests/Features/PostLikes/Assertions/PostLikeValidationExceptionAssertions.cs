using InstaConnect.Common.Application.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeValidationExceptionAssertions
{
    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        DeletePostLikeCommandRequest request,
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
        GetPostLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostLikeByIdQueryRequest, string, GetPostLikeByIdQueryResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddPostLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddPostLikeCommandRequest, string, AddPostLikeCommandResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesQueryRequest, string, GetAllPostLikesQueryResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetPostLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostLikeByIdQueryRequest, string, GetPostLikeByIdQueryResponse>(
            p => p.UserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddPostLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddPostLikeCommandRequest, string, AddPostLikeCommandResponse>(
            p => p.UserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        DeletePostLikeCommandRequest request,
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
        GetAllPostLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesQueryRequest, string, GetAllPostLikesQueryResponse>(
            p => p.UserName,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesQueryRequest, int, GetAllPostLikesQueryResponse>(
            p => p.Page,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesQueryRequest, int, GetAllPostLikesQueryResponse>(
            p => p.PageSize,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesQueryRequest, CommonSortOrder, GetAllPostLikesQueryResponse>(
            p => p.SortOrder,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortPropertyAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<PostLikeSortProperty> messageTransformer,
        GetAllPostLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesQueryRequest, PostLikeSortProperty, GetAllPostLikesQueryResponse>(
            p => p.SortProperty,
            messageTransformer,
            request,
            cancellationToken);
    }
}
