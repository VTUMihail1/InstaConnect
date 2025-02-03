using System.Net;
using FluentAssertions;
using InstaConnect.Messages.Application.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Application.Features.Messages.Commands.DeleteMessage;
using InstaConnect.Messages.Application.Features.Messages.Commands.UpdateMessage;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetAllMessages;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Messages.Presentation.Features.Messages.Controllers.v1;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Binding;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;
using InstaConnect.Messages.Presentation.UnitTests.Features.Messages.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

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
                                                 m.SenderName == UserTestUtilities.ValidName &&
                                                 m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                 m.ReceiverId == existingMessage.ReceiverId &&
                                                 m.ReceiverName == UserTestUtilities.ValidName &&
                                                 m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage &&
                                                 m.Content == MessageTestUtilities.ValidContent);
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
