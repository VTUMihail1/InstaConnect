using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.Users.Commands;

public class UpdateUserIntegrationTests : BaseUserDomainCommandIntegrationTest
{
	private readonly UpdateUserCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdateUserCommandBuilder _commandBuilder;
	private readonly UpdateUserCommand _command;

	public UpdateUserIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddEmailConfirmationTokenRangeAsync(User.EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserEmailAlreadyTakenException_WhenEmailIsNotUnique()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);
		var command = _commandBuilder.WithEmail(user.Email).Build();

		// Assert
		await Service.ShouldThrowUserEmailAlreadyTakenExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldThrowUserEmailAlreadyTakenException_WhenEmailIsNotUniqueAndDifferentCase(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);
		var command = _commandBuilder.WithEmail(user.Email, transformer).Build();

		// Assert
		await Service.ShouldThrowUserEmailAlreadyTakenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNameAlreadyTakenException_WhenNameIsNotUnique()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);
		var command = _commandBuilder.WithName(user.Name).Build();

		// Assert
		await Service.ShouldThrowUserNameAlreadyTakenExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldThrowUserNameAlreadyTakenException_WhenNameIsNotUniqueAndDifferentCase(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash, User.ProfileImage.Url).Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);
		var command = _commandBuilder.WithName(user.Name, transformer).Build();

		// Assert
		await Service.ShouldThrowUserNameAlreadyTakenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, _command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenIdIsValidAndDifferentCase(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailIsNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameIsNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, command);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, command);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateUser_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_command);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenNameIsValidAndDifferentCase(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenEmailIsValidAndDifferentCase(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishUserUpdatedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldPublishUserUpdatedEvent_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishUserUpdatedEvent_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishUserUpdatedEvent_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserUpdatedAsync(user, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldDeleteEmailConfirmationTokens_WhenEmailIsChanged()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task UpdateAsync_ShouldNotDeleteEmailConfirmationTokens_WhenEmailIsNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldNotBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldDeleteEmailConfirmationTokens_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldDeleteEmailConfirmationTokens_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldNotBeEmpty();
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenEmailIsChanged()
	{
		// Act
		await Service.UpdateAsync(_command, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldNotPublishEmailConfirmationTokenDeletedEvents_WhenEmailIsNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await Service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventHarness.ShouldHaveNotPublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		await Service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldNotPublishEmailConfirmationTokenDeletedEvents_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await Service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventHarness.ShouldHaveNotPublishedEmailConfirmationTokenDeletedRangeAsync(User, CancellationToken);
	}
}
