using FluentAssertions;

using InstaConnect.Messages.Application.Features.Messages.Commands.Delete;
using InstaConnect.Messages.Application.IntegrationTests.Features.Messages.Utilities;
using InstaConnect.Messages.Application.IntegrationTests.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Exceptions;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Users;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Application.IntegrationTests.Features.Messages.Commands;

public class DeleteMessageIntegrationTests : BaseMessageIntegrationTest
{
    public DeleteMessageIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new DeleteMessageCommand(
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
    [InlineData(MessageConfigurations.IdMinLength - 1)]
    [InlineData(MessageConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new DeleteMessageCommand(
            SharedTestUtilities.GetString(length),
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
        var command = new DeleteMessageCommand(
            existingMessage.Id,
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
        var command = new DeleteMessageCommand(
            existingMessage.Id,
            SharedTestUtilities.GetString(length)
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
        var command = new DeleteMessageCommand(
            MessageTestUtilities.InvalidId,
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
        var command = new DeleteMessageCommand(
            existingMessage.Id,
            existingUser.Id
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteMessage_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new DeleteMessageCommand(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        var message = await MessageWriteRepository.GetByIdAsync(existingMessage.Id, CancellationToken);

        message
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteMessage_WhenMessageIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var command = new DeleteMessageCommand(
            SharedTestUtilities.GetNonCaseMatchingString(existingMessage.Id),
            existingMessage.SenderId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        var message = await MessageWriteRepository.GetByIdAsync(existingMessage.Id, CancellationToken);

        message
            .Should()
            .BeNull();
    }
}
