using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupGetAllQueryRequest(
		GetAllPostCommentsApiRequest request,
		Post post,
		ICollection<PostComment> postComments,
		CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentMatcher.IsGetAllPostCommentsQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(post, request));
		}

		public void SetupGetAllForUserQueryRequest(
			GetAllPostCommentsForUserApiRequest request,
			User user,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentMatcher.IsGetAllPostCommentsForUserQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(user, request));
		}

		public void SetupGetByIdQueryRequest(
			GetPostCommentByIdApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentMatcher.IsGetPostCommentByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}

		public void SetupAddCommandRequest(
			AddPostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentMatcher.IsAddPostCommentCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}

		public void SetupUpdateCommandRequest(
			UpdatePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentMatcher.IsUpdatePostCommentCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}
	}
}
