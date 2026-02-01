namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostCommentLikes.Controllers.v1;

public class AddPostCommentLikeControllerUnitTests : BasePostCommentLikePresentationCommandUnitTest
{
    private readonly AddPostCommentLikeApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostCommentLikeApiRequestBuilder _requestBuilder;
    private readonly AddPostCommentLikeApiRequest _request;

    private readonly PostCommentLikeController _postCommentLikeController;

    public AddPostCommentLikeControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment, User);
        _request = _requestBuilder.Build();

        _postCommentLikeController = new(Mapper, Sender);

        Sender.SetupAddCommandRequest(_request, PostCommentLike, CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentLikeController.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentLikeController.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, _request);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentLikeController.AddAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
