using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
	extension(IPostCommentLikeQueryService postCommentLikeService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(GetAllPostCommentLikesQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.GetAllAsync(request.IsGetAllPostCommentLikesQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(GetAllPostCommentLikesForUserQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.GetAllForUserAsync(request.IsGetAllPostCommentLikesForUserQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(GetPostCommentLikeByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.GetByIdAsync(request.IsGetPostCommentLikeByIdQuery(), cancellationToken);
		}
	}

	extension(IPostCommentLikeCommandService postCommentLikeService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(AddPostCommentLikeCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.AddAsync(request.IsAddPostCommentLikeCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(DeletePostCommentLikeCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne()

				.DeleteAsync(request.IsDeletePostCommentLikeCommand(), cancellationToken);
		}
	}
}
