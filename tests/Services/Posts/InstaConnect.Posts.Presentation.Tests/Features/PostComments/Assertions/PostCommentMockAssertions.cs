using InstaConnect.Common.Application.Features.Messaging.Abstractions;
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
			await sender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsGetAllPostCommentsQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetAllPostCommentsForUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsGetAllPostCommentsForUserQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetPostCommentByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsGetPostCommentByIdQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			AddPostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsAddPostCommentCommandRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			UpdatePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsUpdatePostCommentCommandRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			DeletePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsDeletePostCommentCommandRequest(request), cancellationToken);
		}
	}
}
