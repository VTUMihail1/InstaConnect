using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.RefreshTokens.Commands;

public class IssueRefreshTokenIntegrationTests : BaseRefreshTokenDomainCommandIntegrationTest
{
	private readonly IssueRefreshTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly IssueRefreshTokenCommandBuilder _commandBuilder;
	private readonly IssueRefreshTokenCommand _command;

	public IssueRefreshTokenIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User, Password);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddUserClaimRangeAsync(User.UserClaims, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldThrowUserInvalidDetailsException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserInvalidDetailsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldThrowUserInvalidDetailsException_WhenPasswordDoesNotMatch()
	{
		// Arrange
		var updatedUser = UserBuilder.WithPasswordHash(PasswordHasher.Hash(NewPassword)).Build();
		await ServiceScope.UpdateUserAsync(updatedUser, CancellationToken);

		// Assert
		await Service.ShouldThrowUserInvalidDetailsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldThrowUserNameEmailNotConfirmedException_WhenEmailIsNotConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithUnconfirmedEmail().Build();
		await ServiceScope.UpdateUserAsync(updatedUser, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNameEmailNotConfirmedExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.IssueAsync(_command, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response.Id, CancellationToken);

		// Assert
		response.ShouldSatisfy(refreshToken, _command);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task IssueAsync_ShouldReturnResponse_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		var response = await Service.IssueAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response.Id, CancellationToken);

		// Assert
		response.ShouldSatisfy(refreshToken, command);
	}

	[Fact]
	public async Task IssueAsync_ShouldAddRefreshToken_WhenCommandIsValid()
	{
		// Act
		var response = await Service.IssueAsync(_command, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response.Id, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(_command, PasswordHasher);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task IssueAsync_ShouldAddRefreshToken_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		var response = await Service.IssueAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetRefreshTokenByIdAsync(response.Id, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(_command, PasswordHasher);
	}
}
