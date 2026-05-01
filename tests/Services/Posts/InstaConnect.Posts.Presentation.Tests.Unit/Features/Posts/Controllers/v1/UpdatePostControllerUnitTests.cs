namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Posts.Controllers.v1;

public class UpdatePostControllerUnitTests : BasePostPresentationCommandUnitTest
{
	private readonly UpdatePostApiRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdatePostApiRequestBuilder _requestBuilder;
	private readonly UpdatePostApiRequest _request;

	private readonly PostController _controller;

	public UpdatePostControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupUpdateCommandRequest(_request, Post, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.UpdateAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.UpdateAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Post, _request);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.UpdateAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
	}
}
