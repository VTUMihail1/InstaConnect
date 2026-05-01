namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Queries.GetById;

public class GetPostCommentLikeByIdQueryHandlerUnitTests : BasePostCommentLikeApplicationQueryUnitTest
{
	private readonly GetPostCommentLikeByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetPostCommentLikeByIdQueryRequestBuilder _requestBuilder;
	private readonly GetPostCommentLikeByIdQueryRequest _request;

	private readonly GetPostCommentLikeByIdQueryHandler _handler;

	public GetPostCommentLikeByIdQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, CommentLikeService);

		CommentLikeService.SetupGetByIdQuery(_request, PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentLike, _request);
	}

	[Fact]
	public async Task Handle_ShouldCallCommentLikeServiceGetByIdAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await CommentLikeService.ShouldReceiveOneGetByIdAsync(_request, CancellationToken);
	}
}
