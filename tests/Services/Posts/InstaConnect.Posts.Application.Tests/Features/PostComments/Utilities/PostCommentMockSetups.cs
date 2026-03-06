namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentMockSetups
{
    extension(IPostCommentQueryService commentService)
    {
        public void SetupGetAllQuery(
        GetAllPostCommentsQueryRequest request,
        Post post,
        ICollection<PostComment> postComments,
        CancellationToken cancellationToken)
        {
            commentService
                .GetAllAsync(PostCommentMatcher.IsGetAllPostCommentsQuery(request), cancellationToken)
                .ReturnsResponse(postComments.ToResponse(post, request));
        }

        public void SetupGetAllForUserQuery(
            GetAllPostCommentsForUserQueryRequest request,
            User user,
            ICollection<PostComment> postComments,
            CancellationToken cancellationToken)
        {
            commentService
                .GetAllForUserAsync(PostCommentMatcher.IsGetAllPostCommentsForUserQuery(request), cancellationToken)
                .ReturnsResponse(postComments.ToResponse(user, request));
        }

        public void SetupGetByIdQuery(
            GetPostCommentByIdQueryRequest request,
            PostComment postComment,
            CancellationToken cancellationToken)
        {
            commentService
                .GetByIdAsync(PostCommentMatcher.IsGetPostCommentByIdQuery(request), cancellationToken)
                .ReturnsResponse(postComment.ToResponse(request));
        }
    }

    extension(IPostCommentCommandService commentService)
    {
        public void SetupAddCommand(
        AddPostCommentCommandRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
        {
            commentService
                .AddAsync(PostCommentMatcher.IsAddPostCommentCommand(request), cancellationToken)
                .ReturnsResponse(postComment.ToResponse(request));
        }

        public void SetupUpdateCommand(
            UpdatePostCommentCommandRequest request,
            PostComment postComment,
            CancellationToken cancellationToken)
        {
            commentService
                .UpdateAsync(PostCommentMatcher.IsUpdatePostCommentCommand(request), cancellationToken)
                .ReturnsResponse(postComment.ToResponse(request));
        }
    }
}
