namespace InstaConnect.Follows.Presentation.Tests.Unit.Features.Follows.Controllers.v1;


public class DeleteFollowControllerUnitTests : BaseFollowPresentationCommandUnitTest
{
    private readonly DeleteFollowApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteFollowApiRequestBuilder _requestBuilder;
    private readonly DeleteFollowApiRequest _request;

    private readonly FollowController _controller;

    public DeleteFollowControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Follow);
        _request = _requestBuilder.Build();

        _controller = new(Mapper, Sender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _controller.DeleteAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _controller.DeleteAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
