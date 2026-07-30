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
				.ClearCalls()
				.GetAllAsync(PostCommentApplicationMatcher.IsGetAllPostCommentsQuery(request), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(request, post));
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentsForUserQueryRequest request,
			User user,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			commentService
				.ClearCalls()
				.GetAllForUserAsync(PostCommentApplicationMatcher.IsGetAllPostCommentsForUserQuery(request), cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(request, user));
		}

		public void SetupGetByIdAsync(
			GetPostCommentByIdQueryRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			commentService
				.ClearCalls()
				.GetByIdAsync(PostCommentApplicationMatcher.IsGetPostCommentByIdQuery(request), cancellationToken)
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
				.ClearCalls()
				.AddAsync(PostCommentApplicationMatcher.IsAddPostCommentCommand(request), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}

		public void SetupUpdateAsync(
			UpdatePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			commentService
				.ClearCalls()
				.UpdateAsync(PostCommentApplicationMatcher.IsUpdatePostCommentCommand(request), cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(request));
		}
	}
}
