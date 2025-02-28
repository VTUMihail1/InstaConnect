using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Messages.Application.Features.Messages.Commands.Update;
using InstaConnect.Messages.Common.Tests.Features.Messages.Utilities;

namespace InstaConnect.Messages.Application.IntegrationTests.Features.Messages.Commands;

public class UpdateMessageIntegrationTests : BaseMessageIntegrationTest
{
    public UpdateMessageIntegrationTests(MessagesWebApplicationFactory messagesWebApplicationFactory) : base(messagesWebApplicationFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new UpdateMessageCommand(
            null!,
            MessageTestUtilities.ValidUpdateContent,
            existingMessage.SenderId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageConfigurations.IdMinLength - 1)]
    [InlineData(MessageConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new UpdateMessageCommand(
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidUpdateContent,
            existingMessage.SenderId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            MessageTestUtilities.ValidUpdateContent,
            null!
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            MessageTestUtilities.ValidUpdateContent,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenContentIsNull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            null!,
            existingMessage.SenderId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageConfigurations.ContentMinLength - 1)]
    [InlineData(MessageConfigurations.ContentMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            SharedTestUtilities.GetString(length),
            existingMessage.SenderId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowMessageNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new UpdateMessageCommand(
            MessageTestUtilities.InvalidId,
            MessageTestUtilities.ValidUpdateContent,
            existingMessage.SenderId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<MessageNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            MessageTestUtilities.ValidUpdateContent,
            existingUser.Id
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldUpdateMessage_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            MessageTestUtilities.ValidUpdateContent,
            existingMessage.SenderId
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var message = await MessageWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        message
            .Should()
            .Match<Message>(m => m.Id == existingMessage.Id &&
                                 m.SenderId == existingMessage.SenderId &&
                                 m.ReceiverId == existingMessage.ReceiverId &&
                                 m.Content == MessageTestUtilities.ValidUpdateContent);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdateMessage_WhenMessageIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new UpdateMessageCommand(
            SharedTestUtilities.GetNonCaseMatchingString(existingMessage.Id),
            MessageTestUtilities.ValidUpdateContent,
            existingMessage.SenderId
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var message = await MessageWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        message
            .Should()
            .Match<Message>(m => m.Id == existingMessage.Id &&
                                 m.SenderId == existingMessage.SenderId &&
                                 m.ReceiverId == existingMessage.ReceiverId &&
                                 m.Content == MessageTestUtilities.ValidUpdateContent);
    }
}
