namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostComments.Controllers.v1;

public class GetAllPostCommentsControllerUnitTests : BasePostCommentPresentationQueryUnitTest
{
    private readonly GetAllPostCommentsApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentsApiRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentsApiRequest _request;

    private readonly PostCommentController _postCommentController;

    public GetAllPostCommentsControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Build();

        _postCommentController = new(Mapper, Sender);

        Sender.SetupGetAllQueryRequest(_request, PostComments, CancellationToken);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComments, _request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentController.GetAllAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
