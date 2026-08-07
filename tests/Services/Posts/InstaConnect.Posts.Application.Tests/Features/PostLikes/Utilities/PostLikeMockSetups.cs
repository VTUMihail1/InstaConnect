namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockSetups
{
	extension(IPostLikeQueryService likeService)
	{
		public void SetupGetAllAsync(
		GetAllPostLikesQueryRequest request,
		Post post,
		ICollection<PostLike> postLikes,
		CancellationToken cancellationToken)
		{
			likeService
				.ClearCalls()
				.GetAllAsync(PostLikeApplicationMatcher.IsGetAllPostLikesQuery(request), cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(request, post));
		}

		public void SetupGetAllForUserAsync(
			GetAllPostLikesForUserQueryRequest request,
			User user,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			likeService
				.ClearCalls()
				.GetAllForUserAsync(PostLikeApplicationMatcher.IsGetAllPostLikesForUserQuery(request), cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(request, user));
		}

		public void SetupGetByIdAsync(
			GetPostLikeByIdQueryRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			likeService
				.ClearCalls()
				.GetByIdAsync(PostLikeApplicationMatcher.IsGetPostLikeByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(postLike.ToResponse(request));
		}
	}

	extension(IPostLikeCommandService likeService)
	{
		public void SetupAddAsync(
		AddPostLikeCommandRequest request,
		PostLike postLike,
		CancellationToken cancellationToken)
		{
			likeService
				.ClearCalls()
				.AddAsync(PostLikeApplicationMatcher.IsAddPostLikeCommand(request), cancellationToken)
				.ReturnsTaskResponse(postLike.ToResponse(request));
		}
	}
}
