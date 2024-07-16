using Bogus;
using FluentAssertions;
using InstaConnect.Messages.Write.Business.Commands.Messages.DeleteMessage;
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

public class DeleteMessageIntegrationTests : BaseMessageIntegrationTest
{
    public DeleteMessageIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var command = new DeleteMessageCommand()
        {
            Id = null!,
            CurrentUserId = ValidCurrentUserId,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new DeleteMessageCommand()
        {
            Id = Faker.Random.AlphaNumeric(length),
            CurrentUserId = ValidCurrentUserId,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new DeleteMessageCommand()
        {
            Id = ValidId,
            CurrentUserId = null!,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new DeleteMessageCommand()
        {
            Id = ValidId,
            CurrentUserId = Faker.Random.AlphaNumeric(length),
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowMessageNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var command = new DeleteMessageCommand()
        {
            Id = MessageIntegrationTestConfigurations.NON_EXISTING_MESSAGE_ID,
            CurrentUserId = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<MessageNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);
        var command = new DeleteMessageCommand()
        {
            Id = existingMessageId,
            CurrentUserId = MessageIntegrationTestConfigurations.EXISTING_SENDER_ID,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteMessage_WhenMessageIsValid()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);
        var command = new DeleteMessageCommand()
        {
            Id = existingMessageId,
            CurrentUserId = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
        };

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        var message = await MessageRepository.GetByIdAsync(existingMessageId, CancellationToken);

        message
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishMessageDeletedEvent_WhenMessageIsValid()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);
        var command = new DeleteMessageCommand()
        {
            Id = existingMessageId,
            CurrentUserId = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
        };

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var result = await TestHarness.Published.Any<MessageDeletedEvent>(m => m.Context.Message.Id == existingMessageId, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
