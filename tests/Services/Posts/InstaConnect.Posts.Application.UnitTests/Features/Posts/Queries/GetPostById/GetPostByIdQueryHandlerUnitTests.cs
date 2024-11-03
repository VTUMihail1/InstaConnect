using FluentAssertions;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetPostById;
using InstaConnect.Posts.Business.UnitTests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Shared.Common.Exceptions.Posts;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.Posts.Queries.GetPostById;

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
        var query = new GetPostByIdQuery(PostTestUtilities.ValidId);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostReadRepository
            .Received(1)
            .GetByIdAsync(PostTestUtilities.ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetPostByIdQuery(PostTestUtilities.ValidId);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostQueryViewModel>(m => m.Id == PostTestUtilities.ValidId &&
                                              m.UserId == PostTestUtilities.ValidPostCurrentUserId &&
                                              m.UserName == PostTestUtilities.ValidUserName &&
                                              m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                              m.Title == PostTestUtilities.ValidTitle &&
                                              m.Content == PostTestUtilities.ValidContent);
    }
}
