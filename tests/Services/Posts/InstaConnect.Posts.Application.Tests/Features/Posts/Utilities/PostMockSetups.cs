namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostMockSetups
{
	extension(IPostQueryService service)
	{
		public void SetupGetAllQuery(
		GetAllPostsQueryRequest request,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(PostMatcher.IsGetAllPostsQuery(request), cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(request));
		}

		public void SetupGetAllForUserQuery(
			GetAllPostsForUserQueryRequest request,
			User user,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			service
				.GetAllForUserAsync(PostMatcher.IsGetAllPostsForUserQuery(request), cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(request, user));
		}

		public void SetupGetByIdQuery(
			GetPostByIdQueryRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(PostMatcher.IsGetPostByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}
	}

	extension(IPostCommandService service)
	{
		public void SetupAddCommand(
		AddPostCommandRequest request,
		Post post,
		CancellationToken cancellationToken)
		{
			service
				.AddAsync(PostMatcher.IsAddPostCommand(request), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}

		public void SetupUpdateCommand(
			UpdatePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			service
				.UpdateAsync(PostMatcher.IsUpdatePostCommand(request), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}
	}
}
