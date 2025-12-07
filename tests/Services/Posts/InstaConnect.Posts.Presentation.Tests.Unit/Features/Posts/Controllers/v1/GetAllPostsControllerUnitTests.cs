namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Posts.Controllers.v1;

public class GetAllPostsControllerUnitTests : BasePostPresentationUnitTest
{
    private readonly GetAllPostsApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostsApiRequestBuilder _requestBuilder;
    private readonly GetAllPostsApiRequest _request;

    private readonly PostController _postController;

    public GetAllPostsControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, User);
        _request = _requestBuilder.Build();

        _postController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupGetAllQueryRequest(_request, Post, CancellationToken);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, User, _request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postController.GetAllAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
