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
				.GetAllAsync(request.IsGetAllPostCommentLikesQuery(), cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToResponse(request, postComment));
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentLikesForUserQueryRequest request,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			commentLikeService
				.GetAllForUserAsync(request.IsGetAllPostCommentLikesForUserQuery(), cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToResponse(request, user));
		}

		public void SetupGetByIdAsync(
			GetPostCommentLikeByIdQueryRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			commentLikeService
				.GetByIdAsync(request.IsGetPostCommentLikeByIdQuery(), cancellationToken)
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
				.AddAsync(request.IsAddPostCommentLikeCommand(), cancellationToken)
				.ReturnsTaskResponse(postCommentLike.ToResponse(request));
		}
	}
}
