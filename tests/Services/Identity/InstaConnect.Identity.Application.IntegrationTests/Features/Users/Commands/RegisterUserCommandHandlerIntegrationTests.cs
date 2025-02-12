using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.RegisterUser;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Contracts.Emails;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;
using MassTransit.Testing;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Commands;

public class RegisterUserCommandHandlerIntegrationTests : BaseUserIntegrationTest
{
    public RegisterUserCommandHandlerIntegrationTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenNameIsNull()
    {
        // Arrange
        var command = new AddUserCommand(
            null,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddUserCommand(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenEmailIsNull()
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            null,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.EmailMinLength - 1)]
    [InlineData(UserConfigurations.EmailMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPasswordIsNull()
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            null,
            null,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.PasswordMinLength - 1)]
    [InlineData(UserConfigurations.PasswordMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var invalidPassword = SharedTestUtilities.GetString(length);

        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            invalidPassword,
            invalidPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPasswordAndConfirmPasswordDoNotMatch()
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenFirstNameIsNull()
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            null,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.FirstNameMinLength - 1)]
    [InlineData(UserConfigurations.FirstNameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenLastNameIsNull()
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            null,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.LastNameMinLength - 1)]
    [InlineData(UserConfigurations.LastNameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenLastNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserEmailAlreadyTakenException_WhenEmailIsAlreadyTaken()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            existingUser.Email,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<UserEmailAlreadyTakenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNameAlreadyTakenException_WhenNameIsAlreadyTaken()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new AddUserCommand(
            existingUser.UserName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
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
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserCommandViewModel>(p => !string.IsNullOrEmpty(p.Id));
    }

    [Fact]
    public async Task SendAsync_ShouldRegisterUser_WhenUserIsValid()
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == response.Id &&
                              p.FirstName == UserTestUtilities.ValidAddFirstName &&
                              p.LastName == UserTestUtilities.ValidAddLastName &&
                              p.UserName == UserTestUtilities.ValidAddName &&
                              p.Email == UserTestUtilities.ValidAddEmail &&
                              PasswordHasher.Verify(UserTestUtilities.ValidAddPassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidAddProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldRegisterUser_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            null
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == response.Id &&
                              p.FirstName == UserTestUtilities.ValidAddFirstName &&
                              p.LastName == UserTestUtilities.ValidAddLastName &&
                              p.UserName == UserTestUtilities.ValidAddName &&
                              p.Email == UserTestUtilities.ValidAddEmail &&
                              PasswordHasher.Verify(UserTestUtilities.ValidAddPassword, p.PasswordHash) &&
                              p.ProfileImage == null);
    }

    [Fact]
    public async Task SendAsync_ShouldPublishUserCreatedEvent_WhenUserIsValid()
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserCreatedEvent>(m =>
                              m.Context.Message.Id == response.Id &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidAddFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidAddLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidAddName &&
                              m.Context.Message.Email == UserTestUtilities.ValidAddEmail &&
                              m.Context.Message.ProfileImage == UserTestUtilities.ValidAddProfileImage, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishUserCreatedEvent_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            null
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserCreatedEvent>(m =>
                              m.Context.Message.Id == response.Id &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidAddFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidAddLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidAddName &&
                              m.Context.Message.Email == UserTestUtilities.ValidAddEmail &&
                              m.Context.Message.ProfileImage == null, CancellationToken);

        // Assert
        result
            .Should()
            .BeTrue();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishUserConfirmEmailTokenCreatedEvent_WhenUserIsValid()
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            null
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(response.Id, CancellationToken);
        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserConfirmEmailTokenCreatedEvent>(m =>
                              m.Context.Message.Email == UserTestUtilities.ValidAddEmail);

        // Assert
        result
            .Should()
            .BeTrue();
    }
}
