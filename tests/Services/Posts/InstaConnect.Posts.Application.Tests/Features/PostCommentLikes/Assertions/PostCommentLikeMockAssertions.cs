using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
	extension(IPostCommentLikeQueryService postCommentLikeService)
	{
		public async Task ShouldReceiveOneGetAllAsync(GetAllPostCommentLikesQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.GetAllAsync(PostCommentLikeApplicationMatcher.IsGetAllPostCommentLikesQuery(request), cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForUserAsync(GetAllPostCommentLikesForUserQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.GetAllForUserAsync(PostCommentLikeApplicationMatcher.IsGetAllPostCommentLikesForUserQuery(request), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(GetPostCommentLikeByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.GetByIdAsync(PostCommentLikeApplicationMatcher.IsGetPostCommentLikeByIdQuery(request), cancellationToken);
		}
	}

	extension(IPostCommentLikeCommandService postCommentLikeService)
	{
		public async Task ShouldReceiveOneAddAsync(AddPostCommentLikeCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.AddAsync(PostCommentLikeApplicationMatcher.IsAddPostCommentLikeCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(DeletePostCommentLikeCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.DeleteAsync(PostCommentLikeApplicationMatcher.IsDeletePostCommentLikeCommand(request), cancellationToken);
		}
	}
}
