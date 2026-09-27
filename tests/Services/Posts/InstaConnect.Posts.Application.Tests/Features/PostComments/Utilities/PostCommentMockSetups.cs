namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentMockSetups
{
	extension(IPostCommentQueryService commentService)
	{
		public void SetupGetAllAsync(
		GetAllPostCommentsQueryRequest request,
		Post post,
		ICollection<PostComment> postComments,
		CancellationToken cancellationToken)
		{
			commentService
				.GetAllAsync(request.IsGetAllPostCommentsQuery(), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(request, post));
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentsForUserQueryRequest request,
			User user,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			commentService
				.GetAllForUserAsync(request.IsGetAllPostCommentsForUserQuery(), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(request, user));
		}

		public void SetupGetByIdAsync(
			GetPostCommentByIdQueryRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			commentService
				.GetByIdAsync(request.IsGetPostCommentByIdQuery(), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}
	}

	extension(IPostCommentCommandService commentService)
	{
		public void SetupAddAsync(
		AddPostCommentCommandRequest request,
		PostComment postComment,
		CancellationToken cancellationToken)
		{
			commentService
				.AddAsync(request.IsAddPostCommentCommand(), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}

		public void SetupUpdateAsync(
			UpdatePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			commentService
				.UpdateAsync(request.IsUpdatePostCommentCommand(), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}
	}
}
