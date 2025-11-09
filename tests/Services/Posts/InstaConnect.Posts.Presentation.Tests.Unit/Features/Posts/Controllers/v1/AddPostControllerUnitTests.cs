namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Posts.Controllers.v1;

public class AddPostControllerUnitTests : BasePostPresentationUnitTest
{
    private readonly AddPostApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostApiRequestBuilder _requestBuilder;
    private readonly AddPostApiRequest _request;

    private readonly PostController _postController;

    public AddPostControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _postController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupAddCommandRequest(_request, Post, CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postController.AddAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
