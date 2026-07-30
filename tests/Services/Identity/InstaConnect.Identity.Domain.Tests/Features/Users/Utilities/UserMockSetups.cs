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
				.NewStringGuid()
				.ReturnsResponse(user.Id.Id);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(User user)
		{
			dateTimeProvider
				.GetOffsetUtcNow()
				.ReturnsResponse(user.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(
			UpdateUserCommand command,
			User user)
		{
			dateTimeProvider
				.GetOffsetUtcNow()
				.ReturnsResponse(user.UpdatedAtUtc);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupIsEmailUnique(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupIsEmailUnique(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveIsEmailUnique(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveIsEmailUnique(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.IsEmailUniqueAsync(command.Email, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void SetupIsNameUnique(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupIsNameUnique(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveIsNameUnique(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveIsNameUnique(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.IsNameUniqueAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void SetupGetById(
			UpdateUserCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, UserMatcher.IsUserInclude(command, include), cancellationToken)
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

		public void RemoveGetById(
			UpdateUserCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, UserMatcher.IsUserInclude(command, include), cancellationToken)
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
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetAllQuery(
			GetAllUsersQuery query,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(query.Filter, query.Current, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(users.ToResponse(query));
		}

		public void SetupGetTotalCount(
			GetAllUsersQuery query,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(users.ToTotalCountResponse(query));
		}

		public void SetupGetById(
			GetUserByIdQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.Current, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetById(
			GetUserByIdQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
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
				.Create(emailConfirmationToken.Id.Id)
				.ReturnsResponse(emailConfirmationToken.To(command));
		}
	}
}
