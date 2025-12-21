namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Queries.GetById;

public class GetPostByIdQueryHandlerUnitTests : BasePostApplicationQueryUnitTest
{
    private readonly GetPostByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostByIdQueryRequestBuilder _requestBuilder;
    private readonly GetPostByIdQueryRequest _request;

    private readonly GetPostByIdQueryHandler _handler;

    public GetPostByIdQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post);
        _request = _requestBuilder.Build();

        _handler = new(PostService, ApplicationMapper, PostIncludeQueryBuilderFactory);

        PostService.SetupGetByIdQuery(_request, Post, Include, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post);
    }

    [Fact]
    public async Task Handle_ShouldCallPostServiceGetByIdAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneGetByIdAsync(_request, Include, CancellationToken);
    }
}
