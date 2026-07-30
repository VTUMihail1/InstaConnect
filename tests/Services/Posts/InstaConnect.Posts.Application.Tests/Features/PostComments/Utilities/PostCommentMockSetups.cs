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
				.GetAllAsync(PostCommentApplicationMatcher.IsGetAllPostCommentsQuery(request), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(request, post));
		}

		public void SetupGetAllForUserQuery(
			GetAllPostCommentsForUserQueryRequest request,
			User user,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			commentService
				.GetAllForUserAsync(PostCommentApplicationMatcher.IsGetAllPostCommentsForUserQuery(request), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(request, user));
		}

		public void SetupGetByIdQuery(
			GetPostCommentByIdQueryRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			commentService
				.GetByIdAsync(PostCommentApplicationMatcher.IsGetPostCommentByIdQuery(request), cancellationToken)
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
				.AddAsync(PostCommentApplicationMatcher.IsAddPostCommentCommand(request), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}

		public void SetupUpdateCommand(
			UpdatePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			commentService
				.UpdateAsync(PostCommentApplicationMatcher.IsUpdatePostCommentCommand(request), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}
	}
}
