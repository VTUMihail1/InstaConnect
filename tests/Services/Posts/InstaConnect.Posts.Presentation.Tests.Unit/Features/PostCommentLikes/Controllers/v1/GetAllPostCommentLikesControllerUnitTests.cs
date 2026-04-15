namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostCommentLikes.Controllers.v1;

public class GetAllPostCommentLikesControllerUnitTests : BasePostCommentLikePresentationQueryUnitTest
{
    private readonly GetAllPostCommentLikesApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentLikesApiRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentLikesApiRequest _request;

    private readonly PostCommentLikeController _controller;

    public GetAllPostCommentLikesControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Build();

        _controller = new(Mapper, Sender);

        Sender.SetupGetAllQueryRequest(_request, PostComment, PostCommentLikes, CancellationToken);
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
        response.ShouldSatisfy(PostComment, PostCommentLikes, _request);
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
