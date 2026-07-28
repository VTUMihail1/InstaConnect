namespace InstaConnect.Follows.Infrastructure.Tests.Features.Users.Assertions;

public static class UserEventHandlerValidationExceptionAssertions
{
	extension(UserAddedEventHandler handler)
	{
		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			UserAddedEventRequest request,
			IApplicationMapper mapper,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<AddUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.Id, messageTransformer, cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
			UserAddedEventRequest request,
			IApplicationMapper mapper,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<AddUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.Name, messageTransformer, cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForFirstNameAsync(
			UserAddedEventRequest request,
			IApplicationMapper mapper,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<AddUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.FirstName, messageTransformer, cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForLastNameAsync(
			UserAddedEventRequest request,
			IApplicationMapper mapper,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<AddUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.LastName, messageTransformer, cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForEmailAsync(
			UserAddedEventRequest request,
			IApplicationMapper mapper,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<AddUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.Email, messageTransformer, cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForProfileImageAsync(
			UserAddedEventRequest request,
			IApplicationMapper mapper,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<AddUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.ProfileImageUrl, messageTransformer!, cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCreatedAtUtcAsync(
			UserAddedEventRequest request,
			IApplicationMapper mapper,
			IDateTimeOffsetMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<AddUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.CreatedAtUtc, messageTransformer, cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUpdatedAtUtcAsync(
			UserAddedEventRequest request,
			IApplicationMapper mapper,
			IDateTimeOffsetMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<AddUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.UpdatedAtUtc, messageTransformer, cancellationToken);
		}
	}

	extension(UserUpdatedEventHandler handler)
	{
		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			UserUpdatedEventRequest request,
			IApplicationMapper mapper,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<UpdateUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.Id, messageTransformer, cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
			UserUpdatedEventRequest request,
			IApplicationMapper mapper,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<UpdateUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.Name, messageTransformer, cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForFirstNameAsync(
			UserUpdatedEventRequest request,
			IApplicationMapper mapper,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<UpdateUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.FirstName, messageTransformer, cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForLastNameAsync(
			UserUpdatedEventRequest request,
			IApplicationMapper mapper,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<UpdateUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.LastName, messageTransformer, cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForEmailAsync(
			UserUpdatedEventRequest request,
			IApplicationMapper mapper,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<UpdateUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.Email, messageTransformer, cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForProfileImageAsync(
			UserUpdatedEventRequest request,
			IApplicationMapper mapper,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<UpdateUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.ProfileImageUrl, messageTransformer!, cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUpdatedAtUtcAsync(
			UserUpdatedEventRequest request,
			IApplicationMapper mapper,
			IDateTimeOffsetMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<UpdateUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.UpdatedAtUtc, messageTransformer, cancellationToken);
		}
	}

	extension(UserDeletedEventHandler handler)
	{
		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			UserDeletedEventRequest request,
			IApplicationMapper mapper,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var command = mapper.Map<DeleteUserCommandRequest>(request);
			Func<Task> func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(command, p => p.Id, messageTransformer, cancellationToken);
		}
	}
}
