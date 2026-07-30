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
				.SendAsync(PostLikePresentationMatcher.IsGetAllPostLikesQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(request, post));
		}

		public void SetupGetAllForUserQueryRequest(
			GetAllPostLikesForUserApiRequest request,
			User user,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostLikePresentationMatcher.IsGetAllPostLikesForUserQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(request, user));
		}

		public void SetupGetByIdQueryRequest(
			GetPostLikeByIdApiRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostLikePresentationMatcher.IsGetPostLikeByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postLike.ToResponse(request));
		}

		public void SetupAddCommandRequest(
			AddPostLikeApiRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostLikePresentationMatcher.IsAddPostLikeCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(postLike.ToResponse(request));
		}
	}
}
