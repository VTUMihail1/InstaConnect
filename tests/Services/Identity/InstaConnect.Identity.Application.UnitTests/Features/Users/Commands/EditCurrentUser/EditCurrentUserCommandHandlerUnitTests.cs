using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Commands.EditCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Models;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.EditCurrentUser;

public class EditCurrentUserCommandHandlerUnitTests : BaseUserUnitTest
{
    private readonly EditCurrentUserCommandHandler _commandHandler;

    public EditCurrentUserCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            ImageHandler,
            EventPublisher,
            InstaConnectMapper,
            UserWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var command = new EditCurrentUserCommand(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNameAlreadyTakenException_WhenNameIsInvalid()
    {
        // Arrange
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidTakenName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNameAlreadyTakenException>();
    }

    [Fact]
    public async Task Handle_ShouldNotCallTheImageHandler_WhenRequestIsValidAndProfileImageIsNull()
    {
        // Arrange
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            null!
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ImageHandler
            .Received(0)
            .UploadAsync(Arg.Any<ImageUploadModel>(), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheImageHandler_WhenRequestIsValid()
    {
        // Arrange
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ImageHandler
            .Received(1)
            .UploadAsync(Arg.Is<ImageUploadModel>(u => u.FormFile == UserTestUtilities.ValidFormFile), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldUpdateTheUserToTheRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        UserWriteRepository
            .Received(1)
            .Update(Arg.Is<User>(u => u.Id == UserTestUtilities.ValidId &&
                                      u.FirstName == UserTestUtilities.ValidFirstName &&
                                      u.LastName == UserTestUtilities.ValidLastName &&
                                      u.UserName == UserTestUtilities.ValidName &&
                                      u.Email == UserTestUtilities.ValidEmail &&
                                      u.ProfileImage == UserTestUtilities.ValidProfileImage));
    }

    [Fact]
    public async Task Handle_ShouldPublishUserUpdatedEvent_WhenRequestIsValid()
    {
        // Arrange
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EventPublisher
            .Received(1)
            .PublishAsync(Arg.Is<UserUpdatedEvent>(u => u.Id == UserTestUtilities.ValidId &&
                                                        u.FirstName == UserTestUtilities.ValidFirstName &&
                                                        u.LastName == UserTestUtilities.ValidLastName &&
                                                        u.UserName == UserTestUtilities.ValidName &&
                                                        u.Email == UserTestUtilities.ValidEmail &&
                                                        u.ProfileImage == UserTestUtilities.ValidProfileImage), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallUnitOfWorkCommit_WhenRequestIsValid()
    {
        // Arrange
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnUserCommandViewModel_WhenRequestIsValid()
    {
        // Arrange
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserCommandViewModel>(u => u.Id == UserTestUtilities.ValidId);
    }

    [Fact]
    public async Task Handle_ShouldReturnUserCommandViewModel_WhenRequestIsValidAndNameIsNotTakenAndNotDefault()
    {
        // Arrange
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.InvalidName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserCommandViewModel>(u => u.Id == UserTestUtilities.ValidId);
    }
}
