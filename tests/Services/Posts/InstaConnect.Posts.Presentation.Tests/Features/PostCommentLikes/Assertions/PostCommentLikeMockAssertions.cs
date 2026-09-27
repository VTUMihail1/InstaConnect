using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
		GetAllPostCommentLikesApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetAllPostCommentLikesQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetAllPostCommentLikesForUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetAllPostCommentLikesForUserQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetPostCommentLikeByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetPostCommentLikeByIdQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			AddPostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsAddPostCommentLikeCommandRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			DeletePostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsDeletePostCommentLikeCommandRequest(), cancellationToken);
		}
	}
}
