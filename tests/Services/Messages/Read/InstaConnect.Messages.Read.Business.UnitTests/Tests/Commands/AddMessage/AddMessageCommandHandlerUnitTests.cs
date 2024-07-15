﻿using FluentAssertions;
using InstaConnect.Messages.Write.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Write.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Write.Business.Models;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Messages.Write.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Messages.Write.Business.UnitTests.Tests.Commands.AddMessage;

public class AddMessageCommandHandlerUnitTests : BaseMessageUnitTest
{
    private readonly AddMessageCommandHandler _commandHandler;

    public AddMessageCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            MessageSender,
            EventPublisher,
            MessageRepository,
            InstaConnectMapper,
            GetUserByIdRequestClient);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenSenderIdIsInvalid()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = MessageUnitTestConfigurations.NON_EXISTING_USER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            Content = ValidReceiverName,
        };

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenReceiverIdIsInvalid()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.NON_EXISTING_USER_ID,
            Content = ValidReceiverName,
        };

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModel_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidReceiverName,
        };

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageViewModel>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID);
    }

    [Fact]
    public async Task Handle_ShouldReturn_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidReceiverName,
        };

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldAddMessageToRepository_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidReceiverName,
        };

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        MessageRepository
            .Received(1)
            .Add(Arg.Is<Message>(m => // m.Id == string.Empty &&
                                      m.SenderId == MessageUnitTestConfigurations.EXISTING_SENDER_ID &&
                                      m.ReceiverId == MessageUnitTestConfigurations.EXISTING_RECEIVER_ID &&
                                      m.Content == ValidReceiverName));
    }

    [Fact]
    public async Task Handle_ShouldSendMessageCreatedEvent_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidReceiverName,
        };

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EventPublisher
            .Received(1)
            .PublishAsync(Arg.Is<MessageCreatedEvent>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                                      m.Content == ValidReceiverName &&
                                                      m.ReceiverId == MessageUnitTestConfigurations.EXISTING_RECEIVER_ID &&
                                                      m.SenderId == MessageUnitTestConfigurations.EXISTING_SENDER_ID),
                     CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldSendMessageFromSender_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidReceiverName,
        };

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await MessageSender
            .Received(1)
            .SendMessageToUserAsync(Arg.Is<MessageSendModel>(m => m.Content == ValidReceiverName &&
                                                                  m.ReceiverId == MessageUnitTestConfigurations.EXISTING_RECEIVER_ID),
                                    CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidReceiverName,
        };

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
