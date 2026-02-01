namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Queries.GetAll;

public class GetAllPostsQueryHandlerUnitTests : BasePostApplicationQueryUnitTest
{
    private readonly GetAllPostsQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostsQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostsQueryRequest _request;

    private readonly GetAllPostsQueryHandler _handler;

    public GetAllPostsQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, Service);

        Service.SetupGetAllQuery(_request, Posts, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Posts, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallPostServiceGetAllAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await Service.ShouldReceiveOneGetAllAsync(_request, CancellationToken);
    }
}
