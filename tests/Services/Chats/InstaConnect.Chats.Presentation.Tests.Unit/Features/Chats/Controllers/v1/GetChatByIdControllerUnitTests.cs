namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.Chats.Controllers.v1;

public class GetChatByIdControllerUnitTests : BaseChatPresentationQueryUnitTest
{
	private readonly GetChatByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetChatByIdApiRequestBuilder _requestBuilder;
	private readonly GetChatByIdApiRequest _request;

	private readonly ChatController _controller;

	public GetChatByIdControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupGetByIdQueryRequest(_request, Chat, CancellationToken);
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
		response.ShouldSatisfy(Chat, _request);
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
