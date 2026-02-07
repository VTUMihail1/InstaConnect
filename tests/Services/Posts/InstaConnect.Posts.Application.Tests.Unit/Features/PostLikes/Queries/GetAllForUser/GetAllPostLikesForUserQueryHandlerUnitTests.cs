using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Queries.GetAllForUser;

public class GetAllPostLikesForUserQueryHandlerUnitTests : BasePostLikeApplicationQueryUnitTest
{
    private readonly GetAllPostLikesForUserQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostLikesForUserQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostLikesForUserQueryRequest _request;

    private readonly GetAllPostLikesForUserQueryHandler _handler;

    public GetAllPostLikesForUserQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, LikeService);

        LikeService.SetupGetAllForUserQuery(_request, User, PostLikes, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, PostLikes, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallLikeServiceGetAllForUserAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await LikeService.ShouldReceiveOneGetAllForUserAsync(_request, CancellationToken);
    }
}
