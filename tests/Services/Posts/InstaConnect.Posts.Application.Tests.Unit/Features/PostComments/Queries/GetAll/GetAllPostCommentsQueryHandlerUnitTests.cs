namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Queries.GetAll;

public class GetAllPostCommentsQueryHandlerUnitTests : BasePostCommentApplicationUnitTest
{
    private readonly GetAllPostCommentsQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentsQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentsQueryRequest _request;

    private readonly GetAllPostCommentsQueryHandler _handler;

    public GetAllPostCommentsQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment, User);
        _request = _requestBuilder.Build();

        _handler = new(ApplicationMapper, PostCommentService, PostCommentIncludeQueryBuilderFactory);

        PostCommentService.SetupGetAllQuery(_request, PostComment, User, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentServiceGetAllAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentService.ShouldReceiveOneGetAllAsync(_request, CancellationToken);
    }
}
