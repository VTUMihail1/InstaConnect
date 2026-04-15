namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.ChatMessages.Controllers.v1;

public class UpdateChatMessageControllerUnitTests : BaseChatMessagePresentationCommandUnitTest
{
    private readonly UpdateChatMessageApiRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdateChatMessageApiRequestBuilder _requestBuilder;
    private readonly UpdateChatMessageApiRequest _request;

    private readonly ChatMessageController _controller;

    public UpdateChatMessageControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(ChatMessage);
        _request = _requestBuilder.Build();

        _controller = new(Mapper, Sender);

        Sender.SetupUpdateCommandRequest(_request, ChatMessage, CancellationToken);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _controller.UpdateAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _controller.UpdateAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ChatMessage, _request);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _controller.UpdateAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
