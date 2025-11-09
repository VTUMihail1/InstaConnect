namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Controllers.v1;

public class AddPostLikeControllerUnitTests : BasePostLikePresentationUnitTest
{
    private readonly AddPostLikeApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostLikeApiRequestBuilder _requestBuilder;
    private readonly AddPostLikeApiRequest _request;

    private readonly PostLikeController _postLikeController;

    public AddPostLikeControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, User);
        _request = _requestBuilder.Build();

        _postLikeController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupAddCommandRequest(_request, PostLike, CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postLikeController.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postLikeController.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postLikeController.AddAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
