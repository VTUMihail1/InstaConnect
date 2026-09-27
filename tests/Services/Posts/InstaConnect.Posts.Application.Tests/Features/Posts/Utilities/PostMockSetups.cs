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
				.GetAllAsync(request.IsGetAllPostsQuery(), cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(request));
		}

		public void SetupGetAllForUserAsync(
			GetAllPostsForUserQueryRequest request,
			User user,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			service
				.GetAllForUserAsync(request.IsGetAllPostsForUserQuery(), cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(request, user));
		}

		public void SetupGetByIdAsync(
			GetPostByIdQueryRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(request.IsGetPostByIdQuery(), cancellationToken)
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
				.AddAsync(request.IsAddPostCommand(), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}

		public void SetupUpdateAsync(
			UpdatePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			service
				.UpdateAsync(request.IsUpdatePostCommand(), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}
	}
}
