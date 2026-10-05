using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;


using Microsoft.Extensions.Options;

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

		public void SetupGetOffsetUtcNow(
			EmailConfirmationToken emailConfirmationToken,
			IOptions<EmailConfirmationTokenOptions> emailConfirmationTokenOptions)
		{
			dateTimeProvider
				.GetOffsetUtcNow(emailConfirmationTokenOptions.Value.LifetimeSeconds)
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
		public void SetupGetByNameAsync(
			AddEmailConfirmationTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByNameAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByNameAsync(
			AddEmailConfirmationTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByNameAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id.Id, include, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id.Id, include, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IEmailConfirmationTokenCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(emailConfirmationToken);
		}

		public void RemoveGetByIdAsync(
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
