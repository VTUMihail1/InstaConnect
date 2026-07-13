using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(EmailConfirmationToken emailConfirmationToken)
		{
			guidProvider
				.NewStringGuid()
				.ReturnsResponse(emailConfirmationToken.Id.Value);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(EmailConfirmationToken emailConfirmationToken)
		{
			dateTimeProvider
				.GetOffsetUtcNow()
				.ReturnsResponse(emailConfirmationToken.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(EmailConfirmationToken emailConfirmationToken, int lifetimeSeconds)
		{
			dateTimeProvider
				.GetOffsetUtcNow(lifetimeSeconds)
				.ReturnsResponse(emailConfirmationToken.ExpiresAtUtc);
		}

		public void SetupGetOffsetUtcNow(VerifyEmailConfirmationTokenCommand command, DateTimeOffset utcNow)
		{
			dateTimeProvider
				.GetOffsetUtcNow()
				.ReturnsResponse(utcNow);
		}
	}

	extension(IEmailConfirmationTokenFactory factory)
	{
		public void SetupCreate(AddEmailConfirmationTokenCommand command, EmailConfirmationToken emailConfirmationToken)
		{
			factory
				.Create(emailConfirmationToken.Id.Id)
				.ReturnsResponse(emailConfirmationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByName(
			AddEmailConfirmationTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByNameAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByName(
			AddEmailConfirmationTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByNameAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupGetById(
			VerifyEmailConfirmationTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id.Id, EmailConfirmationTokenMatcher.IsUserInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetById(
			VerifyEmailConfirmationTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id.Id, EmailConfirmationTokenMatcher.IsUserInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IEmailConfirmationTokenCommandRepository repository)
	{
		public void SetupGetById(
			VerifyEmailConfirmationTokenCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(emailConfirmationToken);
		}

		public void RemoveGetById(
			VerifyEmailConfirmationTokenCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
