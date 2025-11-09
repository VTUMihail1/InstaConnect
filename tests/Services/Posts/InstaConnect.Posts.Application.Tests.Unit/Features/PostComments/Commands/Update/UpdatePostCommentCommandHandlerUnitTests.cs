namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Commands.Update;

public class UpdatePostCommentCommandHandlerUnitTests : BasePostCommentApplicationUnitTest
{
    private readonly UpdatePostCommentCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdatePostCommentCommandRequestBuilder _requestBuilder;
    private readonly UpdatePostCommentCommandRequest _request;

    private readonly UpdatePostCommentCommandHandler _handler;

    public UpdatePostCommentCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Build();

        _handler = new(ApplicationMapper, PostCommentService);

        PostCommentService.SetupUpdateCommand(_request, PostComment, CancellationToken);
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
    public async Task Handle_ShouldCallPostCommentServiceUpdateAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentService.ShouldReceiveOneUpdateAsync(_request, CancellationToken);
    }
}
