namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockSetups
{
	extension(IPostCommentLikeQueryService commentLikeService)
	{
		public void SetupGetAllAsync(
			GetAllPostCommentLikesQueryRequest request,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			commentLikeService
				.ClearCalls()
				.GetAllAsync(PostCommentLikeApplicationMatcher.IsGetAllPostCommentLikesQuery(request), cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToResponse(request, postComment));
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentLikesForUserQueryRequest request,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			commentLikeService
				.ClearCalls()
				.GetAllForUserAsync(PostCommentLikeApplicationMatcher.IsGetAllPostCommentLikesForUserQuery(request), cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToResponse(request, user));
		}

		public void SetupGetByIdAsync(
			GetPostCommentLikeByIdQueryRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			commentLikeService
				.ClearCalls()
				.GetByIdAsync(PostCommentLikeApplicationMatcher.IsGetPostCommentLikeByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(postCommentLike.ToResponse(request));
		}
	}

	extension(IPostCommentLikeCommandService commentLikeService)
	{
		public void SetupAddAsync(
			AddPostCommentLikeCommandRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			commentLikeService
				.ClearCalls()
				.AddAsync(PostCommentLikeApplicationMatcher.IsAddPostCommentLikeCommand(request), cancellationToken)
				.ReturnsTaskResponse(postCommentLike.ToResponse(request));
		}
	}
}
