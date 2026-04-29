using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeMockAssertions
{
	extension(IPostLikeQueryService postLikeService)
	{
		public async Task ShouldReceiveOneGetAllAsync(
		GetAllPostLikesQueryRequest request,
		CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().GetAllAsync(PostLikeMatcher.IsGetAllPostLikesQuery(request), cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForUserAsync(
			GetAllPostLikesForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().GetAllForUserAsync(PostLikeMatcher.IsGetAllPostLikesForUserQuery(request), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetPostLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().GetByIdAsync(PostLikeMatcher.IsGetPostLikeByIdQuery(request), cancellationToken);
		}
	}

	extension(IPostLikeCommandService postLikeService)
	{
		public async Task ShouldReceiveOneAddAsync(
		AddPostLikeCommandRequest request,
		CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().AddAsync(PostLikeMatcher.IsAddPostLikeCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeletePostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().DeleteAsync(PostLikeMatcher.IsDeletePostLikeCommand(request), cancellationToken);
		}
	}
}
