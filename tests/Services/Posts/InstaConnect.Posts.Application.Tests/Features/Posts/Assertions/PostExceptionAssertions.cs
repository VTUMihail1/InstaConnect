using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
		GetAllPostsForUserQueryRequest request,
		CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			UpdatePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostForbiddenExceptionAsync(
			UpdatePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostForbiddenExceptionAsync(
				r => r.Id,
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostForbiddenExceptionAsync(
			DeletePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowPostForbiddenExceptionAsync(
				r => r.Id,
				r => r.UserId,
				request,
				cancellationToken);
		}
	}
}
