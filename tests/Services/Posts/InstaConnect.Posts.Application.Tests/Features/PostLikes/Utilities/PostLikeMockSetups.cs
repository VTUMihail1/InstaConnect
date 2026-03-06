namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockSetups
{
    extension(IPostLikeQueryService likeService)
    {
        public void SetupGetAllQuery(
        GetAllPostLikesQueryRequest request,
        Post post,
        ICollection<PostLike> postLikes,
        CancellationToken cancellationToken)
        {
            likeService
                .GetAllAsync(PostLikeMatcher.IsGetAllPostLikesQuery(request), cancellationToken)
                .ReturnsResponse(postLikes.ToResponse(post, request));
        }

        public void SetupGetAllForUserQuery(
            GetAllPostLikesForUserQueryRequest request,
            User user,
            ICollection<PostLike> postLikes,
            CancellationToken cancellationToken)
        {
            likeService
                .GetAllForUserAsync(PostLikeMatcher.IsGetAllPostLikesForUserQuery(request), cancellationToken)
                .ReturnsResponse(postLikes.ToResponse(user, request));
        }

        public void SetupGetByIdQuery(
            GetPostLikeByIdQueryRequest request,
            PostLike postLike,
            CancellationToken cancellationToken)
        {
            likeService
                .GetByIdAsync(PostLikeMatcher.IsGetPostLikeByIdQuery(request), cancellationToken)
                .ReturnsResponse(postLike.ToResponse(request));
        }
    }

    extension(IPostLikeCommandService likeService)
    {
        public void SetupAddCommand(
        AddPostLikeCommandRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
        {
            likeService
                .AddAsync(PostLikeMatcher.IsAddPostLikeCommand(request), cancellationToken)
                .ReturnsResponse(postLike.ToResponse(request));
        }
    }
}
