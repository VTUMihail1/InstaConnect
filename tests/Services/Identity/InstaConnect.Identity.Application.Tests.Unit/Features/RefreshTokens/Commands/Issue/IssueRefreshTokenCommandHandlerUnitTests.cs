namespace InstaConnect.Identity.Application.Tests.Unit.Features.RefreshTokens.Commands.Issue;

public class IssueRefreshTokenCommandHandlerUnitTests : BaseRefreshTokenApplicationCommandUnitTest
{
	private readonly IssueRefreshTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly IssueRefreshTokenCommandRequestBuilder _requestBuilder;
	private readonly IssueRefreshTokenCommandRequest _request;

	private readonly IssueRefreshTokenCommandHandler _handler;

	public IssueRefreshTokenCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User, Password);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupIssueCommand(_request, RefreshToken, CancellationToken);
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
	public async Task Handle_ShouldCallServiceIssueAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldReceiveOneIssueAsync(_request, CancellationToken);
	}
}
