using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.Value;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.RefreshTokens.Commands;

public class RotateRefreshTokenIntegrationTests : BaseRefreshTokenDomainCommandIntegrationTest
{
	private readonly RotateRefreshTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly RotateRefreshTokenCommandBuilder _commandBuilder;
	private readonly RotateRefreshTokenCommand _command;

	public RotateRefreshTokenIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(RefreshToken);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddUserClaimRangeAsync(User.UserClaims, CancellationToken);
		await ServiceScope.AddRefreshTokenAsync(RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowRefreshTokenNotFoundException_WhenRefreshTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteRefreshTokenAsync(RefreshToken, CancellationToken);

		// Assert
		await Service.ShouldThrowRefreshTokenNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowRefreshTokenExpiredException_WhenRefreshTokenHasExpired()
	{
		// Arrange
		var updatedRefreshToken = RefreshTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateRefreshTokenAsync(updatedRefreshToken, CancellationToken);

		// Assert
		await Service.ShouldThrowRefreshTokenExpiredExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldDeleteRefreshToken_WhenCommandIsValid()
	{
		// Act
		await Service.RotateAsync(_command, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(RefreshToken.Id, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldDeleteRefreshToken_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.RotateAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(RefreshToken.Id, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldDeleteRefreshToken_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithValue(transformer).Build();

		// Act
		await Service.RotateAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(RefreshToken.Id, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Fact]
	public async Task RotateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.RotateAsync(_command, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response.Id, CancellationToken);

		// Assert
		response.ShouldSatisfy(refreshToken, _command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.RotateAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response.Id, CancellationToken);

		// Assert
		response.ShouldSatisfy(refreshToken, command);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldReturnResponse_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithValue(transformer).Build();

		// Act
		var response = await Service.RotateAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response.Id, CancellationToken);

		// Assert
		response.ShouldSatisfy(refreshToken, command);
	}

	[Fact]
	public async Task RotateAsync_ShouldAddRefreshToken_WhenCommandIsValid()
	{
		// Act
		var response = await Service.RotateAsync(_command, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response.Id, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldAddRefreshToken_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.RotateAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response.Id, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(command);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldAddRefreshToken_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithValue(transformer).Build();

		// Act
		var response = await Service.RotateAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response.Id, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(command);
	}
}
