namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Commands.Add;

public class AddPostCommentLikeCommandHandlerUnitTests : BasePostCommentLikeApplicationUnitTest
{
    private readonly AddPostCommentLikeCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostCommentLikeCommandRequestBuilder _requestBuilder;
    private readonly AddPostCommentLikeCommandRequest _request;

    private readonly AddPostCommentLikeCommandHandler _handler;

    public AddPostCommentLikeCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment, User);
        _request = _requestBuilder.Build();

        _handler = new(ApplicationMapper, PostCommentLikeService);

        PostCommentLikeService.SetupAddCommand(_request, PostCommentLike, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentLikeServiceAddAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentLikeService.ShouldReceiveOneAddAsync(_request, CancellationToken);
    }
}
