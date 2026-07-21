using InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.RefreshTokens.Services;

public class RotateRefreshTokenServiceUnitTests : BaseRefreshTokenDomainCommandUnitTest
{
	private readonly RotateRefreshTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly RotateRefreshTokenCommandBuilder _commandBuilder;
	private readonly RotateRefreshTokenCommand _command;

	private readonly UserInclude _include;

	private readonly RefreshToken _refreshToken;

	private readonly RefreshTokenCommandService _service;

	public RotateRefreshTokenServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(RefreshToken);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUserClaims().Build();

		_refreshToken = RefreshTokenBuilderFactory.Create(User).Build();

		_service = new(PasswordHasher, Repository, DateTimeProvider, Factory, SessionTokenGenerator, IncludeBuilderFactory, RefreshTokenRepository);

		Repository.SetupGetById(_command, _include, User, CancellationToken);
		RefreshTokenRepository.SetupGetById(_command, RefreshToken, CancellationToken);
		DateTimeProvider.SetupGetOffsetUtcNow(_command, UnexpiredDate);
		Factory.SetupCreate(_command, _refreshToken);
		SessionTokenGenerator.SetupGenerate(_command, _refreshToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		Repository.RemoveGetById(_command, _include, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowUserEmailNotConfirmedException_WhenEmailIsNotConfirmed()
	{
		// Arrange
		var unconfirmedUser = UserBuilder.WithUnconfirmedEmail().Build();
		Repository.SetupGetById(_command, _include, unconfirmedUser, CancellationToken);

		// Assert
		await _service.ShouldThrowUserEmailNotConfirmedExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowRefreshTokenNotFoundException_WhenRefreshTokenNotFound()
	{
		// Arrange
		RefreshTokenRepository.RemoveGetById(_command, RefreshToken, CancellationToken);

		// Assert
		await _service.ShouldThrowRefreshTokenNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowRefreshTokenExpiredException_WhenRefreshTokenHasExpired()
	{
		// Arrange
		DateTimeProvider.SetupGetOffsetUtcNow(_command, ExpiredDate);

		// Assert
		await _service.ShouldThrowRefreshTokenExpiredExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.RotateAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, _refreshToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.RotateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(_command, _include, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenCommandIsValid()
	{
		// Act
		await _service.RotateAsync(_command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldReceiveOneGetOffsetUtcNow(_command);
	}

	[Fact]
	public async Task RotateAsync_ShouldCallTheRefreshTokenRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.RotateAsync(_command, CancellationToken);

		// Assert
		await RefreshTokenRepository.ShouldReceiveOneGetByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldCallTheRefreshTokenRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.RotateAsync(_command, CancellationToken);

		// Assert
		await RefreshTokenRepository.ShouldReceiveOneDeleteAsync(_command, RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldCallTheFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.RotateAsync(_command, CancellationToken);

		// Assert
		Factory.ShouldReceiveOneCreate(_command);
	}

	[Fact]
	public async Task RotateAsync_ShouldCallTheRefreshTokenRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.RotateAsync(_command, CancellationToken);

		// Assert
		await RefreshTokenRepository.ShouldReceiveOneAddAsync(_command, _refreshToken, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldCallTheSessionTokenGeneratorGenerate_WhenCommandIsValid()
	{
		// Act
		await _service.RotateAsync(_command, CancellationToken);

		// Assert
		SessionTokenGenerator.ShouldReceiveOneGenerate(_command, _refreshToken);
	}
}
