namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostComments.Controllers.v1;

public class GetAllPostCommentsForUserControllerUnitTests : BasePostCommentPresentationQueryUnitTest
{
	private readonly GetAllPostCommentsForUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostCommentsForUserApiRequestBuilder _requestBuilder;
	private readonly GetAllPostCommentsForUserApiRequest _request;

	private readonly UserPostCommentController _controller;

	public GetAllPostCommentsForUserControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostComment);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupGetAllForUserQueryRequest(_request, User, PostComments, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, PostComments, _request);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.GetAllAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
	}
}
