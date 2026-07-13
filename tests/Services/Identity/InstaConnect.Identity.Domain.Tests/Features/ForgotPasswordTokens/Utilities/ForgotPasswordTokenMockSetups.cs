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

		public void SetupGetOffsetUtcNow(ForgotPasswordToken forgotPasswordToken, int lifetimeSeconds)
		{
			dateTimeProvider
				.GetOffsetUtcNow(lifetimeSeconds)
				.ReturnsResponse(forgotPasswordToken.ExpiresAtUtc);
		}

		public void SetupGetOffsetUtcNow(VerifyForgotPasswordTokenCommand command, DateTimeOffset utcNow)
		{
			dateTimeProvider
				.GetOffsetUtcNow()
				.ReturnsResponse(utcNow);
		}
	}

	extension(IPasswordHasher passwordHasher)
	{
		public void SetupHash(VerifyForgotPasswordTokenCommand command, User user)
		{
			passwordHasher
				.Hash(command.Password)
				.ReturnsResponse(user.PasswordHash);
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
		public void SetupGetByName(
			AddForgotPasswordTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByNameAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByName(
			AddForgotPasswordTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByNameAsync(command.Name, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupGetById(
			VerifyForgotPasswordTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id.Id, ForgotPasswordTokenMatcher.IsUserInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetById(
			VerifyForgotPasswordTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id.Id, ForgotPasswordTokenMatcher.IsUserInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IForgotPasswordTokenCommandRepository repository)
	{
		public void SetupGetById(
			VerifyForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(forgotPasswordToken);
		}

		public void RemoveGetById(
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
