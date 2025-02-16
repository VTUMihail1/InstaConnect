using FluentAssertions;

using InstaConnect.Messages.Application.Features.Messages.Commands.Update;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Presentation.Features.Messages.Controllers.v1;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;
using InstaConnect.Messages.Presentation.UnitTests.Features.Messages.Utilities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NSubstitute;

namespace InstaConnect.Messages.Presentation.UnitTests.Features.Messages.Controllers.v1;

public class UpdateMessageUnitTests : BaseMessageUnitTest
{
    private readonly MessageController _messageController;

    public UpdateMessageUnitTests()
    {
        _messageController = new(
            InstaConnectSender,
            InstaConnectMapper);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnOkStatusCode_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new UpdateMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId,
            new(MessageTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await _messageController.UpdateAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnMessageViewModel_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new UpdateMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId,
            new(MessageTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await _messageController.UpdateAsync(request, CancellationToken);

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
    public async Task UpdateAsync_ShouldCallTheSender_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new UpdateMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId,
            new(MessageTestUtilities.ValidUpdateContent)
        );

        // Act
        await _messageController.UpdateAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<UpdateMessageCommand>(m => m.Id == existingMessage.Id &&
                                                    m.CurrentUserId == existingMessage.SenderId &&
                                                    m.Content == MessageTestUtilities.ValidUpdateContent),
                                                    CancellationToken);
    }
}
