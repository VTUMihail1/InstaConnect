using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostCommentLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllPostCommentLikesForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			AddPostCommentLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostCommentLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostCommentLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetAllPostCommentLikesQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			AddPostCommentLikeCommandRequest request,
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
			DeletePostCommentLikeCommandRequest request,
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
			GetPostCommentLikeByIdQueryRequest request,
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
			GetAllPostCommentLikesQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostCommentNotFoundExceptionAsync(
				r => r.Id,
				r => r.CommentId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync(
			DeletePostCommentLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostCommentLikeNotFoundExceptionAsync(
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync(
			GetPostCommentLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostCommentLikeNotFoundExceptionAsync(
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(
			AddPostCommentLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				request,
				cancellationToken);
		}
	}
}
