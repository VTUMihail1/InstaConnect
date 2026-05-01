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
				.ReturnsResponse(postComments.ToResponse(post, request));
		}

		public void SetupGetAllForUserQueryRequest(
			GetAllPostCommentsForUserApiRequest request,
			User user,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentMatcher.IsGetAllPostCommentsForUserQueryRequest(request), cancellationToken)
				.ReturnsResponse(postComments.ToResponse(user, request));
		}

		public void SetupGetByIdQueryRequest(
			GetPostCommentByIdApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentMatcher.IsGetPostCommentByIdQueryRequest(request), cancellationToken)
				.ReturnsResponse(postComment.ToResponse(request));
		}

		public void SetupAddCommandRequest(
			AddPostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentMatcher.IsAddPostCommentCommandRequest(request), cancellationToken)
				.ReturnsResponse(postComment.ToResponse(request));
		}

		public void SetupUpdateCommandRequest(
			UpdatePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentMatcher.IsUpdatePostCommentCommandRequest(request), cancellationToken)
				.ReturnsResponse(postComment.ToResponse(request));
		}
	}
}
