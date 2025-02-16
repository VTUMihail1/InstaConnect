using System.Net;

using FluentAssertions;

using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;
using InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Utilities;
using InstaConnect.Messages.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Controllers.v1;

public class UpdateMessageFunctionalTests : BaseMessageFunctionalTest
{
    public UpdateMessageFunctionalTests(MessagesWebApplicationFactory messagesWebApplicationFactory) : base(messagesWebApplicationFactory)
    {

    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new UpdateMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId,
            new(MessageTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await MessagesClient.UpdateStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(MessageConfigurations.IdMinLength - 1)]
    [InlineData(MessageConfigurations.IdMaxLength + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenIdIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new UpdateMessageRequest(
            SharedTestUtilities.GetString(length),
            existingMessage.SenderId,
            new(MessageTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await MessagesClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenContentIsNull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new UpdateMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId,
            new(null)
        );

        // Act
        var response = await MessagesClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageConfigurations.ContentMinLength - 1)]
    [InlineData(MessageConfigurations.ContentMaxLength + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new UpdateMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId,
            new(SharedTestUtilities.GetString(length))
        );

        // Act
        var response = await MessagesClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new UpdateMessageRequest(
            existingMessage.Id,
            null,
            new(MessageTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await MessagesClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new UpdateMessageRequest(
            existingMessage.Id,
            SharedTestUtilities.GetString(length),
            new(MessageTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await MessagesClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new UpdateMessageRequest(
            MessageTestUtilities.InvalidId,
            existingMessage.SenderId,
            new(MessageTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await MessagesClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnTheMessageIdInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new UpdateMessageRequest(
            existingMessage.Id,
            existingUser.Id,
            new(MessageTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await MessagesClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new UpdateMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId,
            new(MessageTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await MessagesClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new UpdateMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId,
            new(MessageTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await MessagesClient.UpdateAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageCommandResponse>(m => m.Id == existingMessage.Id);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateMessage_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new UpdateMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId,
            new(MessageTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await MessagesClient.UpdateAsync(request, CancellationToken);

        var message = await MessageWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        message
            .Should()
            .Match<Message>(m => m.Id == existingMessage.Id &&
                                 m.SenderId == existingMessage.SenderId &&
                                 m.ReceiverId == existingMessage.ReceiverId &&
                                 m.Content == MessageTestUtilities.ValidUpdateContent);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateMessage_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new UpdateMessageRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingMessage.Id),
            existingMessage.SenderId,
            new(MessageTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await MessagesClient.UpdateAsync(request, CancellationToken);

        var message = await MessageWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        message
            .Should()
            .Match<Message>(m => m.Id == existingMessage.Id &&
                                 m.SenderId == existingMessage.SenderId &&
                                 m.ReceiverId == existingMessage.ReceiverId &&
                                 m.Content == MessageTestUtilities.ValidUpdateContent);
    }
}
