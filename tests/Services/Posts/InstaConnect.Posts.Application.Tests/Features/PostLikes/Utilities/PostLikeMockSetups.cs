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
				.GetAllAsync(request.IsGetAllPostLikesQuery(), cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(request, post));
		}

		public void SetupGetAllForUserAsync(
			GetAllPostLikesForUserQueryRequest request,
			User user,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			likeService
				.GetAllForUserAsync(request.IsGetAllPostLikesForUserQuery(), cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(request, user));
		}

		public void SetupGetByIdAsync(
			GetPostLikeByIdQueryRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			likeService
				.GetByIdAsync(request.IsGetPostLikeByIdQuery(), cancellationToken)
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
				.AddAsync(request.IsAddPostLikeCommand(), cancellationToken)
				.ReturnsTaskResponse(postLike.ToResponse(request));
		}
	}
}
