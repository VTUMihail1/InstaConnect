namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockSetups
{
    extension(IPostCommentLikeQueryService commentLikeService)
    {
        public void SetupGetAllQuery(
            GetAllPostCommentLikesQueryRequest request,
            PostComment postComment,
            ICollection<PostCommentLike> postCommentLikes,
            CancellationToken cancellationToken)
        {
            commentLikeService
                .GetAllAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQuery(request), cancellationToken)
                .ReturnsResponse(postCommentLikes.ToResponse(postComment, request));
        }

        public void SetupGetAllForUserQuery(
            GetAllPostCommentLikesForUserQueryRequest request,
            User user,
            ICollection<PostCommentLike> postCommentLikes,
            CancellationToken cancellationToken)
        {
            commentLikeService
                .GetAllForUserAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesForUserQuery(request), cancellationToken)
                .ReturnsResponse(postCommentLikes.ToResponse(user, request));
        }

        public void SetupGetByIdQuery(
            GetPostCommentLikeByIdQueryRequest request,
            PostCommentLike postCommentLike,
            CancellationToken cancellationToken)
        {
            commentLikeService
                .GetByIdAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQuery(request), cancellationToken)
                .ReturnsResponse(postCommentLike.ToResponse(request));
        }
    }

    extension(IPostCommentLikeCommandService commentLikeService)
    {
        public void SetupAddCommand(
            AddPostCommentLikeCommandRequest request,
            PostCommentLike postCommentLike,
            CancellationToken cancellationToken)
        {
            commentLikeService
                .AddAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommand(request), cancellationToken)
                .ReturnsResponse(postCommentLike.ToResponse(request));
        }
    }
}
