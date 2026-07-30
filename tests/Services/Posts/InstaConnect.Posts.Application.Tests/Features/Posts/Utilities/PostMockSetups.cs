namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostMockSetups
{
	extension(IPostQueryService service)
	{
		public void SetupGetAllAsync(
		GetAllPostsQueryRequest request,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.GetAllAsync(PostApplicationMatcher.IsGetAllPostsQuery(request), cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(request));
		}

		public void SetupGetAllForUserAsync(
			GetAllPostsForUserQueryRequest request,
			User user,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.GetAllForUserAsync(PostApplicationMatcher.IsGetAllPostsForUserQuery(request), cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(request, user));
		}

		public void SetupGetByIdAsync(
			GetPostByIdQueryRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.GetByIdAsync(PostApplicationMatcher.IsGetPostByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}
	}

	extension(IPostCommandService service)
	{
		public void SetupAddAsync(
		AddPostCommandRequest request,
		Post post,
		CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.AddAsync(PostApplicationMatcher.IsAddPostCommand(request), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}

		public void SetupUpdateAsync(
			UpdatePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.UpdateAsync(PostApplicationMatcher.IsUpdatePostCommand(request), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}
	}
}
