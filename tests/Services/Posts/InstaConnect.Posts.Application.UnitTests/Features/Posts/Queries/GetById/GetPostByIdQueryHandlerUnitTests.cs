using FluentAssertions;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetPostById;
using InstaConnect.Posts.Application.UnitTests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Posts;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Queries.GetPostById;

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
        var existingPost = CreatePost();
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
                                              m.UserName == UserTestUtilities.ValidName &&
                                              m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                              m.Title == PostTestUtilities.ValidTitle &&
                                              m.Content == PostTestUtilities.ValidContent);
    }
}
