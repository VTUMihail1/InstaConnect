using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupGetAllQueryRequest(
		GetAllPostsApiRequest request,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostMatcher.IsGetAllPostsQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(request));
		}

		public void SetupGetAllForUserQueryRequest(
			GetAllPostsForUserApiRequest request,
			User user,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostMatcher.IsGetAllPostsForUserQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(request, user));
		}

		public void SetupGetByIdQueryRequest(
			GetPostByIdApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostMatcher.IsGetPostByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}

		public void SetupAddCommandRequest(
			AddPostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostMatcher.IsAddPostCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}

		public void SetupUpdateCommandRequest(
			UpdatePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostMatcher.IsUpdatePostCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}
	}
}
