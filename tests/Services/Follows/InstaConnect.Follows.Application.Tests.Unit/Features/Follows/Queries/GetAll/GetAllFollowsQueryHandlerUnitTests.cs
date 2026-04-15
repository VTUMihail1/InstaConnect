namespace InstaConnect.Follows.Application.Tests.Unit.Features.Follows.Queries.GetAll;

public class GetAllFollowsQueryHandlerUnitTests : BaseFollowApplicationQueryUnitTest
{
    private readonly GetAllFollowsQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllFollowsQueryRequestBuilder _requestBuilder;
    private readonly GetAllFollowsQueryRequest _request;

    private readonly GetAllFollowsQueryHandler _handler;

    public GetAllFollowsQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Follow);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, Service);

        Service.SetupGetAllQuery(_request, Follower, Follows, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follower, Follows, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallLikeServiceGetAllAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await Service.ShouldReceiveOneGetAllAsync(_request, CancellationToken);
    }
}
