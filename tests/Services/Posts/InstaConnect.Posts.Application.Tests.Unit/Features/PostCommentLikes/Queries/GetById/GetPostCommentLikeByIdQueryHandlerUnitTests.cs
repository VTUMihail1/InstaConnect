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

        _handler = new(ApplicationMapper, PostCommentLikeService, PostCommentLikeIncludeQueryBuilderFactory);

        PostCommentLikeService.SetupGetByIdQuery(_request, PostCommentLike, Include, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentLikeServiceGetByIdAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentLikeService.ShouldReceiveOneGetByIdAsync(_request, Include, CancellationToken);
    }
}
