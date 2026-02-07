namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Posts.Controllers.v1;

public class GetAllPostsForUserControllerUnitTests : BasePostPresentationQueryUnitTest
{
    private readonly GetAllPostsForUserApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostsForUserApiRequestBuilder _requestBuilder;
    private readonly GetAllPostsForUserApiRequest _request;

    private readonly UserPostController _controller;

    public GetAllPostsForUserControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post);
        _request = _requestBuilder.Build();

        _controller = new(Mapper, Sender);

        Sender.SetupGetAllForUserQueryRequest(_request, User, Posts, CancellationToken);
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
        response.ShouldSatisfy(User, Posts, _request);
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
