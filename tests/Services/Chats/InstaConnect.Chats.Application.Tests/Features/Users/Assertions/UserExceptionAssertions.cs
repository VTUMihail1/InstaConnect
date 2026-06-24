using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Features.Users.Assertions;

public static class UserExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
		UpdateUserCommandRequest request,
		CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserAlreadyExistsExceptionAsync(
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserAlreadyExistsExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyExistsExceptionAsync(
				r => r.Name,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			UpdateUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyExistsExceptionAsync(
				r => r.Name,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyExistsExceptionAsync(
				r => r.Email,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			UpdateUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyExistsExceptionAsync(
				r => r.Email,
				request,
				cancellationToken);
		}
	}
}
