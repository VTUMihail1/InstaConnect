using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
		GetAllPostCommentsApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetAllPostCommentsQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetAllPostCommentsForUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetAllPostCommentsForUserQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetPostCommentByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetPostCommentByIdQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			AddPostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsAddPostCommentCommandRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			UpdatePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsUpdatePostCommentCommandRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			DeletePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsDeletePostCommentCommandRequest(), cancellationToken);
		}
	}
}
