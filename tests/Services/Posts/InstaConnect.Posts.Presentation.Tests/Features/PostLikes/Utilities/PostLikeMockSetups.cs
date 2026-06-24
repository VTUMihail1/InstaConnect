using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupGetAllQueryRequest(
		GetAllPostLikesApiRequest request,
		Post post,
		ICollection<PostLike> postLikes,
		CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostLikeMatcher.IsGetAllPostLikesQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(post, request));
		}

		public void SetupGetAllForUserQueryRequest(
			GetAllPostLikesForUserApiRequest request,
			User user,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostLikeMatcher.IsGetAllPostLikesForUserQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(user, request));
		}

		public void SetupGetByIdQueryRequest(
			GetPostLikeByIdApiRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostLikeMatcher.IsGetPostLikeByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postLike.ToResponse(request));
		}

		public void SetupAddCommandRequest(
			AddPostLikeApiRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostLikeMatcher.IsAddPostLikeCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(postLike.ToResponse(request));
		}
	}
}
