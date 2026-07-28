namespace InstaConnect.Follows.Infrastructure.Tests.Features.Users.Assertions;

public static class UserEventHandlerExceptionAssertions
{
	extension(UserAddedEventHandler handler)
	{
		public async Task ShouldThrowUserAlreadyExistsExceptionAsync(
			UserAddedEventRequest request,
			IApplicationMapper mapper,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<AddUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserAlreadyExistsExceptionAsync(r => r.Id, command, cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			UserAddedEventRequest request,
			IApplicationMapper mapper,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<AddUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyExistsExceptionAsync(r => r.Email, command, cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			UserAddedEventRequest request,
			IApplicationMapper mapper,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<AddUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyExistsExceptionAsync(r => r.Name, command, cancellationToken);
		}
	}

	extension(UserUpdatedEventHandler handler)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			UserUpdatedEventRequest request,
			IApplicationMapper mapper,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<UpdateUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(r => r.Id, command, cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			UserUpdatedEventRequest request,
			IApplicationMapper mapper,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<UpdateUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyExistsExceptionAsync(r => r.Email, command, cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			UserUpdatedEventRequest request,
			IApplicationMapper mapper,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<UpdateUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyExistsExceptionAsync(r => r.Name, command, cancellationToken);
		}
	}

	extension(UserDeletedEventHandler handler)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			UserDeletedEventRequest request,
			IApplicationMapper mapper,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<DeleteUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(r => r.Id, command, cancellationToken);
		}
	}
}
