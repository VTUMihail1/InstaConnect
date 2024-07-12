using Bogus;
using FluentAssertions;
using InstaConnect.Messages.Write.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;
using InstaConnect.Messages.Write.Business.Utilities;
using InstaConnect.Messages.Write.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.User;

namespace InstaConnect.Messages.Write.Business.IntegrationTests.Tests.Commands;
public class AddMessageIntegrationTests : BaseMessageIntegrationTest
{
    public AddMessageIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task Send_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = null!,
            ReceiverId = ValidReceiverId,
            Content = ValidAddContent
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
        var command = new AddMessageCommand()
        {
            CurrentUserId = Faker.Random.AlphaNumeric(length),
            ReceiverId = ValidReceiverId,
            Content = ValidReceiverId
        };

        // Act
        var action = async () => await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task Send_ShouldThrowBadRequestException_WhenReceiverIdIsNull()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = null!,
            Content = ValidAddContent
        };

        // Act
        var action = async () => await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + 1)]
    public async Task Send_ShouldThrowBadRequestException_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = Faker.Random.AlphaNumeric(length),
            Content = ValidAddContent
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
        var command = new AddMessageCommand()
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
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
        var command = new AddMessageCommand()
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            Content = Faker.Random.AlphaNumeric(length)
        };

        // Act
        var action = async () => await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task Send_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = MessageIntegrationTestConfigurations.NON_EXISTING_USER_ID,
            ReceiverId = MessageIntegrationTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidAddContent
        };

        // Act
        var action = async () => await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Send_ShouldThrowUserNotFoundException_WhenReceiverIdIsInvalid()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = MessageIntegrationTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageIntegrationTestConfigurations.NON_EXISTING_USER_ID,
            Content = ValidAddContent
        };

        // Act
        var action = async () => await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Send_ShouldAddMessage_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = MessageIntegrationTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageIntegrationTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidAddContent
        };

        // Act
        var response = await InstaConnectSender.Send(command, CancellationToken);

        // Assert
        var message = await MessageRepository.GetByIdAsync(response.Id, CancellationToken);

        message
            .Should()
            .Match<Message>(m => m.Id == response.Id &&
                                 m.SenderId == MessageIntegrationTestConfigurations.EXISTING_SENDER_ID &&
                                 m.ReceiverId == MessageIntegrationTestConfigurations.EXISTING_RECEIVER_ID &&
                                 m.Content == ValidAddContent);
    }

    [Fact]
    public async Task Send_ShouldPublishMessageCreatedEvent_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = MessageIntegrationTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageIntegrationTestConfigurations.EXISTING_RECEIVER_ID,
            Content = ValidAddContent
        };

        // Act
        var response = await InstaConnectSender.Send(command, CancellationToken);
        var result = await TestHarness.Published.Any<MessageCreatedEvent>(m => m.Context.Message.Id == response.Id &&
                                                                  m.Context.Message.SenderId == MessageIntegrationTestConfigurations.EXISTING_SENDER_ID &&
                                                                  m.Context.Message.ReceiverId == MessageIntegrationTestConfigurations.EXISTING_RECEIVER_ID &&
                                                                  m.Context.Message.Content == ValidAddContent,
                                                             CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
