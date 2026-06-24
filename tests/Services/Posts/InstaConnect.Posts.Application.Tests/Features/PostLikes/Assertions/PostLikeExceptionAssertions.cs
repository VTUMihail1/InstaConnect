using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
		GetAllPostLikesForUserQueryRequest request,
		CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			AddPostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetAllPostLikesQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeNotFoundExceptionAsync(
			DeletePostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostLikeNotFoundExceptionAsync(
				r => r.Id,
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeNotFoundExceptionAsync(
			GetPostLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostLikeNotFoundExceptionAsync(
				r => r.Id,
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync(
			AddPostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostLikeAlreadyExistsExceptionAsync(
				r => r.Id,
				r => r.UserId,
				request,
				cancellationToken);
		}
	}
}
