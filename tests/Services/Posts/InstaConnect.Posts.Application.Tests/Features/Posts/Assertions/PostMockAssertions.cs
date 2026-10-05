using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostMockAssertions
{
	extension(IPostQueryService postService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
		GetAllPostsQueryRequest request,
		CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().GetAllAsync(request.IsGetAllPostsQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostsForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().GetAllForUserAsync(request.IsGetAllPostsForUserQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().GetByIdAsync(request.IsGetPostByIdQuery(), cancellationToken);
		}
	}

	extension(IPostCommandService postService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddPostCommandRequest request,
		CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().AddAsync(request.IsAddPostCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdatePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().UpdateAsync(request.IsUpdatePostCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().DeleteAsync(request.IsDeletePostCommand(), cancellationToken);
		}
	}
}
