namespace InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IUserFactory factory)
	{
		public void SetupCreate(
			AddUserCommand command,
			User user)
		{
			factory
				.Create(
				    command.Id,
					command.FirstName,
					command.LastName,
					command.Name,
					command.Email,
					command.ProfileImage,
					command.CreatedAtUtc,
					command.UpdatedAtUtc)
				.ReturnsResponse(user.ToFull(command));
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupExistsById(
			AddUserCommand command,
		    User user,
		    CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupGetById(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void SetupGetById(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveExistsById(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveGetById(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetById(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupIsNameUnique(
			AddUserCommand command,
			User user,
		    CancellationToken cancellationToken)
		{
			repository
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupIsNameUnique(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveIsNameUnique(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveIsNameUnique(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void SetupIsEmailUnique(
			AddUserCommand command,
			User user,
		    CancellationToken cancellationToken)
		{
			repository
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupIsEmailUnique(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveIsEmailUnique(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveIsEmailUnique(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}
}
