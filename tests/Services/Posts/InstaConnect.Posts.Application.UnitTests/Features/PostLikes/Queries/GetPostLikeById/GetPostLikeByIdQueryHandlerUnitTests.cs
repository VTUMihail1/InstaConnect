using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Queries.GetPostLikeById;

public class GetPostLikeByIdQueryHandlerUnitTests : BasePostLikeUnitTest
{
    private readonly GetPostLikeByIdQueryHandler _queryHandler;

    public GetPostLikeByIdQueryHandlerUnitTests()
    {
        _queryHandler = new(
            PostLikeService,
            ApplicationMapper,
            PostReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var query = new GetPostLikeByIdQuery(existingPostLike.Id, PostTestUtilities.InvalidId);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostLikeNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var query = new GetPostLikeByIdQuery(PostLikeTestUtilities.InvalidId, existingPostLike.PostId);

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
        var query = new GetPostLikeByIdQuery(existingPostLike.Id, existingPostLike.PostId);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostLikeService
            .Received(1)
            .GetByIdAsync(existingPostLike.Post, existingPostLike.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostLikeViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var query = new GetPostLikeByIdQuery(existingPostLike.Id, existingPostLike.PostId);

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
