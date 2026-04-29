namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.ChatMessages.Controllers.v1;

public class GetChatMessageByIdControllerUnitTests : BaseChatMessagePresentationQueryUnitTest
{
	private readonly GetChatMessageByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetChatMessageByIdApiRequestBuilder _requestBuilder;
	private readonly GetChatMessageByIdApiRequest _request;

	private readonly ChatMessageController _controller;

	public GetChatMessageByIdControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ChatMessage);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupGetByIdQueryRequest(_request, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessage, _request);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.GetByIdAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
	}
}
