using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupGetAllQueryRequest(
		GetAllPostCommentLikesApiRequest request,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes,
		CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentLikePresentationMatcher.IsGetAllPostCommentLikesQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToResponse(request, postComment));
		}

		public void SetupGetAllForUserQueryRequest(
			GetAllPostCommentLikesForUserApiRequest request,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentLikePresentationMatcher.IsGetAllPostCommentLikesForUserQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToResponse(request, user));
		}

		public void SetupGetByIdQueryRequest(
			GetPostCommentLikeByIdApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentLikePresentationMatcher.IsGetPostCommentLikeByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(postCommentLike.ToResponse(request));
		}

		public void SetupAddCommandRequest(
			AddPostCommentLikeApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(PostCommentLikePresentationMatcher.IsAddPostCommentLikeCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(postCommentLike.ToResponse(request));
		}
	}
}
