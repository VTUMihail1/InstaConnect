namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostCommentLikes.Controllers.v1;

public class DeletePostCommentLikeControllerUnitTests : BasePostCommentLikePresentationUnitTest
{
    private readonly DeletePostCommentLikeApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostCommentLikeApiRequestBuilder _requestBuilder;
    private readonly DeletePostCommentLikeApiRequest _request;

    private readonly PostCommentLikeController _postCommentLikeController;

    public DeletePostCommentLikeControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Build();

        _postCommentLikeController = new(ApplicationMapper, ApplicationSender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentLikeController.DeleteAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentLikeController.DeleteAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
