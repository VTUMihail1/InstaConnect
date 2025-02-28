using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Queries.GetById;

public class GetPostByIdQueryHandlerUnitTests : BasePostUnitTest
{
    private readonly GetPostByIdQueryHandler _queryHandler;

    public GetPostByIdQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetPostByIdQuery(PostTestUtilities.InvalidId);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var query = new GetPostByIdQuery(existingPost.Id);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostReadRepository
            .Received(1)
            .GetByIdAsync(existingPost.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var query = new GetPostByIdQuery(existingPost.Id);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostQueryViewModel>(m => m.Id == existingPost.Id &&
                                              m.UserId == existingPost.UserId &&
                                              m.UserName == existingPost.User.UserName &&
                                              m.UserProfileImage == existingPost.User.ProfileImage &&
                                              m.Title == existingPost.Title &&
                                              m.Content == existingPost.Content);
    }
}
