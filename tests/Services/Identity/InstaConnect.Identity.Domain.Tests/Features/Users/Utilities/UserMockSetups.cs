using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

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
					command.Name,
					command.FirstName,
					command.LastName,
					command.Email,
					command.Password)
				.ReturnsResponse(user.To(command));
		}
	}

	extension(IPasswordHasher passwordHasher)
	{
		public void SetupHash(
			User user,
			string password)
		{
			passwordHasher
				.ClearCalls()
				.Hash(password)
				.ReturnsResponse(user.PasswordHash);
		}
	}

	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(User user)
		{
			guidProvider
				.ClearCalls()
				.NewStringGuid()
				.ReturnsResponse(user.Id.Id);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(User user)
		{
			dateTimeProvider
				.ClearCalls()
				.GetOffsetUtcNow()
				.ReturnsResponse(user.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(
			UpdateUserCommand command,
			User user)
		{
			dateTimeProvider
				.ClearCalls()
				.GetOffsetUtcNow()
				.ReturnsResponse(user.UpdatedAtUtc);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupIsEmailUniqueAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupIsEmailUniqueAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveIsEmailUniqueAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveIsEmailUniqueAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void SetupIsNameUniqueAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupIsNameUniqueAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveIsNameUniqueAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveIsNameUniqueAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void SetupGetByIdAsync(
			UpdateUserCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, UserDomainMatcher.IsUserInclude(command, include), cancellationToken)
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

		public void RemoveGetByIdAsync(
			UpdateUserCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, UserDomainMatcher.IsUserInclude(command, include), cancellationToken)
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
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllUsersQuery query,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetAllAsync(query.Filter, query.Current, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(users.ToResponse(query));
		}

		public void SetupGetTotalCountAsync(
			GetAllUsersQuery query,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(users.ToTotalCountResponse(query));
		}

		public void SetupGetByIdAsync(
			GetUserByIdQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Id, query.Current, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetUserByIdQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Id, query.Current, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IEmailConfirmationTokenFactory factory)
	{
		public void SetupCreate(
			AddUserCommand command,
			EmailConfirmationToken emailConfirmationToken)
		{
			factory
				.ClearCalls()
				.Create(emailConfirmationToken.Id.Id)
				.ReturnsResponse(emailConfirmationToken.To(command));
		}
	}
}
