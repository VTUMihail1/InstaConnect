namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostComments.Controllers.v1;

public class GetAllPostCommentsControllerUnitTests : BasePostCommentPresentationUnitTest
{
    private readonly GetAllPostCommentsApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentsApiRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentsApiRequest _request;

    private readonly PostCommentController _postCommentController;

    public GetAllPostCommentsControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment, User);
        _request = _requestBuilder.Build();

        _postCommentController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupGetAllQueryRequest(_request, PostComment, CancellationToken);
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
        response.ShouldSatisfy(PostComment, User, _request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentController.GetAllAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
