using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllPostCommentLikesApiRequest request,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes,
		CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(PostCommentLikePresentationMatcher.IsGetAllPostCommentLikesQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToResponse(request, postComment));
		}

		public void SetupSendAsync(
			GetAllPostCommentLikesForUserApiRequest request,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(PostCommentLikePresentationMatcher.IsGetAllPostCommentLikesForUserQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToResponse(request, user));
		}

		public void SetupSendAsync(
			GetPostCommentLikeByIdApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(PostCommentLikePresentationMatcher.IsGetPostCommentLikeByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postCommentLike.ToResponse(request));
		}

		public void SetupSendAsync(
			AddPostCommentLikeApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(PostCommentLikePresentationMatcher.IsAddPostCommentLikeCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(postCommentLike.ToResponse(request));
		}
	}
}
