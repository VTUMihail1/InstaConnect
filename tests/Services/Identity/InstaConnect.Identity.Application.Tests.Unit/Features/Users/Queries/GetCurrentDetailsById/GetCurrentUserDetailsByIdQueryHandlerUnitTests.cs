namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Queries.GetCurrentDetailsById;

public class GetCurrentUserDetailsByIdQueryHandlerUnitTests : BaseUserApplicationQueryUnitTest
{
	private readonly GetCurrentUserDetailsByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetCurrentUserDetailsByIdQueryRequestBuilder _requestBuilder;
	private readonly GetCurrentUserDetailsByIdQueryRequest _request;

	private readonly GetCurrentUserDetailsByIdQueryHandler _handler;

	public GetCurrentUserDetailsByIdQueryHandlerUnitTests()
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
