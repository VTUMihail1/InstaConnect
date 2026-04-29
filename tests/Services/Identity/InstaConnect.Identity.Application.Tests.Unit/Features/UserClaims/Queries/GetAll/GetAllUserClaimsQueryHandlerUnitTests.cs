namespace InstaConnect.Identity.Application.Tests.Unit.Features.UserClaims.Queries.GetAll;

public class GetAllUserClaimsQueryHandlerUnitTests : BaseUserClaimApplicationQueryUnitTest
{
	private readonly GetAllUserClaimsQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllUserClaimsQueryRequestBuilder _requestBuilder;
	private readonly GetAllUserClaimsQueryRequest _request;

	private readonly GetAllUserClaimsQueryHandler _handler;

	public GetAllUserClaimsQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(UserClaim);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupGetAllQuery(_request, User, UserClaims, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, UserClaims, _request);
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
