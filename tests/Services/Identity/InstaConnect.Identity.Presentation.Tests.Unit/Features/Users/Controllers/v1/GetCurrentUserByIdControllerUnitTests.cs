namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.Users.Controllers.v1;

public class GetCurrentUserByIdControllerUnitTests : BaseUserPresentationQueryUnitTest
{
	private readonly GetCurrentUserByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetCurrentUserByIdApiRequestBuilder _requestBuilder;
	private readonly GetCurrentUserByIdApiRequest _request;

	private readonly UserController _controller;

	public GetCurrentUserByIdControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupGetCurrentByIdQueryRequest(_request, User, CancellationToken);
	}

	[Fact]
	public async Task GetCurrentByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetCurrentByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetCurrentByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetCurrentByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, _request);
	}

	[Fact]
	public async Task GetCurrentByIdAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.GetCurrentByIdAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
	}
}
