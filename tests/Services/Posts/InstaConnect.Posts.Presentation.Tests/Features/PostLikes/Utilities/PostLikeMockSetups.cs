using InstaConnect.Common.Application.Features.Requests.Abstractions;

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
				.SendAsync(request.IsGetAllPostLikesQueryRequest(), cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(request, post));
		}

		public void SetupSendAsync(
			GetAllPostLikesForUserApiRequest request,
			User user,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsGetAllPostLikesForUserQueryRequest(), cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(request, user));
		}

		public void SetupSendAsync(
			GetPostLikeByIdApiRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsGetPostLikeByIdQueryRequest(), cancellationToken)
				.ReturnsTaskResponse(postLike.ToResponse(request));
		}

		public void SetupSendAsync(
			AddPostLikeApiRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsAddPostLikeCommandRequest(), cancellationToken)
				.ReturnsTaskResponse(postLike.ToResponse(request));
		}
	}
}
