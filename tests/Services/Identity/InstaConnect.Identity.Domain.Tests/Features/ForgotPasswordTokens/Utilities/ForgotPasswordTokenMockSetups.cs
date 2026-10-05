using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(ForgotPasswordToken forgotPasswordToken)
		{
			guidProvider
				.NewStringGuid()
				.ReturnsResponse(forgotPasswordToken.Id.Value);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(ForgotPasswordToken forgotPasswordToken)
		{
			dateTimeProvider
				.GetOffsetUtcNow()
				.ReturnsResponse(forgotPasswordToken.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(
			ForgotPasswordToken forgotPasswordToken,
			IOptions<ForgotPasswordTokenOptions> forgotPasswordTokenOptions)
		{
			dateTimeProvider
				.GetOffsetUtcNow(forgotPasswordTokenOptions.Value.LifetimeSeconds)
				.ReturnsResponse(forgotPasswordToken.ExpiresAtUtc);
		}

		public void SetupGetOffsetUtcNow(VerifyForgotPasswordTokenCommand command, DateTimeOffset utcNow)
		{
			dateTimeProvider
				.GetOffsetUtcNow()
				.ReturnsResponse(utcNow);
		}
	}

	extension(IForgotPasswordTokenFactory factory)
	{
		public void SetupCreate(AddForgotPasswordTokenCommand command, ForgotPasswordToken forgotPasswordToken)
		{
			factory
				.Create(forgotPasswordToken.Id.Id)
				.ReturnsResponse(forgotPasswordToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByNameAsync(
			AddForgotPasswordTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByNameAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByNameAsync(
			AddForgotPasswordTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByNameAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id.Id, include, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id.Id, include, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IForgotPasswordTokenCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(forgotPasswordToken);
		}

		public void RemoveGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
