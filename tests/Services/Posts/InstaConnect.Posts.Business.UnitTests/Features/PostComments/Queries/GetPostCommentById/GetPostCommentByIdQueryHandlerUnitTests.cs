﻿using FluentAssertions;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetPostCommentById;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetPostById;
using InstaConnect.Shared.Business.Exceptions.Follow;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Business.Exceptions.Posts;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Queries.GetFollowById;

public class GetPostCommentByIdQueryHandlerUnitTests : BasePostCommentUnitTest
{
    private readonly GetPostCommentByIdQueryHandler _queryHandler;

    public GetPostCommentByIdQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostCommentReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetPostCommentByIdQuery(InvalidId);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetPostCommentByIdQuery(ValidId);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostCommentReadRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommentViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetPostCommentByIdQuery(ValidId);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentQueryViewModel>(m => m.Id == ValidId &&
                                              m.UserId == ValidPostCommentCurrentUserId &&
                                              m.UserName == ValidUserName &&
                                              m.UserProfileImage == ValidUserProfileImage &&
                                              m.PostId == ValidPostCommentPostId &&
                                              m.Content == ValidContent);
    }
}
