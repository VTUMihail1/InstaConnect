namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.ChatMessages.Controllers.v1;


public class DeleteChatMessageControllerUnitTests : BaseChatMessagePresentationCommandUnitTest
{
    private readonly DeleteChatMessageApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteChatMessageApiRequestBuilder _requestBuilder;
    private readonly DeleteChatMessageApiRequest _request;

    private readonly ChatMessageController _controller;

    public DeleteChatMessageControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(ChatMessage);
        _request = _requestBuilder.Build();

        _controller = new(Mapper, Sender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _controller.DeleteAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _controller.DeleteAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
