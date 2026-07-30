namespace InstaConnect.Follows.Domain.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IUserFactory factory)
	{
		public void SetupCreate(
			AddUserCommand command,
			User user)
		{
			factory
				.ClearCalls()
				.Create(
					command.Id,
					command.FirstName,
					command.LastName,
					command.Name,
					command.Email,
					command.ProfileImage,
					command.CreatedAtUtc,
					command.UpdatedAtUtc)
				.ReturnsResponse(user.To(command));
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupExistsByIdAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupGetByIdAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void SetupGetByIdAsync(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveExistsByIdAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveGetByIdAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetByIdAsync(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupIsNameUniqueAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupIsNameUniqueAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveIsNameUniqueAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveIsNameUniqueAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void SetupIsEmailUniqueAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupIsEmailUniqueAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveIsEmailUniqueAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveIsEmailUniqueAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}
}
