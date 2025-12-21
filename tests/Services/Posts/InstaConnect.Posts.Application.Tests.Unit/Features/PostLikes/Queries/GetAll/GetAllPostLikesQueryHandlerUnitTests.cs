namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Queries.GetAll;

public class GetAllPostLikesQueryHandlerUnitTests : BasePostLikeApplicationQueryUnitTest
{
    private readonly GetAllPostLikesQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostLikesQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostLikesQueryRequest _request;

    private readonly GetAllPostLikesQueryHandler _handler;

    public GetAllPostLikesQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();

        _handler = new(PostLikeService, ApplicationMapper, PostLikeIncludeQueryBuilderFactory);

        PostLikeService.SetupGetAllQuery(_request, PostLikes, Include, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLikes, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallPostLikeServiceGetAllAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostLikeService.ShouldReceiveOneGetAllAsync(_request, Include, CancellationToken);
    }
}
