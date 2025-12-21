namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Queries.GetById;

public class GetPostLikeByIdQueryHandlerUnitTests : BasePostLikeApplicationQueryUnitTest
{
    private readonly GetPostLikeByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostLikeByIdQueryRequestBuilder _requestBuilder;
    private readonly GetPostLikeByIdQueryRequest _request;

    private readonly GetPostLikeByIdQueryHandler _handler;

    public GetPostLikeByIdQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();

        _handler = new(PostLikeService, ApplicationMapper, PostLikeIncludeQueryBuilderFactory);

        PostLikeService.SetupGetByIdQuery(_request, PostLike, Include, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike);
    }

    [Fact]
    public async Task Handle_ShouldCallPostLikeServiceGetByIdAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostLikeService.ShouldReceiveOneGetByIdAsync(_request, Include, CancellationToken);
    }
}
