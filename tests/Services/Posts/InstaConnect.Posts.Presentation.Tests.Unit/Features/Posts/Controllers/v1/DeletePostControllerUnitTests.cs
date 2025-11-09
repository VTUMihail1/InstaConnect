namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Posts.Controllers.v1;


public class DeletePostControllerUnitTests : BasePostPresentationUnitTest
{
    private readonly DeletePostApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostApiRequestBuilder _requestBuilder;
    private readonly DeletePostApiRequest _request;

    private readonly PostController _postController;

    public DeletePostControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post);
        _request = _requestBuilder.Build();

        _postController = new(ApplicationMapper, ApplicationSender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.DeleteAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postController.DeleteAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
