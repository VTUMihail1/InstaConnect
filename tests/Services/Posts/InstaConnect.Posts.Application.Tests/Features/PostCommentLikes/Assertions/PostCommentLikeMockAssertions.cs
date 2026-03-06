using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
    extension(IPostCommentLikeQueryService postCommentLikeService)
    {
        public async Task ShouldReceiveOneGetAllAsync(GetAllPostCommentLikesQueryRequest request, CancellationToken cancellationToken)
        {
            await postCommentLikeService.ShouldHaveReceivedOne()

                .GetAllAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQuery(request), cancellationToken);
        }

        public async Task ShouldReceiveOneGetAllForUserAsync(GetAllPostCommentLikesForUserQueryRequest request, CancellationToken cancellationToken)
        {
            await postCommentLikeService.ShouldHaveReceivedOne()

                .GetAllForUserAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesForUserQuery(request), cancellationToken);
        }

        public async Task ShouldReceiveOneGetByIdAsync(GetPostCommentLikeByIdQueryRequest request, CancellationToken cancellationToken)
        {
            await postCommentLikeService.ShouldHaveReceivedOne()

                .GetByIdAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQuery(request), cancellationToken);
        }
    }

    extension(IPostCommentLikeCommandService postCommentLikeService)
    {
        public async Task ShouldReceiveOneAddAsync(AddPostCommentLikeCommandRequest request, CancellationToken cancellationToken)
        {
            await postCommentLikeService.ShouldHaveReceivedOne()

                .AddAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommand(request), cancellationToken);
        }

        public async Task ShouldReceiveOneDeleteAsync(DeletePostCommentLikeCommandRequest request, CancellationToken cancellationToken)
        {
            await postCommentLikeService.ShouldHaveReceivedOne()

                .DeleteAsync(PostCommentLikeMatcher.IsDeletePostCommentLikeCommand(request), cancellationToken);
        }
    }
}
