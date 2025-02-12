using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetPostCommentLikeById;
using InstaConnect.Posts.Application.IntegrationTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.PostCommentLike;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostCommentLikes.Queries;

public class GetPostCommentLikeByIdQueryHandlerIntegrationTests : BasePostCommentLikeIntegrationTest
{
    public GetPostCommentLikeByIdQueryHandlerIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetPostCommentLikeByIdQuery(null);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentLikeConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentLikeConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetPostCommentLikeByIdQuery(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentLikeNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetPostCommentLikeByIdQuery(PostCommentLikeTestUtilities.InvalidId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentLikeNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetPostCommentLikeByIdQuery(existingPostCommentLike.Id);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikeQueryViewModel>(m => m.Id == existingPostCommentLike.Id &&
                                                  m.UserId == existingPostCommentLike.UserId &&
                                                  m.UserName == UserTestUtilities.ValidName &&
                                                  m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                                  m.PostCommentId == existingPostCommentLike.PostCommentId);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetPostCommentLikeByIdQuery(SharedTestUtilities.GetNonCaseMatchingString(existingPostCommentLike.Id));

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

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
