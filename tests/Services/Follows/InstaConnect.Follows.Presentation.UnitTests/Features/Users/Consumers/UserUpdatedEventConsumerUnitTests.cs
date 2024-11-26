using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Domain.Features.Users.Models.Entities;
using InstaConnect.Follows.Presentation.Features.Users.Consumers;
using InstaConnect.Follows.Presentation.UnitTests.Features.Users.Utilities;
using InstaConnect.Shared.Application.Contracts.Users;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Follows.Presentation.UnitTests.Features.Users.Consumers;

public class UserUpdatedEventConsumerUnitTests : BaseUserUnitTest
{
    private readonly UserUpdatedEventConsumer _userUpdatedEventConsumer;
    private readonly ConsumeContext<UserUpdatedEvent> _userUpdatedEventConsumeContext;

    public UserUpdatedEventConsumerUnitTests()
    {
        _userUpdatedEventConsumer = new(
            UnitOfWork,
            InstaConnectMapper,
            UserWriteRepository);

        _userUpdatedEventConsumeContext = Substitute.For<ConsumeContext<UserUpdatedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldCallGetUserByIdAsyncMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var existingUserId = CreateUser();
        var userUpdatedEvent = new UserUpdatedEvent(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(UserTestUtilities.InvalidId, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotAddMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var existingUserId = CreateUser();
        var userUpdatedEvent = new UserUpdatedEvent(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(0)
            .Add(Arg.Any<User>());
    }

    [Fact]
    public async Task Consume_ShouldNotCallSaveChangesAsync_WhenUserIdIsInvalid()
    {
        // Arrange
        var existingUserId = CreateUser();
        var userUpdatedEvent = new UserUpdatedEvent(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(0)
            .SaveChangesAsync(CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldGetUserById_WhenUserUpdatedEventIsValid()
    {
        // Arrange
        var existingUserId = CreateUser();
        var userUpdatedEvent = new UserUpdatedEvent(
            existingUserId,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(existingUserId, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldUpdateUserToRepository_WhenUserUpdatedEventIsValid()
    {
        // Arrange
        var existingUserId = CreateUser();
        var userUpdatedEvent = new UserUpdatedEvent(
            existingUserId,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(1)
            .Update(Arg.Is<User>(m => m.Id == existingUserId &&
                                   m.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                                   m.LastName == UserTestUtilities.ValidUpdateLastName &&
                                   m.UserName == UserTestUtilities.ValidUpdateName &&
                                   m.Email == UserTestUtilities.ValidEmail &&
                                   m.ProfileImage == UserTestUtilities.ValidUpdateProfileImage));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var existingUserId = CreateUser();
        var userUpdatedEvent = new UserUpdatedEvent(
            existingUserId,
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
