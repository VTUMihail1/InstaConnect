namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostComments.Controllers.v1;

public class AddPostCommentControllerUnitTests : BasePostCommentPresentationCommandUnitTest
{
    private readonly AddPostCommentApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostCommentApiRequestBuilder _requestBuilder;
    private readonly AddPostCommentApiRequest _request;

    private readonly PostCommentController _postCommentController;

    public AddPostCommentControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, User);
        _request = _requestBuilder.Build();

        _postCommentController = new(Mapper, Sender);

        Sender.SetupAddCommandRequest(_request, PostComment, CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, _request);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentController.AddAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
