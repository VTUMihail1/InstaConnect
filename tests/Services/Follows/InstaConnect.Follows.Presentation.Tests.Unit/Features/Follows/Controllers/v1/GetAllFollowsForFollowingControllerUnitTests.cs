namespace InstaConnect.Follows.Presentation.Tests.Unit.Features.Follows.Controllers.v1;

public class GetAllFollowsForFollowingControllerUnitTests : BaseFollowPresentationQueryUnitTest
{
    private readonly GetAllFollowsForFollowingApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllFollowsForFollowingApiRequestBuilder _requestBuilder;
    private readonly GetAllFollowsForFollowingApiRequest _request;

    private readonly FollowingFollowController _controller;

    public GetAllFollowsForFollowingControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Follow);
        _request = _requestBuilder.Build();

        _controller = new(Mapper, Sender);

        Sender.SetupGetAllForFollowingQueryRequest(_request, Following, Follows, CancellationToken);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _controller.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _controller.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Following, Follows, _request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _controller.GetAllAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
