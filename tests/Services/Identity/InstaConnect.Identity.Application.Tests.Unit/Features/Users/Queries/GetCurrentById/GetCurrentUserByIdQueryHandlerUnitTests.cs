namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Queries.GetCurrentById;

public class GetCurrentUserByIdQueryHandlerUnitTests : BaseUserApplicationQueryUnitTest
{
	private readonly GetCurrentUserByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetCurrentUserByIdQueryRequestBuilder _requestBuilder;
	private readonly GetCurrentUserByIdQueryRequest _request;

	private readonly GetCurrentUserByIdQueryHandler _handler;

	public GetCurrentUserByIdQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupGetByIdQuery(_request, User, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, _request);
	}

	[Fact]
	public async Task Handle_ShouldCallServiceGetByIdAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldReceiveOneGetByIdAsync(_request, CancellationToken);
	}
}
