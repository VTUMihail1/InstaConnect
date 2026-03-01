using InstaConnect.Common.Application.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentValidationExceptionAssertions
{
    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddPostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddPostCommentCommandRequest, string, AddPostCommentCommandResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdatePostCommentCommandRequest, string, UpdatePostCommentCommandResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentCommandRequest request,
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
        GetPostCommentByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostCommentByIdQueryRequest, string, GetPostCommentByIdQueryResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentsQueryRequest, string, GetAllPostCommentsQueryResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdatePostCommentCommandRequest, string, UpdatePostCommentCommandResponse>(
            p => p.CommentId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentCommandRequest request,
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
        GetPostCommentByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostCommentByIdQueryRequest, string, GetPostCommentByIdQueryResponse>(
            p => p.CommentId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForContentAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddPostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddPostCommentCommandRequest, string, AddPostCommentCommandResponse>(
            p => p.Content,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForContentAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdatePostCommentCommandRequest, string, UpdatePostCommentCommandResponse>(
            p => p.Content,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddPostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddPostCommentCommandRequest, string, AddPostCommentCommandResponse>(
            p => p.UserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdatePostCommentCommandRequest, string, UpdatePostCommentCommandResponse>(
            p => p.UserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentCommandRequest request,
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
        GetAllPostCommentsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentsForUserQueryRequest, string, GetAllPostCommentsForUserQueryResponse>(
            p => p.UserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetPostCommentByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostCommentByIdQueryRequest, string, GetPostCommentByIdQueryResponse>(
            p => p.CurrentUserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentsQueryRequest, string, GetAllPostCommentsQueryResponse>(
            p => p.CurrentUserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentsForUserQueryRequest, string, GetAllPostCommentsForUserQueryResponse>(
            p => p.CurrentUserId,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUserNameAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentsQueryRequest, string, GetAllPostCommentsQueryResponse>(
            p => p.UserName,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentsQueryRequest, int, GetAllPostCommentsQueryResponse>(
            p => p.Page,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentsForUserQueryRequest, int, GetAllPostCommentsForUserQueryResponse>(
            p => p.Page,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentsQueryRequest, int, GetAllPostCommentsQueryResponse>(
            p => p.PageSize,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
        this IApplicationSender sender,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentsForUserQueryRequest, int, GetAllPostCommentsForUserQueryResponse>(
            p => p.PageSize,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentsQueryRequest, CommonSortOrder, GetAllPostCommentsQueryResponse>(
            p => p.SortOrder,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostCommentsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentsForUserQueryRequest, CommonSortOrder, GetAllPostCommentsForUserQueryResponse>(
            p => p.SortOrder,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<PostCommentsSortTerm> messageTransformer,
        GetAllPostCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentsQueryRequest, PostCommentsSortTerm, GetAllPostCommentsQueryResponse>(
            p => p.SortTerm,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
        this IApplicationSender sender,
        IEnumMessageTransformer<PostCommentsForUserSortTerm> messageTransformer,
        GetAllPostCommentsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentsForUserQueryRequest, PostCommentsForUserSortTerm, GetAllPostCommentsForUserQueryResponse>(
            p => p.SortTerm,
            messageTransformer,
            request,
            cancellationToken);
    }
}
