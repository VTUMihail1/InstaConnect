using FluentAssertions;
using InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccount;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Models;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Commands.EditCurrentAccount;

public class EditCurrentAccountCommandHandlerUnitTests : BaseAccountUnitTest
{
    private readonly EditCurrentAccountCommandHandler _commandHandler;

    public EditCurrentAccountCommandHandlerUnitTests()
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
        var command = new EditCurrentAccountCommand(
            InvalidId,
            ValidFirstName,
            ValidLastName,
            ValidName,
            ValidFormFile
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountNameAlreadyTakenException_WhenNameIsInvalid()
    {
        // Arrange
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            ValidLastName,
            ValidTakenName,
            ValidFormFile
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountNameAlreadyTakenException>();
    }

    [Fact]
    public async Task Handle_ShouldNotCallTheImageHandler_WhenRequestIsValidAndProfileImageIsNull()
    {
        // Arrange
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            ValidLastName,
            ValidName,
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
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            ValidLastName,
            ValidName,
            ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ImageHandler
            .Received(1)
            .UploadAsync(Arg.Is<ImageUploadModel>(u => u.FormFile == ValidFormFile), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldUpdateTheUserToTheRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            ValidLastName,
            ValidName,
            ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        UserWriteRepository
            .Received(1)
            .Update(Arg.Is<User>(u => u.Id == ValidId &&
                                      u.FirstName == ValidFirstName &&
                                      u.LastName == ValidLastName &&
                                      u.UserName == ValidName &&
                                      u.Email == ValidEmail &&
                                      u.ProfileImage == ValidProfileImage));
    }

    [Fact]
    public async Task Handle_ShouldPublishUserUpdatedEvent_WhenRequestIsValid()
    {
        // Arrange
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            ValidLastName,
            ValidName,
            ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EventPublisher
            .Received(1)
            .PublishAsync(Arg.Is<UserUpdatedEvent>(u => u.Id == ValidId &&
                                                        u.FirstName == ValidFirstName &&
                                                        u.LastName == ValidLastName &&
                                                        u.UserName == ValidName &&
                                                        u.Email == ValidEmail &&
                                                        u.ProfileImage == ValidProfileImage), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallUnitOfWorkCommit_WhenRequestIsValid()
    {
        // Arrange
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            ValidLastName,
            ValidName,
            ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnAccountCommandViewModel_WhenRequestIsValid()
    {
        // Arrange
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            ValidLastName,
            ValidName,
            ValidFormFile
        );

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<AccountCommandViewModel>(u => u.Id == ValidId);
    }

    [Fact]
    public async Task Handle_ShouldReturnAccountCommandViewModel_WhenRequestIsValidAndNameIsNotTakenAndNotDefault()
    {
        // Arrange
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            ValidLastName,
            InvalidName,
            ValidFormFile
        );

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<AccountCommandViewModel>(u => u.Id == ValidId);
    }
}
