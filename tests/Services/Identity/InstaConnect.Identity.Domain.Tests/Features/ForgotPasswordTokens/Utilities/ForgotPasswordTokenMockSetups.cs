using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(ForgotPasswordToken forgotPasswordToken)
		{
			guidProvider
				.ClearCalls()
				.NewStringGuid()
				.ReturnsResponse(forgotPasswordToken.Id.Value);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(ForgotPasswordToken forgotPasswordToken)
		{
			dateTimeProvider
				.ClearCalls()
				.GetOffsetUtcNow()
				.ReturnsResponse(forgotPasswordToken.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(ForgotPasswordToken forgotPasswordToken, int lifetimeSeconds)
		{
			dateTimeProvider
				.ClearCalls()
				.GetOffsetUtcNow(lifetimeSeconds)
				.ReturnsResponse(forgotPasswordToken.ExpiresAtUtc);
		}

		public void SetupGetOffsetUtcNow(VerifyForgotPasswordTokenCommand command, DateTimeOffset utcNow)
		{
			dateTimeProvider
				.ClearCalls()
				.GetOffsetUtcNow()
				.ReturnsResponse(utcNow);
		}
	}

	extension(IPasswordHasher passwordHasher)
	{
		public void SetupHash(VerifyForgotPasswordTokenCommand command, User user)
		{
			passwordHasher
				.ClearCalls()
				.Hash(command.Password)
				.ReturnsResponse(user.PasswordHash);
		}
	}

	extension(IForgotPasswordTokenFactory factory)
	{
		public void SetupCreate(AddForgotPasswordTokenCommand command, ForgotPasswordToken forgotPasswordToken)
		{
			factory
				.ClearCalls()
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
				.ClearCalls()
				.GetByNameAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByNameAsync(
			AddForgotPasswordTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
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
				.ClearCalls()
				.GetByIdAsync(command.Id.Id, ForgotPasswordTokenDomainMatcher.IsUserInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id.Id, ForgotPasswordTokenDomainMatcher.IsUserInclude(command, include), cancellationToken)
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
				.ClearCalls()
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(forgotPasswordToken);
		}

		public void RemoveGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
