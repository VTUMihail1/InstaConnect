using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(RefreshToken refreshToken)
		{
			guidProvider
				.ClearCalls()
				.NewStringGuid()
				.ReturnsResponse(refreshToken.Id.Value);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(RefreshToken refreshToken)
		{
			dateTimeProvider
				.ClearCalls()
				.GetOffsetUtcNow()
				.ReturnsResponse(refreshToken.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(
			RefreshToken refreshToken,
			IOptions<RefreshTokenOptions> refreshTokenOptions)
		{
			dateTimeProvider
				.ClearCalls()
				.GetOffsetUtcNow(refreshTokenOptions.Value.LifetimeSeconds)
				.ReturnsResponse(refreshToken.ExpiresAtUtc);
		}

		public void SetupGetOffsetUtcNow(RotateRefreshTokenCommand command, DateTimeOffset utcNow)
		{
			dateTimeProvider
				.ClearCalls()
				.GetOffsetUtcNow()
				.ReturnsResponse(utcNow);
		}
	}

	extension(IPasswordHasher passwordHasher)
	{
		public void RemoveIsMismatch(IssueRefreshTokenCommand command, User user)
		{
			passwordHasher
				.ClearCalls()
				.IsMismatch(command.Password, user.PasswordHash)
				.ReturnsResponse(false);
		}

		public void SetupIsMismatch(IssueRefreshTokenCommand command, User user)
		{
			passwordHasher
				.ClearCalls()
				.IsMismatch(command.Password, user.PasswordHash)
				.ReturnsResponse(true);
		}
	}

	extension(IRefreshTokenFactory factory)
	{
		public void SetupCreate(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			factory
				.ClearCalls()
				.Create(refreshToken.Id.Id)
				.ReturnsResponse(refreshToken);
		}

		public void SetupCreate(RotateRefreshTokenCommand command, RefreshToken refreshToken)
		{
			factory
				.ClearCalls()
				.Create(command.Id.Id)
				.ReturnsResponse(refreshToken);
		}
	}

	extension(ISessionTokenGenerator generator)
	{
		public void SetupGenerate(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			generator
				.ClearCalls()
				.Generate(refreshToken)
				.ReturnsResponse(refreshToken.ToResponse(command));
		}

		public void SetupGenerate(RotateRefreshTokenCommand command, RefreshToken refreshToken)
		{
			generator
				.ClearCalls()
				.Generate(refreshToken)
				.ReturnsResponse(refreshToken.ToResponse(command));
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByNameAsync(
			IssueRefreshTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByNameAsync(command.Name, RefreshTokenDomainMatcher.IsUserInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByNameAsync(
			IssueRefreshTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByNameAsync(command.Name, RefreshTokenDomainMatcher.IsUserInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupGetByIdAsync(
			RotateRefreshTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id.Id, RefreshTokenDomainMatcher.IsUserInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByIdAsync(
			RotateRefreshTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id.Id, RefreshTokenDomainMatcher.IsUserInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsByIdAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsByIdAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IRefreshTokenCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			RotateRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(refreshToken);
		}

		public void SetupGetByIdAsync(
			DeleteRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(refreshToken);
		}

		public void RemoveGetByIdAsync(
			RotateRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetByIdAsync(
			DeleteRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
