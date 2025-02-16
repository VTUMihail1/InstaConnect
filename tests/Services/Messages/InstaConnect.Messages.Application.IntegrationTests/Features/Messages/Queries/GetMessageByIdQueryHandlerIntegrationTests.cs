using FluentAssertions;

using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetById;
using InstaConnect.Messages.Application.IntegrationTests.Features.Messages.Utilities;
using InstaConnect.Messages.Application.IntegrationTests.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Exceptions;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Users;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Application.IntegrationTests.Features.Messages.Queries;

public class GetMessageByIdQueryHandlerIntegrationTests : BaseMessageIntegrationTest
{
    public GetMessageByIdQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetMessageByIdQuery(
            null!,
            existingMessage.SenderId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

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
        var query = new GetMessageByIdQuery(
            SharedTestUtilities.GetString(length),
            existingMessage.SenderId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetMessageByIdQuery(
            existingMessage.Id,
            null!
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

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
        var query = new GetMessageByIdQuery(
            existingMessage.Id,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowMessageNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetMessageByIdQuery(
            MessageTestUtilities.InvalidId,
            existingMessage.SenderId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<MessageNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowAccountForbiddenException_WhenSenderIdDoesNotOwnMessage()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetMessageByIdQuery(
            existingMessage.Id,
            existingUser.Id
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetMessageByIdQuery(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageQueryViewModel>(m => m.Id == existingMessage.Id &&
                                          m.SenderId == existingMessage.SenderId &&
                                          m.SenderName == existingMessage.Sender.UserName &&
                                          m.SenderProfileImage == existingMessage.Sender.ProfileImage &&
                                          m.ReceiverId == existingMessage.ReceiverId &&
                                          m.ReceiverName == existingMessage.Receiver.UserName &&
                                          m.ReceiverProfileImage == existingMessage.Receiver.ProfileImage &&
                                          m.Content == existingMessage.Content);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenQueryIsValidAndIdCaseDoesntMatch()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var query = new GetMessageByIdQuery(
            SharedTestUtilities.GetNonCaseMatchingString(existingMessage.Id),
            existingMessage.SenderId
        );

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageQueryViewModel>(m => m.Id == existingMessage.Id &&
                                          m.SenderId == existingMessage.SenderId &&
                                          m.SenderName == existingMessage.Sender.UserName &&
                                          m.SenderProfileImage == existingMessage.Sender.ProfileImage &&
                                          m.ReceiverId == existingMessage.ReceiverId &&
                                          m.ReceiverName == existingMessage.Receiver.UserName &&
                                          m.ReceiverProfileImage == existingMessage.Receiver.ProfileImage &&
                                          m.Content == existingMessage.Content);
    }
}
