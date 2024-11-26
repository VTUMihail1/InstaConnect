using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.EditCurrentUser;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Commands;

public class EditCurrentUserIntegrationTests : BaseUserIntegrationTest
{
    public EditCurrentUserIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            null!,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenFirstNameIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            existingUserId,
            null!,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            existingUserId,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenLastNameIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            existingUserId,
            UserTestUtilities.ValidUpdateFirstName,
            null!,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.LAST_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenLastLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            existingUserId,
            UserTestUtilities.ValidUpdateFirstName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenUserNameIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            existingUserId,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            null!,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.USER_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.USER_NAME_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            existingUserId,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNameAlreadyTakenException_WhenNameIsAlreadyTaken()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingUserNameTakedId = await CreateUserAsync(UserTestUtilities.ValidUpdateEmail, UserTestUtilities.ValidUpdateName, true, CancellationToken);
        var command = new EditCurrentUserCommand(
            existingUserId,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNameAlreadyTakenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserCommandViewModel_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            existingUserId,
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
            .Match<UserCommandViewModel>(p => p.Id == existingUserId);
    }

    [Fact]
    public async Task SendAsync_ShouldEditCurrentUser_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            existingUserId,
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
            .Match<User>(p => p.Id == existingUserId &&
                              p.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              p.LastName == UserTestUtilities.ValidUpdateLastName &&
                              p.UserName == UserTestUtilities.ValidUpdateName &&
                              p.Email == UserTestUtilities.ValidEmail &&
                              PasswordHasher.Verify(UserTestUtilities.ValidPassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidUpdateProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldEditCurrentUser_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            existingUserId,
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
                              p.Email == UserTestUtilities.ValidEmail &&
                              PasswordHasher.Verify(UserTestUtilities.ValidPassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldEditCurrentUser_WhenUserIsValidAndNameIsTheSame()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            existingUserId,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidName,
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
                              p.UserName == UserTestUtilities.ValidName &&
                              p.Email == UserTestUtilities.ValidEmail &&
                              PasswordHasher.Verify(UserTestUtilities.ValidPassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldPublishUserUpdateEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            existingUserId,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserUpdatedEvent>(m =>
                              m.Context.Message.Id == existingUserId &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidUpdateLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidUpdateName &&
                              m.Context.Message.Email == UserTestUtilities.ValidEmail &&
                              m.Context.Message.ProfileImage == UserTestUtilities.ValidUpdateProfileImage, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishUserUpdatedEvent_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new EditCurrentUserCommand(
            existingUserId,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            null
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserUpdatedEvent>(m =>
                              m.Context.Message.Id == existingUserId &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidUpdateLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidUpdateName &&
                              m.Context.Message.Email == UserTestUtilities.ValidEmail &&
                              m.Context.Message.ProfileImage == UserTestUtilities.ValidProfileImage, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
