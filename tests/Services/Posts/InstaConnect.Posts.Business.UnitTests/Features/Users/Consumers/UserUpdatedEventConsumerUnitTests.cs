using InstaConnect.Posts.Business.Features.Users.Consumers;
using InstaConnect.Posts.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.Users.Consumers;

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
        var userUpdatedEvent = new UserUpdatedEvent(
            UserTestUtilities.InvalidUserId,
            UserTestUtilities.ValidUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(UserTestUtilities.InvalidUserId, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotAddMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var userUpdatedEvent = new UserUpdatedEvent(
            UserTestUtilities.InvalidUserId,
            UserTestUtilities.ValidUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

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
        var userUpdatedEvent = new UserUpdatedEvent(
            UserTestUtilities.InvalidUserId,
            UserTestUtilities.ValidUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

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
        var userUpdatedEvent = new UserUpdatedEvent(
            UserTestUtilities.ValidCurrentUserId,
            UserTestUtilities.ValidUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(UserTestUtilities.ValidCurrentUserId, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldUpdateUserToRepository_WhenUserUpdatedEventIsValid()
    {
        // Arrange
        var userUpdatedEvent = new UserUpdatedEvent(
            UserTestUtilities.ValidCurrentUserId,
            UserTestUtilities.ValidUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(1)
            .Update(Arg.Is<User>(m => m.Id == UserTestUtilities.ValidCurrentUserId &&
                                   m.FirstName == UserTestUtilities.ValidUserFirstName &&
                                   m.LastName == UserTestUtilities.ValidUserLastName &&
                                   m.UserName == UserTestUtilities.ValidUserName &&
                                   m.Email == UserTestUtilities.ValidUserEmail &&
                                   m.ProfileImage == UserTestUtilities.ValidUserProfileImage));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userUpdatedEvent = new UserUpdatedEvent(
            UserTestUtilities.ValidCurrentUserId,
            UserTestUtilities.ValidUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
