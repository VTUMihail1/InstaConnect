namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.Users.Controllers.v1;

public class UpdateCurrentUserControllerUnitTests : BaseUserPresentationCommandUnitTest
{
	private readonly UpdateCurrentUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateCurrentUserApiRequestBuilder _requestBuilder;
	private readonly UpdateCurrentUserApiRequest _request;

	private readonly UserController _controller;

	public UpdateCurrentUserControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupUpdateCurrentCommandRequest(_request, User, CancellationToken);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.UpdateCurrentAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.UpdateCurrentAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, _request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.UpdateCurrentAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
	}
}
