﻿using InstaConnect.Posts.Business.Features.Users.Consumers;
using InstaConnect.Posts.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.Users.Consumers;

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
        var userDeletedEvent = new UserDeletedEvent(InvalidUserId);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(InvalidUserId, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotDeleteMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var userDeletedEvent = new UserDeletedEvent(InvalidUserId);

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
        var userDeletedEvent = new UserDeletedEvent(InvalidUserId);

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
        var userDeletedEvent = new UserDeletedEvent(ValidCurrentUserId);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(ValidCurrentUserId, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldAddUserToRepository_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userDeletedEvent = new UserDeletedEvent(ValidCurrentUserId);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(1)
            .Delete(Arg.Is<User>(m => m.Id == ValidCurrentUserId &&
                                   m.UserName == ValidUserName &&
                                   m.FirstName == ValidUserFirstName &&
                                   m.LastName == ValidUserLastName &&
                                   m.Email == ValidUserEmail &&
                                   m.ProfileImage == ValidUserProfileImage));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userDeletedEvent = new UserDeletedEvent(ValidCurrentUserId);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}