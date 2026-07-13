using InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.RefreshTokens.Services;

public class DeleteRefreshTokenServiceUnitTests : BaseRefreshTokenDomainCommandUnitTest
{
	private readonly DeleteRefreshTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteRefreshTokenCommandBuilder _commandBuilder;
	private readonly DeleteRefreshTokenCommand _command;

	private readonly RefreshTokenCommandService _service;

	public DeleteRefreshTokenServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(RefreshToken);
		_command = _commandBuilder.Build();

		_service = new(PasswordHasher, Repository, DateTimeProvider, Factory, SessionTokenGenerator, RefreshTokenRepository, IncludeBuilderFactory);

		Repository.SetupExistsById(_command, CancellationToken);
		RefreshTokenRepository.SetupGetById(_command, RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		Repository.RemoveExistsById(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowRefreshTokenNotFoundException_WhenRefreshTokenNotFound()
	{
		// Arrange
		RefreshTokenRepository.RemoveGetById(_command, RefreshToken, CancellationToken);

		// Assert
		await _service.ShouldThrowRefreshTokenNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneExistsByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRefreshTokenRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await RefreshTokenRepository.ShouldReceiveOneGetByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRefreshTokenRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await RefreshTokenRepository.ShouldReceiveOneDeleteAsync(_command, RefreshToken, CancellationToken);
	}
}
