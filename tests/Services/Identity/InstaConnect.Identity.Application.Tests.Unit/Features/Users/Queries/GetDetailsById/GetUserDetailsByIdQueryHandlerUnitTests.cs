namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Queries.GetDetailsById;

public class GetUserDetailsByIdQueryHandlerUnitTests : BaseUserApplicationQueryUnitTest
{
	private readonly GetUserDetailsByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetUserDetailsByIdQueryRequestBuilder _requestBuilder;
	private readonly GetUserDetailsByIdQueryRequest _request;

	private readonly GetUserDetailsByIdQueryHandler _handler;

	public GetUserDetailsByIdQueryHandlerUnitTests()
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
