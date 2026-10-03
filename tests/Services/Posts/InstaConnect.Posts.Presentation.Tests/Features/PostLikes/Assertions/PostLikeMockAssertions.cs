using InstaConnect.Common.Application.Features.Requests.Abstractions;
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
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetAllPostLikesQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetAllPostLikesForUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetAllPostLikesForUserQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetPostLikeByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetPostLikeByIdQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			AddPostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsAddPostLikeCommandRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			DeletePostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsDeletePostLikeCommandRequest(), cancellationToken);
		}
	}
}
