namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Controllers.v1;

public class AddPostLikeControllerUnitTests : BasePostLikePresentationCommandUnitTest
{
    private readonly AddPostLikeApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostLikeApiRequestBuilder _requestBuilder;
    private readonly AddPostLikeApiRequest _request;

    private readonly PostLikeController _controller;

    public AddPostLikeControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, User);
        _request = _requestBuilder.Build();

        _controller = new(Mapper, Sender);

        Sender.SetupAddCommandRequest(_request, PostLike, CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _controller.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _controller.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, _request);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _controller.AddAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
