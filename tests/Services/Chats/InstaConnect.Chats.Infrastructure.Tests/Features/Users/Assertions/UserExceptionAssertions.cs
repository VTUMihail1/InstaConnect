using InstaConnect.Common.Infrastructure.Tests.Features.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Users.Assertions;

public static class UserExceptionAssertions
{
	extension(UserAddedEventHandler handler)
	{
		public async Task ShouldThrowUserAlreadyExistsExceptionAsync(
			UserAddedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserAlreadyExistsExceptionAsync(
				r => r.User.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			UserAddedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyExistsExceptionAsync(
				r => r.User.Email,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			UserAddedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyExistsExceptionAsync(
				r => r.User.Name,
				request,
				cancellationToken);
		}
	}

	extension(UserUpdatedEventHandler handler)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			UserUpdatedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.User.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			UserUpdatedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyExistsExceptionAsync(
				r => r.User.Email,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			UserUpdatedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyExistsExceptionAsync(
				r => r.User.Name,
				request,
				cancellationToken);
		}
	}

	extension(UserDeletedEventHandler handler)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			UserDeletedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.User.Id,
				request,
				cancellationToken);
		}
	}
}
