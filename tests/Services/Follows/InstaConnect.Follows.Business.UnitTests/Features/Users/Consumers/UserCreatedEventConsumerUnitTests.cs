using InstaConnect.Follows.Business.Features.Users.Consumers;
using InstaConnect.Follows.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Users.Consumers;

public class UserCreatedEventConsumerUnitTests : BaseUserUnitTest
{
    private readonly UserCreatedEventConsumer _userCreatedEventConsumer;
    private readonly ConsumeContext<UserCreatedEvent> _userCreatedEventConsumeContext;

    public UserCreatedEventConsumerUnitTests()
    {
        _userCreatedEventConsumer = new(
            UnitOfWork,
            InstaConnectMapper,
            UserWriteRepository);

        _userCreatedEventConsumeContext = Substitute.For<ConsumeContext<UserCreatedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldCallGetByIdAsyncMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var userCreatedEvent = new UserCreatedEvent(
            UserTestUtilities.ValidCurrentUserId,
            UserTestUtilities.ValidUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(UserTestUtilities.ValidCurrentUserId, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotAddMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var userCreatedEvent = new UserCreatedEvent(
            UserTestUtilities.ValidCurrentUserId,
            UserTestUtilities.ValidUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(0)
            .Add(Arg.Any<User>());
    }

    [Fact]
    public async Task Consume_ShouldNotCallSaveChangesAsync_WhenUserIdIsInvalid()
    {
        // Arrange
        var userCreatedEvent = new UserCreatedEvent(
            UserTestUtilities.ValidCurrentUserId,
            UserTestUtilities.ValidUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(0)
            .SaveChangesAsync(CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldGetById_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userCreatedEvent = new UserCreatedEvent(
            UserTestUtilities.InvalidUserId,
            UserTestUtilities.ValidUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(UserTestUtilities.InvalidUserId, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldAddUserToRepository_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userCreatedEvent = new UserCreatedEvent(
            UserTestUtilities.InvalidUserId,
            UserTestUtilities.ValidUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(1)
            .Add(Arg.Is<User>(m => m.Id == UserTestUtilities.InvalidUserId &&
                                   m.UserName == UserTestUtilities.ValidUserName &&
                                   m.FirstName == UserTestUtilities.ValidUserFirstName &&
                                   m.LastName == UserTestUtilities.ValidUserLastName &&
                                   m.Email == UserTestUtilities.ValidUserEmail &&
                                   m.ProfileImage == UserTestUtilities.ValidUserProfileImage));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userCreatedEvent = new UserCreatedEvent(
            UserTestUtilities.InvalidUserId,
            UserTestUtilities.ValidUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
