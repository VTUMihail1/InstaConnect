namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostCommentLikes.Controllers.v1;

public class DeletePostCommentLikeControllerUnitTests : BasePostCommentLikePresentationCommandUnitTest
{
	private readonly DeletePostCommentLikeApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeletePostCommentLikeApiRequestBuilder _requestBuilder;
	private readonly DeletePostCommentLikeApiRequest _request;

	private readonly PostCommentLikeController _controller;

	public DeletePostCommentLikeControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);
	}

	[Fact]
	public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.DeleteAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.DeleteAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
	}
}
