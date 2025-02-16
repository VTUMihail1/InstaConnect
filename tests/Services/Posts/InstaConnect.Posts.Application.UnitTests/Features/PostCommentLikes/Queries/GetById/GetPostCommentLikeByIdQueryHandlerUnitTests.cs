using FluentAssertions;

using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Queries.GetById;

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
                                              m.UserName == existingPostCommentLike.User.UserName &&
                                              m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                              m.PostCommentId == existingPostCommentLike.PostCommentId);
    }
}
