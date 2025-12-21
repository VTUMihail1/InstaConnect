namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostCommentLikes.Controllers.v1;

public class GetAllPostCommentLikesControllerUnitTests : BasePostCommentLikePresentationQueryUnitTest
{
    private readonly GetAllPostCommentLikesApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentLikesApiRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentLikesApiRequest _request;

    private readonly PostCommentLikeController _postCommentLikeController;

    public GetAllPostCommentLikesControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Build();

        _postCommentLikeController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupGetAllQueryRequest(_request, PostCommentLikes, CancellationToken);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentLikeController.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentLikeController.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLikes, _request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentLikeController.GetAllAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
