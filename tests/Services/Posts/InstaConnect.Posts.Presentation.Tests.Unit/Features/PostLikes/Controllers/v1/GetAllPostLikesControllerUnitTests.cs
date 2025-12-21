namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Controllers.v1;

public class GetAllPostLikesControllerUnitTests : BasePostLikePresentationQueryUnitTest
{
    private readonly GetAllPostLikesApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostLikesApiRequestBuilder _requestBuilder;
    private readonly GetAllPostLikesApiRequest _request;

    private readonly PostLikeController _postLikeController;

    public GetAllPostLikesControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();

        _postLikeController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupGetAllQueryRequest(_request, PostLikes, CancellationToken);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postLikeController.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postLikeController.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLikes, _request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postLikeController.GetAllAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
