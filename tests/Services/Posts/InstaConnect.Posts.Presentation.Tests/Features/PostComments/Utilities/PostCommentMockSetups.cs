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
				.SendAsync(request.IsGetAllPostCommentsQueryRequest(), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(request, post));
		}

		public void SetupSendAsync(
			GetAllPostCommentsForUserApiRequest request,
			User user,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsGetAllPostCommentsForUserQueryRequest(), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(request, user));
		}

		public void SetupSendAsync(
			GetPostCommentByIdApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsGetPostCommentByIdQueryRequest(), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}

		public void SetupSendAsync(
			AddPostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsAddPostCommentCommandRequest(), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}

		public void SetupSendAsync(
			UpdatePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsUpdatePostCommentCommandRequest(), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}
	}
}
