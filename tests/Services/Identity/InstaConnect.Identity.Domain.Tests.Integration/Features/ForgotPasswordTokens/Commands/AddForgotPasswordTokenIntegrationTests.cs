using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.ForgotPasswordTokens.Commands;

public class AddForgotPasswordTokenIntegrationTests : BaseForgotPasswordTokenDomainCommandIntegrationTest
{
	private readonly AddForgotPasswordTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly AddForgotPasswordTokenCommandBuilder _commandBuilder;
	private readonly AddForgotPasswordTokenCommand _command;

	public AddForgotPasswordTokenIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNameNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddForgotPasswordToken_WhenCommandIsValid()
	{
		// Act
		await Service.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldNotBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldAddForgotPasswordToken_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		await Service.AddAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldNotBeEmpty();
	}

	[Fact]
	public async Task AddAsync_ShouldPublishForgotPasswordTokenAddedEvent_WhenCommandIsValid()
	{
		// Act
		await Service.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedForgotPasswordTokenAddedRangeAsync(_command, user, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldPublishForgotPasswordTokenAddedEvent_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		await Service.AddAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedForgotPasswordTokenAddedRangeAsync(command, user, CancellationToken);
	}
}
