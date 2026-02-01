namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Posts.Controllers.v1;

public class UpdatePostControllerUnitTests : BasePostPresentationCommandUnitTest
{
    private readonly UpdatePostApiRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdatePostApiRequestBuilder _requestBuilder;
    private readonly UpdatePostApiRequest _request;

    private readonly PostController _postController;

    public UpdatePostControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post);
        _request = _requestBuilder.Build();

        _postController = new(Mapper, Sender);

        Sender.SetupUpdateCommandRequest(_request, Post, CancellationToken);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.UpdateAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.UpdateAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, _request);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postController.UpdateAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
