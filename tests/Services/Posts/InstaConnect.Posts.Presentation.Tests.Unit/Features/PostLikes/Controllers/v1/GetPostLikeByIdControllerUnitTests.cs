namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Controllers.v1;

public class GetPostLikeByIdControllerUnitTests : BasePostLikePresentationUnitTest
{
    private readonly GetPostLikeByIdApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostLikeByIdApiRequestBuilder _requestBuilder;
    private readonly GetPostLikeByIdApiRequest _request;

    private readonly PostLikeController _postLikeController;

    public GetPostLikeByIdControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();

        _postLikeController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupGetByIdQueryRequest(_request, PostLike, User, CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postLikeController.GetByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postLikeController.GetByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postLikeController.GetByIdAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
