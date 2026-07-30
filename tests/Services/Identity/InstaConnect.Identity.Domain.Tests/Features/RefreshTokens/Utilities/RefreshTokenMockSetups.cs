using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;

namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(RefreshToken refreshToken)
		{
			guidProvider
				.NewStringGuid()
				.ReturnsResponse(refreshToken.Id.Value);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(RefreshToken refreshToken)
		{
			dateTimeProvider
				.GetOffsetUtcNow()
				.ReturnsResponse(refreshToken.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(RefreshToken refreshToken, int lifetimeSeconds)
		{
			dateTimeProvider
				.GetOffsetUtcNow(lifetimeSeconds)
				.ReturnsResponse(refreshToken.ExpiresAtUtc);
		}

		public void SetupGetOffsetUtcNow(RotateRefreshTokenCommand command, DateTimeOffset utcNow)
		{
			dateTimeProvider
				.GetOffsetUtcNow()
				.ReturnsResponse(utcNow);
		}
	}

	extension(IPasswordHasher passwordHasher)
	{
		public void SetupIsMismatch(IssueRefreshTokenCommand command, User user)
		{
			passwordHasher
				.IsMismatch(command.Password, user.PasswordHash)
				.ReturnsResponse(false);
		}

		public void SetupIsMismatchExists(IssueRefreshTokenCommand command, User user)
		{
			passwordHasher
				.IsMismatch(command.Password, user.PasswordHash)
				.ReturnsResponse(true);
		}
	}

	extension(IRefreshTokenFactory factory)
	{
		public void SetupCreate(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			factory
				.Create(refreshToken.Id.Id)
				.ReturnsResponse(refreshToken);
		}

		public void SetupCreate(RotateRefreshTokenCommand command, RefreshToken refreshToken)
		{
			factory
				.Create(command.Id.Id)
				.ReturnsResponse(refreshToken);
		}
	}

	extension(ISessionTokenGenerator generator)
	{
		public void SetupGenerate(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			generator
				.Generate(refreshToken)
				.ReturnsResponse(refreshToken.ToResponse(command));
		}

		public void SetupGenerate(RotateRefreshTokenCommand command, RefreshToken refreshToken)
		{
			generator
				.Generate(refreshToken)
				.ReturnsResponse(refreshToken.ToResponse(command));
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByName(
			IssueRefreshTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByNameAsync(command.Name, RefreshTokenDomainMatcher.IsUserInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByName(
			IssueRefreshTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByNameAsync(command.Name, RefreshTokenDomainMatcher.IsUserInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupGetById(
			RotateRefreshTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id.Id, RefreshTokenDomainMatcher.IsUserInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetById(
			RotateRefreshTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id.Id, RefreshTokenDomainMatcher.IsUserInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsById(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsById(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IRefreshTokenCommandRepository repository)
	{
		public void SetupGetById(
			RotateRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(refreshToken);
		}

		public void SetupGetById(
			DeleteRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(refreshToken);
		}

		public void RemoveGetById(
			RotateRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetById(
			DeleteRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
