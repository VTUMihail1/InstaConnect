namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.Users.Controllers.v1;

public class GetUserDetailsByIdControllerUnitTests : BaseUserPresentationQueryUnitTest
{
	private readonly GetUserDetailsByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetUserDetailsByIdApiRequestBuilder _requestBuilder;
	private readonly GetUserDetailsByIdApiRequest _request;

	private readonly UserController _controller;

	public GetUserDetailsByIdControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupGetDetailsByIdQueryRequest(_request, User, CancellationToken);
	}

	[Fact]
	public async Task GetDetailsByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetDetailsByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetDetailsByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetDetailsByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, _request);
	}

	[Fact]
	public async Task GetDetailsByIdAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.GetDetailsByIdAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
	}
}
