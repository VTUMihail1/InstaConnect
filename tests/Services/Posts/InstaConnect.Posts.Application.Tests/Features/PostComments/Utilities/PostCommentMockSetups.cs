namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentMockSetups
{
	extension(IPostCommentQueryService commentService)
	{
		public void SetupGetAllQuery(
		GetAllPostCommentsQueryRequest request,
		Post post,
		ICollection<PostComment> postComments,
		CancellationToken cancellationToken)
		{
			commentService
				.GetAllAsync(PostCommentMatcher.IsGetAllPostCommentsQuery(request), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(request, post));
		}

		public void SetupGetAllForUserQuery(
			GetAllPostCommentsForUserQueryRequest request,
			User user,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			commentService
				.GetAllForUserAsync(PostCommentMatcher.IsGetAllPostCommentsForUserQuery(request), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(request, user));
		}

		public void SetupGetByIdQuery(
			GetPostCommentByIdQueryRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			commentService
				.GetByIdAsync(PostCommentMatcher.IsGetPostCommentByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}
	}

	extension(IPostCommentCommandService commentService)
	{
		public void SetupAddCommand(
		AddPostCommentCommandRequest request,
		PostComment postComment,
		CancellationToken cancellationToken)
		{
			commentService
				.AddAsync(PostCommentMatcher.IsAddPostCommentCommand(request), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}

		public void SetupUpdateCommand(
			UpdatePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			commentService
				.UpdateAsync(PostCommentMatcher.IsUpdatePostCommentCommand(request), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}
	}
}
