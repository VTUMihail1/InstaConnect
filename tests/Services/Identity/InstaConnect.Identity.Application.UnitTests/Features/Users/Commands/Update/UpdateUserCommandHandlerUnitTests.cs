using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Application.Models;
using InstaConnect.Identity.Application.Features.Users.Commands.Update;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.Update;

public class UpdateUserCommandHandlerUnitTests : BaseUserUnitTest
{
    private readonly UpdateUserCommandHandler _commandHandler;

    public UpdateUserCommandHandlerUnitTests()
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
        var command = new UpdateUserCommand(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
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
        var existingUser = CreateUser();
        var existingUserWithTakenName = CreateUser();
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            existingUserWithTakenName.UserName,
            UserTestUtilities.ValidUpdateFormFile
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
        var existingUser = CreateUser();
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            null
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
        var existingUser = CreateUser();
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ImageHandler
            .Received(1)
            .UploadAsync(Arg.Is<ImageUploadModel>(u => u.FormFile == UserTestUtilities.ValidUpdateFormFile), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldUpdateTheUserToTheRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        UserWriteRepository
            .Received(1)
            .Update(Arg.Is<User>(u => u.Id == existingUser.Id &&
                                      u.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                                      u.LastName == UserTestUtilities.ValidUpdateLastName &&
                                      u.UserName == UserTestUtilities.ValidUpdateName &&
                                      u.Email == existingUser.Email &&
                                      u.ProfileImage == UserTestUtilities.ValidUpdateProfileImage));
    }

    [Fact]
    public async Task Handle_ShouldPublishUserUpdatedEvent_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EventPublisher
            .Received(1)
            .PublishAsync(Arg.Is<UserUpdatedEvent>(u => u.Id == existingUser.Id &&
                                                        u.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                                                        u.LastName == UserTestUtilities.ValidUpdateLastName &&
                                                        u.UserName == UserTestUtilities.ValidUpdateName &&
                                                        u.Email == existingUser.Email &&
                                                        u.ProfileImage == UserTestUtilities.ValidUpdateProfileImage), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallUnitOfWorkCommit_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
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
        var existingUser = CreateUser();
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserCommandViewModel>(u => u.Id == existingUser.Id);
    }

    [Fact]
    public async Task Handle_ShouldReturnUserCommandViewModel_WhenRequestIsValidAndNameIsNotTakenAndNotDefault()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new UpdateUserCommand(
            existingUser.Id,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            existingUser.UserName,
            UserTestUtilities.ValidUpdateFormFile
        );

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserCommandViewModel>(u => u.Id == existingUser.Id);
    }
}
