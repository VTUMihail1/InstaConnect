using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllPostsApiRequest request,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(PostPresentationMatcher.IsGetAllPostsQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(request));
		}

		public void SetupSendAsync(
			GetAllPostsForUserApiRequest request,
			User user,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(PostPresentationMatcher.IsGetAllPostsForUserQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(request, user));
		}

		public void SetupSendAsync(
			GetPostByIdApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(PostPresentationMatcher.IsGetPostByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}

		public void SetupSendAsync(
			AddPostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(PostPresentationMatcher.IsAddPostCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}

		public void SetupSendAsync(
			UpdatePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(PostPresentationMatcher.IsUpdatePostCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(request));
		}
	}
}
