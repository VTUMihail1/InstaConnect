namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Controllers.v1;

public class GetAllPostLikesControllerUnitTests : BasePostLikePresentationQueryUnitTest
{
    private readonly GetAllPostLikesApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostLikesApiRequestBuilder _requestBuilder;
    private readonly GetAllPostLikesApiRequest _request;

    private readonly PostLikeController _controller;

    public GetAllPostLikesControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();

        _controller = new(Mapper, Sender);

        Sender.SetupGetAllQueryRequest(_request, Post, PostLikes, CancellationToken);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _controller.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _controller.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, PostLikes, _request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _controller.GetAllAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
