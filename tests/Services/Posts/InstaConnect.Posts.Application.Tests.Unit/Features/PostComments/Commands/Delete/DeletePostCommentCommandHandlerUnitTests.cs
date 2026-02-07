namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Commands.Delete;

public class DeletePostCommentCommandHandlerUnitTests : BasePostCommentApplicationCommandUnitTest
{
    private readonly DeletePostCommentCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostCommentCommandRequestBuilder _requestBuilder;
    private readonly DeletePostCommentCommandRequest _request;

    private readonly DeletePostCommentCommandHandler _handler;

    public DeletePostCommentCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, CommentService);
    }

    [Fact]
    public async Task Handle_ShouldCallCommentServiceDeleteAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await CommentService.ShouldReceiveOneDeleteAsync(_request, CancellationToken);
    }
}
