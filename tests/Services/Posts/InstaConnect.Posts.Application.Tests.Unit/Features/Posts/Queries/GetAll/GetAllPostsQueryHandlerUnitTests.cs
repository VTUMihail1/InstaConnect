namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Queries.GetAll;

public class GetAllPostsQueryHandlerUnitTests : BasePostApplicationUnitTest
{
    private readonly GetAllPostsQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostsQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostsQueryRequest _request;

    private readonly GetAllPostsQueryHandler _handler;

    public GetAllPostsQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, User);
        _request = _requestBuilder.Build();

        _handler = new(PostService, ApplicationMapper, PostIncludeQueryBuilderFactory);

        PostService.SetupGetAllQuery(_request, Post, User, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, User, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallPostServiceGetAllAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneGetAllAsync(_request, CancellationToken);
    }
}
