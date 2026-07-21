using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.Value;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.ForgotPasswordTokens.Commands;

public class VerifyForgotPasswordTokenIntegrationTests : BaseForgotPasswordTokenDomainCommandIntegrationTest
{
	private readonly VerifyForgotPasswordTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly VerifyForgotPasswordTokenCommandBuilder _commandBuilder;
	private readonly VerifyForgotPasswordTokenCommand _command;

	public VerifyForgotPasswordTokenIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(ForgotPasswordToken);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddForgotPasswordTokenRangeAsync(User.ForgotPasswordTokens, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowForgotPasswordTokenNotFoundException_WhenForgotPasswordTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteForgotPasswordTokenAsync(ForgotPasswordToken, CancellationToken);

		// Assert
		await Service.ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowForgotPasswordExpiredException_WhenForgotPasswordTokenHasExpired()
	{
		// Arrange
		var updatedForgotPasswordToken = ForgotPasswordTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateForgotPasswordTokenAsync(updatedForgotPasswordToken, CancellationToken);

		// Assert
		await Service.ShouldThrowForgotPasswordTokenExpiredExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldUpdatedUser_WhenCommandIsValid()
	{
		// Act
		await Service.VerifyAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ShouldSatisfy(_command, PasswordHasher);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldUpdatedUser_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.VerifyAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ShouldSatisfy(command, PasswordHasher);
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldUpdatedUser_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithValue(transformer).Build();

		// Act
		await Service.VerifyAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ShouldSatisfy(command, PasswordHasher);
	}

	[Fact]
	public async Task VerifyAsync_ShouldDeleteForgotPasswordToken_WhenCommandIsValid()
	{
		// Act
		await Service.VerifyAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldDeleteForgotPasswordToken_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.VerifyAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldBeEmpty();
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldDeleteForgotPasswordToken_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithValue(transformer).Build();

		// Act
		await Service.VerifyAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task VerifyAsync_ShouldPublishForgotPasswordTokenDeletedEvents_WhenCommandIsValid()
	{
		// Act
		await Service.VerifyAsync(_command, CancellationToken);
		var eventRequests = await EventHarness.PublishedForgotPasswordTokenDeletedEventRequestRange(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_command, User.ForgotPasswordTokens);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldPublishForgotPasswordTokenDeletedEvents_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.VerifyAsync(command, CancellationToken);
		var eventRequests = await EventHarness.PublishedForgotPasswordTokenDeletedEventRequestRange(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(command, User.ForgotPasswordTokens);
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldPublishForgotPasswordTokenDeletedEvents_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithValue(transformer).Build();

		// Act
		await Service.VerifyAsync(command, CancellationToken);
		var eventRequests = await EventHarness.PublishedForgotPasswordTokenDeletedEventRequestRange(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(command, User.ForgotPasswordTokens);
	}
}
