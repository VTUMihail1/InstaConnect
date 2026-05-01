using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
		GetAllPostLikesApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsGetAllPostLikesQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetAllPostLikesForUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsGetAllPostLikesForUserQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetPostLikeByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsGetPostLikeByIdQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			AddPostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsAddPostLikeCommandRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			DeletePostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsDeletePostLikeCommandRequest(request), cancellationToken);
		}
	}
}
