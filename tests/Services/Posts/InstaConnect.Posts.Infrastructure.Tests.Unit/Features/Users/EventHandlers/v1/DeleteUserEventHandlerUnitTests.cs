namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Users.EventHandlers.v1;

public class DeleteUserEventHandlerUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly UserDeletedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserDeletedEventRequestBuilder _requestBuilder;
	private readonly UserDeletedEventRequest _request;

	private readonly UserDeletedEventHandler _handler;

	public DeleteUserEventHandlerUnitTests()
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
