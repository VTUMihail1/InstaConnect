using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Identity.Application.Features.Users.Commands.Update;
using InstaConnect.Identity.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Commands;

public class UpdateUserCommandHandlerIntegrationTests : BaseUserIntegrationTest
{
    public UpdateUserCommandHandlerIntegrationTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var command = new UpdateUserCommand(
            null,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new UpdateUserCommand(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenFirstNameIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new UpdateUserCommand(
            existingUser.Id,
            null,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.FirstNameMinLength - 1)]
    [InlineData(UserConfigurations.FirstNameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new UpdateUserCommand(
            existingUser.Id,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenLastNameIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            null,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.LastNameMinLength - 1)]
    [InlineData(UserConfigurations.LastNameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenLastLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserNameIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            null,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var command = new UpdateUserCommand(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNameAlreadyTakenException_WhenNameIsAlreadyTaken()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingUserWithTakenName = await CreateUserAsync(CancellationToken);
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            existingUserWithTakenName.UserName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<UserNameAlreadyTakenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserCommandViewModel_WhenUserIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserCommandViewModel>(p => p.Id == existingUser.Id);
    }

    [Fact]
    public async Task SendAsync_ShouldEditCurrentUser_WhenUserIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == existingUser.Id &&
                              p.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              p.LastName == UserTestUtilities.ValidUpdateLastName &&
                              p.UserName == UserTestUtilities.ValidUpdateName &&
                              p.Email == existingUser.Email &&
                              PasswordHasher.Verify(UserTestUtilities.ValidPassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidUpdateProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldEditCurrentUser_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            null
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == response.Id &&
                              p.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              p.LastName == UserTestUtilities.ValidUpdateLastName &&
                              p.UserName == UserTestUtilities.ValidUpdateName &&
                              p.Email == existingUser.Email &&
                              PasswordHasher.Verify(UserTestUtilities.ValidPassword, p.PasswordHash) &&
                              p.ProfileImage == existingUser.ProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldEditCurrentUser_WhenUserIsValidAndNameIsTheSame()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            existingUser.UserName,
            null
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == response.Id &&
                              p.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              p.LastName == UserTestUtilities.ValidUpdateLastName &&
                              p.UserName == existingUser.UserName &&
                              p.Email == existingUser.Email &&
                              PasswordHasher.Verify(UserTestUtilities.ValidPassword, p.PasswordHash) &&
                              p.ProfileImage == existingUser.ProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldPublishUserUpdateEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserUpdatedEvent>(m =>
                              m.Context.Message.Id == existingUser.Id &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidUpdateLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidUpdateName &&
                              m.Context.Message.Email == existingUser.Email &&
                              m.Context.Message.ProfileImage == UserTestUtilities.ValidUpdateProfileImage, CancellationToken);

        // Assert
        result
            .Should()
            .BeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishUserUpdatedEvent_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            null
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserUpdatedEvent>(m =>
                              m.Context.Message.Id == existingUser.Id &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidUpdateLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidUpdateName &&
                              m.Context.Message.Email == existingUser.Email &&
                              m.Context.Message.ProfileImage == existingUser.ProfileImage, CancellationToken);

        // Assert
        result
            .Should()
            .BeTrue();
    }
}
