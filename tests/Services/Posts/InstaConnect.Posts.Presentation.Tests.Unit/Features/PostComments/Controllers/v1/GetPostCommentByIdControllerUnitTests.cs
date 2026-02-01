namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostComments.Controllers.v1;

public class GetPostCommentByIdControllerUnitTests : BasePostCommentPresentationQueryUnitTest
{
    private readonly GetPostCommentByIdApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostCommentByIdApiRequestBuilder _requestBuilder;
    private readonly GetPostCommentByIdApiRequest _request;

    private readonly PostCommentController _postCommentController;

    public GetPostCommentByIdControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Build();

        _postCommentController = new(Mapper, Sender);

        Sender.SetupGetByIdQueryRequest(_request, PostComment, CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.GetByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.GetByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, _request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentController.GetByIdAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
