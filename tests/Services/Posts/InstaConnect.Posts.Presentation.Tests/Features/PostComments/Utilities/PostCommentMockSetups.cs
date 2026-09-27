using InstaConnect.Common.Application.Features.Requests.Abstractions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllPostCommentsApiRequest request,
		Post post,
		ICollection<PostComment> postComments,
		CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentPresentationMatcher.IsGetAllPostCommentsQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(request, post));
		}

		public void SetupSendAsync(
			GetAllPostCommentsForUserApiRequest request,
			User user,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentPresentationMatcher.IsGetAllPostCommentsForUserQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(request, user));
		}

		public void SetupSendAsync(
			GetPostCommentByIdApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentPresentationMatcher.IsGetPostCommentByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}

		public void SetupSendAsync(
			AddPostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentPresentationMatcher.IsAddPostCommentCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}

		public void SetupSendAsync(
			UpdatePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentPresentationMatcher.IsUpdatePostCommentCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}
	}
}
