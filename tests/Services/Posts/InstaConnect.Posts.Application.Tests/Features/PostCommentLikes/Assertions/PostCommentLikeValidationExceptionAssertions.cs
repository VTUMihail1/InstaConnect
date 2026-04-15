using InstaConnect.Common.Application.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeValidationExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForUserNameAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
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

        public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
            IEnumMessageTransformer<PostCommentLikesForUserSortTerm> messageTransformer,
            GetAllPostCommentLikesForUserQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostCommentLikesForUserQueryRequest, PostCommentLikesForUserSortTerm, GetAllPostCommentLikesForUserQueryResponse>(
                p => p.SortTerm,
                messageTransformer,
                request,
                cancellationToken);
        }
    }
}
