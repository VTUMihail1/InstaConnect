using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowFollowingNotFoundExceptionAsync(
		GetAllFollowsForFollowingQueryRequest request,
		CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.FollowingId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowFollowingNotFoundExceptionAsync(
			AddFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.FollowingId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowFollowerNotFoundExceptionAsync(
			AddFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.FollowerId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowFollowerNotFoundExceptionAsync(
			DeleteFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.FollowerId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowFollowerNotFoundExceptionAsync(
			GetFollowByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.FollowerId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowFollowerNotFoundExceptionAsync(
			GetAllFollowsQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.FollowerId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowFollowNotFoundExceptionAsync(
			DeleteFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowFollowNotFoundExceptionAsync(
				r => r.FollowerId,
				r => r.FollowingId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowFollowNotFoundExceptionAsync(
			GetFollowByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowFollowNotFoundExceptionAsync(
				r => r.FollowerId,
				r => r.FollowingId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowFollowAlreadyExistsExceptionAsync(
			AddFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowFollowAlreadyExistsExceptionAsync(
				r => r.FollowerId,
				r => r.FollowingId,
				request,
				cancellationToken);
		}
	}
}
