using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentValidationExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForContentAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForContentAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForUserNameAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
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
}
