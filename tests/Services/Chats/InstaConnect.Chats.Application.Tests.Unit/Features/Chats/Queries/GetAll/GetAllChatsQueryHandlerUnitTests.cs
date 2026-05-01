namespace InstaConnect.Chats.Application.Tests.Unit.Features.Chats.Queries.GetAll;

public class GetAllChatsQueryHandlerUnitTests : BaseChatApplicationQueryUnitTest
{
	private readonly GetAllChatsQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllChatsQueryRequestBuilder _requestBuilder;
	private readonly GetAllChatsQueryRequest _request;

	private readonly GetAllChatsQueryHandler _handler;

	public GetAllChatsQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupGetAllQuery(_request, ParticipantOne, Chats, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(ParticipantOne, Chats, _request);
	}

	[Fact]
	public async Task Handle_ShouldCallServiceGetAllAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldReceiveOneGetAllAsync(_request, CancellationToken);
	}
}
