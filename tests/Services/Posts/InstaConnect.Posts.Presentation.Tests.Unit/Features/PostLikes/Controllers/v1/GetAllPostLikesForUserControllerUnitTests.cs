namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Controllers.v1;

public class GetAllPostLikesForUserControllerUnitTests : BasePostLikePresentationQueryUnitTest
{
    private readonly GetAllPostLikesForUserApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostLikesForUserApiRequestBuilder _requestBuilder;
    private readonly GetAllPostLikesForUserApiRequest _request;

    private readonly UserPostLikeController _controller;

    public GetAllPostLikesForUserControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();

        _controller = new(Mapper, Sender);

        Sender.SetupGetAllForUserQueryRequest(_request, User, PostLikes, CancellationToken);
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
        response.ShouldSatisfy(User, PostLikes, _request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _controller.GetAllAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
