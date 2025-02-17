using InstaConnect.Messages.Application.Features.Messages.Commands.Delete;

namespace InstaConnect.Messages.Presentation.UnitTests.Features.Messages.Controllers.v1;

public class DeleteMessageUnitTests : BaseMessageUnitTest
{
    private readonly MessageController _messageController;

    public DeleteMessageUnitTests()
    {
        _messageController = new(
            InstaConnectSender,
            InstaConnectMapper);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new DeleteMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        var response = await _messageController.DeleteAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new DeleteMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        await _messageController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeleteMessageCommand>(m => m.Id == existingMessage.Id &&
                                                    m.CurrentUserId == existingMessage.SenderId),
                                                    CancellationToken);
    }
}
