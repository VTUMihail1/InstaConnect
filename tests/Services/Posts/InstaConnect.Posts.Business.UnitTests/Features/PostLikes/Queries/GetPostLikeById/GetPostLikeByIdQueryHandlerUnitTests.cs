using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetPostLikeById;
using InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Shared.Common.Exceptions.PostLike;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Queries.GetPostLikeById;

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
        var query = new GetPostLikeByIdQuery(PostLikeTestUtilities.InvalidId);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostLikeNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(PostLikeTestUtilities.ValidId);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostLikeReadRepository
            .Received(1)
            .GetByIdAsync(PostLikeTestUtilities.ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostLikeViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(PostLikeTestUtilities.ValidId);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikeQueryViewModel>(m => m.Id == PostLikeTestUtilities.ValidId &&
                                              m.UserId == PostLikeTestUtilities.ValidPostLikeCurrentUserId &&
                                              m.UserName == PostLikeTestUtilities.ValidUserName &&
                                              m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                              m.PostId == PostLikeTestUtilities.ValidPostLikePostId);
    }
}
