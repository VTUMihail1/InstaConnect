namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Queries.GetAll;

public class GetAllPostCommentLikesQueryHandlerUnitTests : BasePostCommentLikeApplicationQueryUnitTest
{
    private readonly GetAllPostCommentLikesQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentLikesQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentLikesQueryRequest _request;

    private readonly GetAllPostCommentLikesQueryHandler _handler;

    public GetAllPostCommentLikesQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, CommentLikeService);

        CommentLikeService.SetupGetAllQuery(_request, PostComment, PostCommentLikes, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, PostCommentLikes, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallCommentLikeServiceGetAllAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await CommentLikeService.ShouldReceiveOneGetAllAsync(_request, CancellationToken);
    }
}
