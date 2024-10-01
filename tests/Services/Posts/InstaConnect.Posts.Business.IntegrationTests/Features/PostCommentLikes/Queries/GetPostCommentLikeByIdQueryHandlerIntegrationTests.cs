using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetPostCommentLikeById;
using InstaConnect.Posts.Business.IntegrationTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Business.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.PostCommentLike;

namespace InstaConnect.Posts.Business.IntegrationTests.Features.PostCommentLikes.Queries;

public class GetPostCommentLikeByIdQueryHandlerIntegrationTests : BasePostCommentLikeIntegrationTest
{
    public GetPostCommentLikeByIdQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var query = new GetPostCommentLikeByIdQuery(null!);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentLikeBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentLikeBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var query = new GetPostCommentLikeByIdQuery(Faker.Random.AlphaNumeric(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentLikeNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var query = new GetPostCommentLikeByIdQuery(existingPostCommentLikeId);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikeQueryViewModel>(m => m.Id == existingPostCommentLikeId &&
                                                  m.UserId == existingUserId &&
                                                  m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                  m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage &&
                                                  m.PostCommentId == existingPostCommentId);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var query = new GetPostCommentLikeByIdQuery(GetNonCaseMatchingString(existingPostCommentLikeId));

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikeQueryViewModel>(m => m.Id == existingPostCommentLikeId &&
                                                  m.UserId == existingUserId &&
                                                  m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                  m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage &&
                                                  m.PostCommentId == existingPostCommentId);
    }
}
