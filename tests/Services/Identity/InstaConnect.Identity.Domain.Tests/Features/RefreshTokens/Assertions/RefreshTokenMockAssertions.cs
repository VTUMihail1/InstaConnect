using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMockAssertions
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldReceiveOneGetOffsetUtcNow(int lifetimeSeconds)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow(lifetimeSeconds);
		}

		public void ShouldReceiveOneGetOffsetUtcNow(RotateRefreshTokenCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}

	extension(IPasswordHasher passwordHasher)
	{
		public void ShouldReceiveOneIsMismatch(IssueRefreshTokenCommand command, User user)
		{
			passwordHasher.ShouldHaveReceivedOne().IsMismatch(command.Password, user.PasswordHash);
		}
	}

	extension(IRefreshTokenFactory factory)
	{
		public void ShouldReceiveOneCreate(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			factory.ShouldHaveReceivedOne().Create(refreshToken.Id.Id);
		}

		public void ShouldReceiveOneCreate(RotateRefreshTokenCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(command.Id.Id);
		}
	}

	extension(ISessionTokenGenerator generator)
	{
		public void ShouldReceiveOneGenerate(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			generator.ShouldHaveReceivedOne().Generate(refreshToken);
		}

		public void ShouldReceiveOneGenerate(RotateRefreshTokenCommand command, RefreshToken refreshToken)
		{
			generator.ShouldHaveReceivedOne().Generate(refreshToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByNameAsync(
			IssueRefreshTokenCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByNameAsync(
				command.Name,
				RefreshTokenDomainMatcher.IsUserInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			RotateRefreshTokenCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id.Id,
				RefreshTokenDomainMatcher.IsUserInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}
	}

	extension(IRefreshTokenCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldReceiveOneAddAsync(
			IssueRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(RefreshTokenDomainMatcher.IsRefreshToken(command, refreshToken), cancellationToken);
		}

		public async Task ShouldReceiveOneAddAsync(
			RotateRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(RefreshTokenDomainMatcher.IsRefreshToken(command, refreshToken), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			RotateRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(RefreshTokenDomainMatcher.IsRefreshToken(command, refreshToken), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(RefreshTokenDomainMatcher.IsRefreshToken(command, refreshToken), cancellationToken);
		}
	}
}
