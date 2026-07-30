using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllPostLikesApiRequest request,
		Post post,
		ICollection<PostLike> postLikes,
		CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(PostLikePresentationMatcher.IsGetAllPostLikesQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(request, post));
		}

		public void SetupSendAsync(
			GetAllPostLikesForUserApiRequest request,
			User user,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(PostLikePresentationMatcher.IsGetAllPostLikesForUserQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(request, user));
		}

		public void SetupSendAsync(
			GetPostLikeByIdApiRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(PostLikePresentationMatcher.IsGetPostLikeByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postLike.ToResponse(request));
		}

		public void SetupSendAsync(
			AddPostLikeApiRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(PostLikePresentationMatcher.IsAddPostLikeCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(postLike.ToResponse(request));
		}
	}
}
