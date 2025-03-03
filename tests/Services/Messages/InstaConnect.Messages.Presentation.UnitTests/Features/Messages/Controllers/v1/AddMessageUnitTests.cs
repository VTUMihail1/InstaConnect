﻿using InstaConnect.Messages.Application.Features.Messages.Commands.Add;

namespace InstaConnect.Messages.Presentation.UnitTests.Features.Messages.Controllers.v1;

public class AddMessageUnitTests : BaseMessageUnitTest
{
    private readonly MessageController _messageController;

    public AddMessageUnitTests()
    {
        _messageController = new(
            InstaConnectSender,
            InstaConnectMapper);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new AddMessageRequest(
            existingMessage.SenderId,
            new(existingMessage.ReceiverId, MessageTestUtilities.ValidAddContent)
        );

        // Act
        var response = await _messageController.AddAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnMessageViewModel_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new AddMessageRequest(
            existingMessage.SenderId,
            new(existingMessage.ReceiverId, MessageTestUtilities.ValidAddContent)
        );

        // Act
        var response = await _messageController.AddAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<MessageCommandResponse>(m => m.Id == existingMessage.Id);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new AddMessageRequest(
            existingMessage.SenderId,
            new(existingMessage.ReceiverId, MessageTestUtilities.ValidAddContent)
        );

        // Act
        await _messageController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddMessageCommand>(m => m.CurrentUserId == existingMessage.SenderId &&
                                                 m.ReceiverId == existingMessage.ReceiverId &&
                                                 m.Content == MessageTestUtilities.ValidAddContent),
                                                 CancellationToken);
    }
}
