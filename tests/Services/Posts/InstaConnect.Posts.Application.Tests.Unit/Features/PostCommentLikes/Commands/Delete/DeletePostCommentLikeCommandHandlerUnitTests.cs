namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Commands.Delete;

public class DeletePostCommentLikeCommandHandlerUnitTests : BasePostCommentLikeApplicationUnitTest
{
    private readonly DeletePostCommentLikeCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostCommentLikeCommandRequestBuilder _requestBuilder;
    private readonly DeletePostCommentLikeCommandRequest _request;

    private readonly DeletePostCommentLikeCommandHandler _handler;

    public DeletePostCommentLikeCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Build();

        _handler = new(ApplicationMapper, PostCommentLikeService);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentLikeServiceDeleteAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentLikeService.ShouldReceiveOneDeleteAsync(_request, CancellationToken);
    }
}
