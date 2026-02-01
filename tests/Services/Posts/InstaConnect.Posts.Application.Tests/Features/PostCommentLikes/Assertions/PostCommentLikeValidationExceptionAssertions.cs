using InstaConnect.Common.Application.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeValidationExceptionAssertions
{
    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentLikeCommandRequest request,
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
        GetPostCommentLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostCommentLikeByIdQueryRequest, string, GetPostCommentLikeByIdQueryResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddPostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddPostCommentLikeCommandRequest, string, AddPostCommentLikeCommandResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesQueryRequest, string, GetAllPostCommentLikesQueryResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync(
            p => p.CommentId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetPostCommentLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostCommentLikeByIdQueryRequest, string, GetPostCommentLikeByIdQueryResponse>(
            p => p.CommentId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddPostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddPostCommentLikeCommandRequest, string, AddPostCommentLikeCommandResponse>(
            p => p.CommentId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesQueryRequest, string, GetAllPostCommentLikesQueryResponse>(
            p => p.CommentId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync(
            p => p.UserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesForUserQueryRequest, string, GetAllPostCommentLikesForUserQueryResponse>(
            p => p.UserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetPostCommentLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostCommentLikeByIdQueryRequest, string, GetPostCommentLikeByIdQueryResponse>(
            p => p.UserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddPostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddPostCommentLikeCommandRequest, string, AddPostCommentLikeCommandResponse>(
            p => p.UserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetPostCommentLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostCommentLikeByIdQueryRequest, string, GetPostCommentLikeByIdQueryResponse>(
            p => p.CurrentUserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesQueryRequest, string, GetAllPostCommentLikesQueryResponse>(
            p => p.CurrentUserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesForUserQueryRequest, string, GetAllPostCommentLikesForUserQueryResponse>(
            p => p.CurrentUserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserNameAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesQueryRequest, string, GetAllPostCommentLikesQueryResponse>(
            p => p.UserName,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesQueryRequest, int, GetAllPostCommentLikesQueryResponse>(
            p => p.Page,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentLikesForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesForUserQueryRequest, int, GetAllPostCommentLikesForUserQueryResponse>(
            p => p.Page,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesQueryRequest, int, GetAllPostCommentLikesQueryResponse>(
            p => p.PageSize,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentLikesForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesForUserQueryRequest, int, GetAllPostCommentLikesForUserQueryResponse>(
            p => p.PageSize,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesQueryRequest, CommonSortOrder, GetAllPostCommentLikesQueryResponse>(
            p => p.SortOrder,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostCommentLikesForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesForUserQueryRequest, CommonSortOrder, GetAllPostCommentLikesForUserQueryResponse>(
            p => p.SortOrder,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortPropertyAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<PostCommentLikesSortTerm> messageTransformer,
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesQueryRequest, PostCommentLikesSortTerm, GetAllPostCommentLikesQueryResponse>(
            p => p.SortTerm,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortPropertyAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<PostCommentLikesSortTerm> messageTransformer,
        GetAllPostCommentLikesForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesForUserQueryRequest, PostCommentLikesSortTerm, GetAllPostCommentLikesForUserQueryResponse>(
            p => p.SortTerm,
            messageTransformer,
            request,
            cancellationToken);
    }
}
