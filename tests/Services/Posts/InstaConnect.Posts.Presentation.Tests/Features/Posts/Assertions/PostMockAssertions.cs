using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
		GetAllPostsApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetAllPostsQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetAllPostsForUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetAllPostsForUserQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetPostByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetPostByIdQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			AddPostApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsAddPostCommandRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			UpdatePostApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsUpdatePostCommandRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			DeletePostApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsDeletePostCommandRequest(), cancellationToken);
		}
	}
}
