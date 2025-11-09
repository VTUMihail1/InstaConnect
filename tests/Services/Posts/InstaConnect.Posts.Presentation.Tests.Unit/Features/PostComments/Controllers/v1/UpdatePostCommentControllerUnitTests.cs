namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostComments.Controllers.v1;

public class UpdatePostCommentControllerUnitTests : BasePostCommentPresentationUnitTest
{
    private readonly UpdatePostCommentApiRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdatePostCommentApiRequestBuilder _requestBuilder;
    private readonly UpdatePostCommentApiRequest _request;

    private readonly PostCommentController _postCommentController;

    public UpdatePostCommentControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Build();

        _postCommentController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupUpdateCommandRequest(_request, PostComment, CancellationToken);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.UpdateAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.UpdateAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentController.UpdateAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
