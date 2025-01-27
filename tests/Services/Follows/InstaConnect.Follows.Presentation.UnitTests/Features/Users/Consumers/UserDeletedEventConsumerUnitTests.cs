using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Domain.Features.Users.Models.Entities;
using InstaConnect.Follows.Presentation.Features.Users.Consumers;
using InstaConnect.Follows.Presentation.UnitTests.Features.Users.Utilities;
using InstaConnect.Shared.Application.Contracts.Users;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Follows.Presentation.UnitTests.Features.Users.Consumers;

public class UserDeletedEventConsumerUnitTests : BaseUserUnitTest
{
    private readonly UserDeletedEventConsumer _userDeletedEventConsumer;
    private readonly ConsumeContext<UserDeletedEvent> _userDeletedEventConsumeContext;

    public UserDeletedEventConsumerUnitTests()
    {
        _userDeletedEventConsumer = new(
            UnitOfWork,
            UserWriteRepository);

        _userDeletedEventConsumeContext = Substitute.For<ConsumeContext<UserDeletedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldCallGetUserByIdAsyncMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userDeletedEvent = new UserDeletedEvent(UserTestUtilities.InvalidId);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(UserTestUtilities.InvalidId, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotDeleteMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userDeletedEvent = new UserDeletedEvent(UserTestUtilities.InvalidId);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(0)
            .Delete(Arg.Any<User>());
    }

    [Fact]
    public async Task Consume_ShouldNotCallSaveChangesAsync_WhenUserIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userDeletedEvent = new UserDeletedEvent(UserTestUtilities.InvalidId);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(0)
            .SaveChangesAsync(CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldGetUserById_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userDeletedEvent = new UserDeletedEvent(existingUser.Id);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(existingUser.Id, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldAddUserToRepository_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userDeletedEvent = new UserDeletedEvent(existingUser.Id);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(1)
            .Delete(Arg.Is<User>(m => m.Id == existingUser.Id &&
                                   m.UserName == UserTestUtilities.ValidName &&
                                   m.FirstName == UserTestUtilities.ValidFirstName &&
                                   m.LastName == UserTestUtilities.ValidLastName &&
                                   m.Email == UserTestUtilities.ValidEmail &&
                                   m.ProfileImage == UserTestUtilities.ValidProfileImage));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userDeletedEvent = new UserDeletedEvent(existingUser.Id);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
