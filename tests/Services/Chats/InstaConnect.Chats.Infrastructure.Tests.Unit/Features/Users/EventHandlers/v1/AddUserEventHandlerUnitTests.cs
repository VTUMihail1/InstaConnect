namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Users.EventHandlers.v1;

public class AddUserEventHandlerUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly UserAddedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserAddedEventRequestBuilder _requestBuilder;
	private readonly UserAddedEventRequest _request;

	private readonly UserAddedEventHandler _handler;

	public AddUserEventHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Sender);
	}

	[Fact]
	public async Task Consume_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);

		// Assert
		await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
	}
}
