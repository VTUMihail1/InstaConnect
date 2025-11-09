namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostCommentLikes.Controllers.v1;

public class GetPostCommentLikeByIdControllerUnitTests : BasePostCommentLikePresentationUnitTest
{
    private readonly GetPostCommentLikeByIdApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostCommentLikeByIdApiRequestBuilder _requestBuilder;
    private readonly GetPostCommentLikeByIdApiRequest _request;

    private readonly PostCommentLikeController _postCommentLikeController;

    public GetPostCommentLikeByIdControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Build();

        _postCommentLikeController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupGetByIdQueryRequest(_request, PostCommentLike, User, CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentLikeController.GetByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentLikeController.GetByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, User);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentLikeController.GetByIdAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
