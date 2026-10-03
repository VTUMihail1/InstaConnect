using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
	extension(IPostCommentLikeQueryService postCommentLikeService)
	{
		public async Task ShouldReceiveOneGetAllAsync(GetAllPostCommentLikesQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.GetAllAsync(request.IsGetAllPostCommentLikesQuery(), cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForUserAsync(GetAllPostCommentLikesForUserQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.GetAllForUserAsync(request.IsGetAllPostCommentLikesForUserQuery(), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(GetPostCommentLikeByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.GetByIdAsync(request.IsGetPostCommentLikeByIdQuery(), cancellationToken);
		}
	}

	extension(IPostCommentLikeCommandService postCommentLikeService)
	{
		public async Task ShouldReceiveOneAddAsync(AddPostCommentLikeCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.AddAsync(request.IsAddPostCommentLikeCommand(), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(DeletePostCommentLikeCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.DeleteAsync(request.IsDeletePostCommentLikeCommand(), cancellationToken);
		}
	}
}
