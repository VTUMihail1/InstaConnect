namespace InstaConnect.Identity.Application.Tests.Unit.Features.RefreshTokens.Commands.Rotate;

public class RotateRefreshTokenCommandHandlerUnitTests : BaseRefreshTokenApplicationCommandUnitTest
{
	private readonly RotateRefreshTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly RotateRefreshTokenCommandRequestBuilder _requestBuilder;
	private readonly RotateRefreshTokenCommandRequest _request;

	private readonly RotateRefreshTokenCommandHandler _handler;

	public RotateRefreshTokenCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(RefreshToken);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupRotateCommand(_request, RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(RefreshToken, _request);
	}

	[Fact]
	public async Task Handle_ShouldCallServiceRotateAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldReceiveOneRotateAsync(_request, CancellationToken);
	}
}
