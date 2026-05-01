namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.Users.Controllers.v1;

public class DeleteCurrentUserControllerUnitTests : BaseUserPresentationCommandUnitTest
{
	private readonly DeleteCurrentUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteCurrentUserApiRequestBuilder _requestBuilder;
	private readonly DeleteCurrentUserApiRequest _request;

	private readonly UserController _controller;

	public DeleteCurrentUserControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.DeleteCurrentAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.DeleteCurrentAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
	}
}
