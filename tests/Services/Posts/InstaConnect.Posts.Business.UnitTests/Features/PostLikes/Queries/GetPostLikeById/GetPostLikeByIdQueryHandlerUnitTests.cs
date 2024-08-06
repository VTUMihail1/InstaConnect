using FluentAssertions;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetPostLikeById;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetPostById;
using InstaConnect.Shared.Business.Exceptions.Follow;
using InstaConnect.Shared.Business.Exceptions.PostLike;
using InstaConnect.Shared.Business.Exceptions.Posts;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Queries.GetFollowById;

public class GetPostLikeByIdQueryHandlerUnitTests : BasePostLikeUnitTest
{
    private readonly GetPostLikeByIdQueryHandler _queryHandler;

    public GetPostLikeByIdQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostLikeReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostLikeNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(InvalidId);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostLikeNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(ValidId);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostLikeReadRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostLikeViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(ValidId);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikeQueryViewModel>(m => m.Id == ValidId &&
                                              m.UserId == ValidPostLikeCurrentUserId &&
                                              m.UserName == ValidUserName &&
                                              m.UserProfileImage == ValidUserProfileImage &&
                                              m.PostId == ValidPostLikePostId);
    }
}
