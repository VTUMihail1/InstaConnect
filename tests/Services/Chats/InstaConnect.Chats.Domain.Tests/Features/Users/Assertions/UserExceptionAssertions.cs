using InstaConnect.Chats.Tests.Features.Users.Assertions;

namespace InstaConnect.Chats.Domain.Tests.Features.Users.Assertions;

public static class UserExceptionAssertions
{
	extension(IUserCommandService service)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
		UpdateUserCommand request,
		CancellationToken cancellationToken)
		{
			var action = () => service.UpdateAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteUserCommand request,
			CancellationToken cancellationToken)
		{
			var action = () => service.DeleteAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserAlreadyExistsExceptionAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			var action = () => service.AddAsync(request, cancellationToken);

			await action.ShouldThrowUserAlreadyExistsExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			var action = () => service.AddAsync(request, cancellationToken);

			await action.ShouldThrowUserNameAlreadyExistsExceptionAsync(
				r => r.Name,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			var action = () => service.UpdateAsync(request, cancellationToken);

			await action.ShouldThrowUserNameAlreadyExistsExceptionAsync(
				r => r.Name,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			var action = () => service.AddAsync(request, cancellationToken);

			await action.ShouldThrowUserEmailAlreadyExistsExceptionAsync(
				r => r.Email,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			var action = () => service.UpdateAsync(request, cancellationToken);

			await action.ShouldThrowUserEmailAlreadyExistsExceptionAsync(
				r => r.Email,
				request,
				cancellationToken);
		}
	}
}
