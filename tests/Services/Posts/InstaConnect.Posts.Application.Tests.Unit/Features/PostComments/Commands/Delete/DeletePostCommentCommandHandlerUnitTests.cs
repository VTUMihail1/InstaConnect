namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Commands.Delete;

public class DeletePostCommentCommandHandlerUnitTests : BasePostCommentApplicationUnitTest
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

        _handler = new(ApplicationMapper, PostCommentService);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentServiceDeleteAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentService.ShouldReceiveOneDeleteAsync(_request, CancellationToken);
    }
}
