using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;


using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMockAssertions
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldHaveReceivedOneGetOffsetUtcNow(IOptions<RefreshTokenOptions> refreshTokenOptions)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow(refreshTokenOptions.Value.LifetimeSeconds);
		}

		public void ShouldHaveReceivedOneGetOffsetUtcNow(RotateRefreshTokenCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}

	extension(IPasswordHasher passwordHasher)
	{
		public void ShouldHaveReceivedOneIsMismatch(IssueRefreshTokenCommand command, User user)
		{
			passwordHasher.ShouldHaveReceivedOne().IsMismatch(command.Password, user.PasswordHash);
		}
	}

	extension(IRefreshTokenFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			factory.ShouldHaveReceivedOne().Create(refreshToken.Id.Id);
		}

		public void ShouldHaveReceivedOneCreate(RotateRefreshTokenCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(command.Id.Id);
		}
	}

	extension(ISessionTokenGenerator generator)
	{
		public void ShouldHaveReceivedOneGenerate(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			generator.ShouldHaveReceivedOne().Generate(refreshToken);
		}

		public void ShouldHaveReceivedOneGenerate(RotateRefreshTokenCommand command, RefreshToken refreshToken)
		{
			generator.ShouldHaveReceivedOne().Generate(refreshToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByNameAsync(
			IssueRefreshTokenCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByNameAsync(
				command.Name,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			RotateRefreshTokenCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
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
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			IssueRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(command.IsRefreshToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(command.IsRefreshToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(command.IsRefreshToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(command.IsRefreshToken(), cancellationToken);
		}
	}
}
