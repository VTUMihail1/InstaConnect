﻿using InstaConnect.Messages.Application.Features.Messages.Queries.GetById;

namespace InstaConnect.Messages.Presentation.UnitTests.Features.Messages.Controllers.v1;

public class GetMessageByIdUnitTests : BaseMessageUnitTest
{
    private readonly MessageController _messageController;

    public GetMessageByIdUnitTests()
    {
        _messageController = new(
            InstaConnectSender,
            InstaConnectMapper);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new GetMessageByIdRequest(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        var response = await _messageController.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new GetMessageByIdRequest(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        var response = await _messageController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<MessageQueryResponse>(m => m.Id == existingMessage.Id &&
                                                 m.SenderId == existingMessage.SenderId &&
                                                 m.SenderName == existingMessage.Sender.UserName &&
                                                 m.SenderProfileImage == existingMessage.Sender.ProfileImage &&
                                                 m.ReceiverId == existingMessage.ReceiverId &&
                                                 m.ReceiverName == existingMessage.Receiver.UserName &&
                                                 m.ReceiverProfileImage == existingMessage.Receiver.ProfileImage &&
                                                 m.Content == existingMessage.Content);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new GetMessageByIdRequest(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        await _messageController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetMessageByIdQuery>(m => m.Id == existingMessage.Id &&
                                                          m.CurrentUserId == existingMessage.SenderId), CancellationToken);
    }
}
