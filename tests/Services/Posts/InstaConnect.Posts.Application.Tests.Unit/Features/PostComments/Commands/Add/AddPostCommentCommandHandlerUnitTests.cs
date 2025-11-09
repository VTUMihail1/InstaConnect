namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Commands.Add;

public class AddPostCommentCommandHandlerUnitTests : BasePostCommentApplicationUnitTest
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

        _handler = new(ApplicationMapper, PostCommentService);

        PostCommentService.SetupAddCommand(_request, PostComment, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentServiceAddAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentService.ShouldReceiveOneAddAsync(_request, CancellationToken);
    }
}
