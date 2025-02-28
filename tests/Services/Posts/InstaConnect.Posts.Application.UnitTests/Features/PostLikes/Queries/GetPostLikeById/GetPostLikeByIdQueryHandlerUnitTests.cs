using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Queries.GetPostLikeById;

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
        var existingPostLike = CreatePostLike();
        var query = new GetPostLikeByIdQuery(existingPostLike.Id);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostLikeReadRepository
            .Received(1)
            .GetByIdAsync(existingPostLike.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostLikeViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var query = new GetPostLikeByIdQuery(existingPostLike.Id);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikeQueryViewModel>(m => m.Id == existingPostLike.Id &&
                                              m.UserId == existingPostLike.UserId &&
                                              m.UserName == existingPostLike.User.UserName &&
                                              m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                              m.PostId == existingPostLike.PostId);
    }
}
