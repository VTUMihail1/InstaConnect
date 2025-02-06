using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetPostCommentLikeById;
using InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.PostCommentLike;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Queries.GetPostCommentLikeById;

public class GetPostCommentLikeByIdQueryHandlerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly GetPostCommentLikeByIdQueryHandler _queryHandler;

    public GetPostCommentLikeByIdQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostCommentLikeReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentLikeNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var query = new GetPostCommentLikeByIdQuery(PostCommentLikeTestUtilities.InvalidId);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentLikeNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var query = new GetPostCommentLikeByIdQuery(existingPostCommentLike.Id);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostCommentLikeReadRepository
            .Received(1)
            .GetByIdAsync(existingPostCommentLike.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommentLikeViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var query = new GetPostCommentLikeByIdQuery(existingPostCommentLike.Id);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikeQueryViewModel>(m => m.Id == existingPostCommentLike.Id &&
                                              m.UserId == existingPostCommentLike.UserId &&
                                              m.UserName == UserTestUtilities.ValidName &&
                                              m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                              m.PostCommentId == existingPostCommentLike.PostCommentId);
    }
}
