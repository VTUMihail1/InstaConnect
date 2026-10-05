using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeMockAssertions
{
	extension(IPostLikeQueryService postLikeService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
		GetAllPostLikesQueryRequest request,
		CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().GetAllAsync(request.IsGetAllPostLikesQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostLikesForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().GetAllForUserAsync(request.IsGetAllPostLikesForUserQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().GetByIdAsync(request.IsGetPostLikeByIdQuery(), cancellationToken);
		}
	}

	extension(IPostLikeCommandService postLikeService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddPostLikeCommandRequest request,
		CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().AddAsync(request.IsAddPostLikeCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().DeleteAsync(request.IsDeletePostLikeCommand(), cancellationToken);
		}
	}
}
