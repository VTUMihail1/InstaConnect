namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Controllers.v1;


public class DeletePostLikeControllerUnitTests : BasePostLikePresentationCommandUnitTest
{
    private readonly DeletePostLikeApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostLikeApiRequestBuilder _requestBuilder;
    private readonly DeletePostLikeApiRequest _request;

    private readonly PostLikeController _postLikeController;

    public DeletePostLikeControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();

        _postLikeController = new(Mapper, Sender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postLikeController.DeleteAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postLikeController.DeleteAsync(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
