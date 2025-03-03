﻿using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostLikes.Queries;

public class GetPostLikeByIdQueryHandlerIntegrationTests : BasePostLikeIntegrationTest
{
    public GetPostLikeByIdQueryHandlerIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(null);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeBusinessConfigurations.IdMinLength - 1)]
    [InlineData(PostLikeBusinessConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostLikeNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(PostLikeTestUtilities.InvalidId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostLikeNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetPostLikeByIdQuery(existingPostLike.Id);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikeQueryViewModel>(m => m.Id == existingPostLike.Id &&
                                                  m.UserId == existingPostLike.UserId &&
                                                  m.UserName == existingPostLike.User.UserName &&
                                                  m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                  m.PostId == existingPostLike.PostId);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetPostLikeByIdQuery(SharedTestUtilities.GetNonCaseMatchingString(existingPostLike.Id));

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

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
