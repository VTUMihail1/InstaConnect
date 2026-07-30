using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostMockAssertions
{
	extension(IPostQueryService postService)
	{
		public async Task ShouldReceiveOneGetAllAsync(
		GetAllPostsQueryRequest request,
		CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().GetAllAsync(PostApplicationMatcher.IsGetAllPostsQuery(request), cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForUserAsync(
			GetAllPostsForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().GetAllForUserAsync(PostApplicationMatcher.IsGetAllPostsForUserQuery(request), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetPostByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().GetByIdAsync(PostApplicationMatcher.IsGetPostByIdQuery(request), cancellationToken);
		}
	}

	extension(IPostCommandService postService)
	{
		public async Task ShouldReceiveOneAddAsync(
		AddPostCommandRequest request,
		CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().AddAsync(PostApplicationMatcher.IsAddPostCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(
			UpdatePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().UpdateAsync(PostApplicationMatcher.IsUpdatePostCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeletePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().DeleteAsync(PostApplicationMatcher.IsDeletePostCommand(request), cancellationToken);
		}
	}
}
