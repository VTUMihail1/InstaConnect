using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllPostCommentsForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			AddPostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			UpdatePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostCommentByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetAllPostCommentsQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			UpdatePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostCommentNotFoundExceptionAsync(
				r => r.Id,
				r => r.CommentId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			DeletePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostCommentNotFoundExceptionAsync(
				r => r.Id,
				r => r.CommentId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			GetPostCommentByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostCommentNotFoundExceptionAsync(
				r => r.Id,
				r => r.CommentId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync(
			DeletePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostCommentForbiddenExceptionAsync(
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync(
			UpdatePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostCommentForbiddenExceptionAsync(
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				request,
				cancellationToken);
		}
	}
}
