using System.Net;

using FluentAssertions;

using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;
using InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Utilities;
using InstaConnect.Messages.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Controllers.v1;

public class GetMessageByIdFunctionalTests : BaseMessageFunctionalTest
{
    public GetMessageByIdFunctionalTests(MessagesWebApplicationFactory messagesWebApplicationFactory) : base(messagesWebApplicationFactory)
    {

    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetMessageByIdRequest(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        var response = await MessagesClient.GetByIdStatusCodeUnathorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(MessageConfigurations.IdMinLength - 1)]
    [InlineData(MessageConfigurations.IdMaxLength + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetMessageByIdRequest(
            SharedTestUtilities.GetString(length),
            existingMessage.SenderId
        );

        // Act
        var response = await MessagesClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIsNull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetMessageByIdRequest(
            existingMessage.Id,
            null
        );

        // Act
        var response = await MessagesClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetMessageByIdRequest(
            existingMessage.Id,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await MessagesClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetMessageByIdRequest(
            MessageTestUtilities.InvalidId,
            existingMessage.SenderId
        );

        // Act
        var response = await MessagesClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdCurrentUserIdDoesNotOwnMessage()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetMessageByIdRequest(
            existingMessage.Id,
            existingUser.Id
        );

        // Act
        var response = await MessagesClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetMessageByIdRequest(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        var response = await MessagesClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMessageViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetMessageByIdRequest(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        var response = await MessagesClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageQueryResponse>(m => m.Id == existingMessage.Id &&
                                 m.Content == existingMessage.Content &&
                                 m.SenderId == existingMessage.SenderId &&
                                 m.SenderName == existingMessage.Sender.UserName &&
                                 m.SenderProfileImage == existingMessage.Sender.ProfileImage &&
                                 m.ReceiverId == existingMessage.ReceiverId &&
                                 m.ReceiverName == existingMessage.Receiver.UserName &&
                                 m.ReceiverProfileImage == existingMessage.Receiver.ProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMessageViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetMessageByIdRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingMessage.Id),
            existingMessage.SenderId
        );

        // Act
        var response = await MessagesClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageQueryResponse>(m => m.Id == existingMessage.Id &&
                                 m.Content == existingMessage.Content &&
                                 m.SenderId == existingMessage.SenderId &&
                                 m.SenderName == existingMessage.Sender.UserName &&
                                 m.SenderProfileImage == existingMessage.Sender.ProfileImage &&
                                 m.ReceiverId == existingMessage.ReceiverId &&
                                 m.ReceiverName == existingMessage.Receiver.UserName &&
                                 m.ReceiverProfileImage == existingMessage.Receiver.ProfileImage);
    }
}
