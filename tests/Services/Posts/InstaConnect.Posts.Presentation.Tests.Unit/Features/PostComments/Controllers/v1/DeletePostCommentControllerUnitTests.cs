namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostComments.Controllers.v1;


public class DeletePostCommentControllerUnitTests : BasePostCommentPresentationCommandUnitTest
{
    private readonly DeletePostCommentApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostCommentApiRequestBuilder _requestBuilder;
    private readonly DeletePostCommentApiRequest _request;

    private readonly PostCommentController _postCommentController;

    public DeletePostCommentControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Build();

        _postCommentController = new(Mapper, Sender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.DeleteAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentController.DeleteAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
