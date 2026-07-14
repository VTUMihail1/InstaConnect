using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.EmailConfirmationTokens.Commands;

public class AddEmailConfirmationTokenIntegrationTests : BaseEmailConfirmationTokenDomainCommandIntegrationTest
{
	private readonly AddEmailConfirmationTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly AddEmailConfirmationTokenCommandBuilder _commandBuilder;
	private readonly AddEmailConfirmationTokenCommand _command;

	public AddEmailConfirmationTokenIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
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
	public async Task AddAsync_ShouldThrowUserNameEmailAlreadyConfirmedException_WhenEmailIsConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithConfirmedEmail().Build();
		await ServiceScope.UpdateUserAsync(updatedUser, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenCommandIsValid()
	{
		// Act
		await Service.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldNotBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		await Service.AddAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldNotBeEmpty();
	}

	[Fact]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenCommandIsValid()
	{
		// Act
		await Service.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenAddedRangeAsync(_command, user, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		await Service.AddAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenAddedRangeAsync(command, user, CancellationToken);
	}
}
