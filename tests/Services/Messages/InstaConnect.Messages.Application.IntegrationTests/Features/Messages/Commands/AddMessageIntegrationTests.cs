using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Messages.Application.Features.Messages.Commands.Add;
using InstaConnect.Messages.Common.Tests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Messages.Application.IntegrationTests.Features.Messages.Commands;
public class AddMessageIntegrationTests : BaseMessageIntegrationTest
{
    public AddMessageIntegrationTests(MessagesWebApplicationFactory messagesWebApplicationFactory) : base(messagesWebApplicationFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            null!,
            existingReceiver.Id,
            MessageTestUtilities.ValidAddContent
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
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            SharedTestUtilities.GetString(length),
            existingReceiver.Id,
            MessageTestUtilities.ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenReceiverIdIsNull()
    {
        // Arrange
        var existingSender = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            existingSender.Id,
            null!,
            MessageTestUtilities.ValidAddContent
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
    public async Task SendAsync_ShouldThrowValidationException_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingSender = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            existingSender.Id,
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidAddContent
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
        var existingSender = await CreateUserAsync(CancellationToken);
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            existingSender.Id,
            existingReceiver.Id,
            null!
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
        var existingSender = await CreateUserAsync(CancellationToken);
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            existingSender.Id,
            existingReceiver.Id,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            UserTestUtilities.InvalidId,
            existingReceiver.Id,
            MessageTestUtilities.ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenReceiverIdIsInvalid()
    {
        // Arrange
        var existingSender = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            existingSender.Id,
            UserTestUtilities.InvalidId,
            MessageTestUtilities.ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldAddMessage_WhenMessageIsValid()
    {
        // Arrange
        var existingSender = await CreateUserAsync(CancellationToken);
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            existingSender.Id,
            existingReceiver.Id,
            MessageTestUtilities.ValidAddContent
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var message = await MessageWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        message
            .Should()
            .Match<Message>(m => m.Id == response.Id &&
                                 m.SenderId == existingSender.Id &&
                                 m.ReceiverId == existingReceiver.Id &&
                                 m.Content == MessageTestUtilities.ValidAddContent);
    }
}
