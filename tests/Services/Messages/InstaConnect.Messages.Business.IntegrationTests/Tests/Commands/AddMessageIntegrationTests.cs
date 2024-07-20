using Bogus;
using FluentAssertions;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.IntegrationTests.Utilities;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.User;

namespace InstaConnect.Messages.Business.IntegrationTests.Tests.Commands;
public class AddMessageIntegrationTests : BaseMessageIntegrationTest
{
    public AddMessageIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = null!,
            ReceiverId = ValidReceiverId,
            Content = ValidAddContent
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
        var command = new AddMessageCommand()
        {
            CurrentUserId = Faker.Random.AlphaNumeric(length),
            ReceiverId = ValidReceiverId,
            Content = ValidReceiverId
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenReceiverIdIsNull()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = null!,
            Content = ValidAddContent
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = Faker.Random.AlphaNumeric(length),
            Content = ValidAddContent
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenContentIsNull()
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            Content = null!
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddMessageCommand()
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            Content = Faker.Random.AlphaNumeric(length)
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand()
        {
            CurrentUserId = MessageIntegrationTestConfigurations.NON_EXISTING_USER_ID,
            ReceiverId = existingReceiverId,
            Content = ValidAddContent
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenReceiverIdIsInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand()
        {
            CurrentUserId = existingSenderId,
            ReceiverId = MessageIntegrationTestConfigurations.NON_EXISTING_USER_ID,
            Content = ValidAddContent
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldAddMessage_WhenMessageIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand()
        {
            CurrentUserId = existingSenderId,
            ReceiverId = existingReceiverId,
            Content = ValidAddContent
        };

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var message = await MessageWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        message
            .Should()
            .Match<Message>(m => m.Id == response.Id &&
                                 m.SenderId == existingSenderId &&
                                 m.ReceiverId == existingReceiverId &&
                                 m.Content == ValidAddContent);
    }
}
