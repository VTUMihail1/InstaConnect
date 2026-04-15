namespace InstaConnect.Follows.Application.Tests.Unit.Features.Follows.Queries.GetById;

public class GetFollowByIdQueryHandlerUnitTests : BaseFollowApplicationQueryUnitTest
{
    private readonly GetFollowByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetFollowByIdQueryRequestBuilder _requestBuilder;
    private readonly GetFollowByIdQueryRequest _request;

    private readonly GetFollowByIdQueryHandler _handler;

    public GetFollowByIdQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Follow);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, Service);

        Service.SetupGetByIdQuery(_request, Follow, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follow, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallLikeServiceGetByIdAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await Service.ShouldReceiveOneGetByIdAsync(_request, CancellationToken);
    }
}
