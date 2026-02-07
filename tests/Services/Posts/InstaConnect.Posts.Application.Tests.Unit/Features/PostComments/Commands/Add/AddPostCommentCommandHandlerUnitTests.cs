namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Commands.Add;

public class AddPostCommentCommandHandlerUnitTests : BasePostCommentApplicationCommandUnitTest
{
    private readonly AddPostCommentCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostCommentCommandRequestBuilder _requestBuilder;
    private readonly AddPostCommentCommandRequest _request;

    private readonly AddPostCommentCommandHandler _handler;

    public AddPostCommentCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, User);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, CommentService);

        CommentService.SetupAddCommand(_request, PostComment, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallCommentServiceAddAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await CommentService.ShouldReceiveOneAddAsync(_request, CancellationToken);
    }
}
