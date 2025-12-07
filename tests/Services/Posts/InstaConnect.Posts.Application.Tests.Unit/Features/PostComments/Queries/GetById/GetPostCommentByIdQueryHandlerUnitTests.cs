namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Queries.GetById;

public class GetPostCommentByIdQueryHandlerUnitTests : BasePostCommentApplicationUnitTest
{
    private readonly GetPostCommentByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostCommentByIdQueryRequestBuilder _requestBuilder;
    private readonly GetPostCommentByIdQueryRequest _request;

    private readonly GetPostCommentByIdQueryHandler _handler;

    public GetPostCommentByIdQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Build();

        _handler = new(ApplicationMapper, PostCommentService, PostCommentIncludeQueryBuilderFactory);

        PostCommentService.SetupGetByIdQuery(_request, PostComment, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentServiceGetByIdAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentService.ShouldReceiveOneGetByIdAsync(_request, CancellationToken);
    }
}
