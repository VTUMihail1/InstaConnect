using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetPostCommentLikeById;
using InstaConnect.Posts.Business.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Shared.Business.Exceptions.PostCommentLike;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostCommentLikes.Queries.GetPostCommentLikeById;

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
        var query = new GetPostCommentLikeByIdQuery(InvalidId);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentLikeNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetPostCommentLikeByIdQuery(ValidId);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostCommentLikeReadRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommentLikeViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetPostCommentLikeByIdQuery(ValidId);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikeQueryViewModel>(m => m.Id == ValidId &&
                                              m.UserId == ValidPostCommentLikeCurrentUserId &&
                                              m.UserName == ValidUserName &&
                                              m.UserProfileImage == ValidUserProfileImage &&
                                              m.PostCommentId == ValidPostCommentLikePostCommentId);
    }
}
