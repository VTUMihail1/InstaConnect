using Bogus;
using FluentAssertions;
using InstaConnect.Messages.Write.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;
using InstaConnect.Messages.Write.Business.Utilities;
using InstaConnect.Messages.Write.Data.Abstractions;
using InstaConnect.Messages.Write.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.Message;
using InstaConnect.Shared.Business.Exceptions.User;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Write.Business.IntegrationTests.Tests.Commands;

public class UpdateMessageIntegrationTests : BaseMessageIntegrationTest
{
    public UpdateMessageIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task Send_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var command = new UpdateMessageCommand()
        {
            Id = null!,
            CurrentUserId = ValidCurrentUserId,
            Content = ValidContent
        };

        // Act
        var action = async () => await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task Send_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new UpdateMessageCommand()
        {
            Id = Faker.Random.AlphaNumeric(length),
            CurrentUserId = ValidCurrentUserId,
            Content = ValidContent
        };

        // Act
        var action = async () => await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task Send_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new UpdateMessageCommand()
        {
            Id = ValidId,
            CurrentUserId = null!,
            Content = ValidContent
        };

        // Act
        var action = async () => await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task Send_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new UpdateMessageCommand()
        {
            Id = ValidId,
            CurrentUserId = Faker.Random.AlphaNumeric(length),
            Content = ValidContent
        };

        // Act
        var action = async () => await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task Send_ShouldThrowBadRequestException_WhenContentIsNull()
    {
        // Arrange
        var command = new UpdateMessageCommand()
        {
            Id = ValidId,
            CurrentUserId = ValidCurrentUserId,
            Content = null!
        };

        // Act
        var action = async () => await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public async Task Send_ShouldThrowBadRequestException_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var command = new UpdateMessageCommand()
        {
            Id = MessageIntegrationTestConfigurations.NON_EXISTING_MESSAGE_ID,
            CurrentUserId = ValidCurrentUserId,
            Content = Faker.Random.AlphaNumeric(length)
        };

        // Act
        var action = async () => await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task Send_ShouldThrowMessageNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var command = new UpdateMessageCommand()
        {
            Id = MessageIntegrationTestConfigurations.NON_EXISTING_MESSAGE_ID,
            CurrentUserId = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            Content = ValidUpdateContent
        };

        // Act
        var action = async () => await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<MessageNotFoundException>();
    }

    [Fact]
    public async Task Send_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);
        var command = new UpdateMessageCommand()
        {
            Id = existingMessageId,
            CurrentUserId = MessageIntegrationTestConfigurations.EXISTING_SENDER_ID,
            Content = ValidContent
        };

        // Act
        var action = async () => await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountForbiddenException>();
    }

    [Fact]
    public async Task Send_ShouldUpdateMessage_WhenMessageIsValid()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);
        var command = new UpdateMessageCommand()
        {
            Id = existingMessageId,
            CurrentUserId = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            Content = ValidUpdateContent
        };

        // Act
        var response = await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        var message = await MessageRepository.GetByIdAsync(existingMessageId, CancellationToken);

        message
            .Should()
            .Match<Message>(m => m.Id == existingMessageId &&
                                 m.SenderId == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                                 m.ReceiverId == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                                 m.Content == ValidUpdateContent);
    }

    [Fact]
    public async Task Send_ShouldPublishMessageUpdatedEvent_WhenMessageIsValid()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);
        var command = new UpdateMessageCommand()
        {
            Id = existingMessageId,
            CurrentUserId = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            Content = ValidUpdateContent
        };

        // Act
        await InstaConnectSender.Send(command, CancellationToken);
        var result = await TestHarness.Published.Any<MessageUpdatedEvent>(m => m.Context.Message.Id == existingMessageId &&
                                                                               m.Context.Message.Content == ValidUpdateContent,
                                                                          CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
