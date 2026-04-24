using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockSetups
{
    extension(IApplicationSender sender)
    {
        public void SetupGetAllQueryRequest(
        GetAllPostCommentLikesApiRequest request,
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        CancellationToken cancellationToken)
        {
            sender
                .SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQueryRequest(request), cancellationToken)
                .ReturnsResponse(postCommentLikes.ToResponse(postComment, request));
        }

        public void SetupGetAllForUserQueryRequest(
            GetAllPostCommentLikesForUserApiRequest request,
            User user,
            ICollection<PostCommentLike> postCommentLikes,
            CancellationToken cancellationToken)
        {
            sender
                .SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesForUserQueryRequest(request), cancellationToken)
                .ReturnsResponse(postCommentLikes.ToResponse(user, request));
        }

        public void SetupGetByIdQueryRequest(
            GetPostCommentLikeByIdApiRequest request,
            PostCommentLike postCommentLike,
            CancellationToken cancellationToken)
        {
            sender
                .SendAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQueryRequest(request), cancellationToken)
                .ReturnsResponse(postCommentLike.ToResponse(request));
        }

        public void SetupAddCommandRequest(
            AddPostCommentLikeApiRequest request,
            PostCommentLike postCommentLike,
            CancellationToken cancellationToken)
        {
            sender
                .SendAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommandRequest(request), cancellationToken)
                .ReturnsResponse(postCommentLike.ToResponse(request));
        }
    }
}
