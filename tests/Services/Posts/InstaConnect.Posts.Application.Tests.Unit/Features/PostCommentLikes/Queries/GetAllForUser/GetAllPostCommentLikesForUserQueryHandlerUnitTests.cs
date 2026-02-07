using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Queries.GetAllForUser;

public class GetAllPostCommentLikesForUserQueryHandlerUnitTests : BasePostCommentLikeApplicationQueryUnitTest
{
    private readonly GetAllPostCommentLikesForUserQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentLikesForUserQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentLikesForUserQueryRequest _request;

    private readonly GetAllPostCommentLikesForUserQueryHandler _handler;

    public GetAllPostCommentLikesForUserQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, CommentLikeService);

        CommentLikeService.SetupGetAllForUserQuery(_request, User, PostCommentLikes, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, PostCommentLikes, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentLikeServiceGetAllForUserAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await CommentLikeService.ShouldReceiveOneGetAllForUserAsync(_request, CancellationToken);
    }
}
