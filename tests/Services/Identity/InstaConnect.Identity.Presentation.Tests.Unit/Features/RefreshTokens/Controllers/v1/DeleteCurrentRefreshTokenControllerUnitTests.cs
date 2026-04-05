namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.RefreshTokens.Controllers.v1;


public class DeleteCurrentRefreshTokenControllerUnitTests : BaseRefreshTokenPresentationCommandUnitTest
{
    private readonly DeleteCurrentRefreshTokenApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteCurrentRefreshTokenApiRequestBuilder _requestBuilder;
    private readonly DeleteCurrentRefreshTokenApiRequest _request;

    private readonly RefreshTokenController _controller;

    public DeleteCurrentRefreshTokenControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(RefreshToken);
        _request = _requestBuilder.Build();

        _controller = new(Mapper, Sender, CookieStore);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _controller.DeleteCurrentAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _controller.DeleteCurrentAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldCallTheCookieStoreDelete_WhenRequestIsValid()
    {
        // Act
        await _controller.DeleteCurrentAsync(_request, CancellationToken);

        // Assert
        CookieStore.ShouldReceiveOneDelete(_request);
    }
}
