namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostCommentLikes.Controllers.v1;

public class AddPostCommentLikeControllerUnitTests : BasePostCommentLikePresentationUnitTest
{
    private readonly AddPostCommentLikeApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostCommentLikeApiRequestBuilder _requestBuilder;
    private readonly AddPostCommentLikeApiRequest _request;

    private readonly PostCommentLikeController _postCommentLikeController;

    public AddPostCommentLikeControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, PostComment, User);
        _request = _requestBuilder.Build();

        _postCommentLikeController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupAddCommandRequest(_request, PostCommentLike, CancellationToken);
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
        response.ShouldSatisfy(PostCommentLike);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentLikeController.AddAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
