using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetPostLikeById;
using InstaConnect.Posts.Business.IntegrationTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Business.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.PostLike;

namespace InstaConnect.Posts.Business.IntegrationTests.Features.PostLikes.Queries;

public class GetPostLikeByIdQueryHandlerIntegrationTests : BasePostLikeIntegrationTest
{
    public GetPostLikeByIdQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetPostLikeByIdQuery(null!);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetPostLikeByIdQuery(Faker.Random.AlphaNumeric(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostLikeNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetPostLikeByIdQuery(existingPostLikeId);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikeQueryViewModel>(m => m.Id == existingPostLikeId &&
                                                  m.UserId == existingUserId &&
                                                  m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                  m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                  m.PostId == existingPostId);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetPostLikeByIdQuery(GetNonCaseMatchingString(existingPostLikeId));

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikeQueryViewModel>(m => m.Id == existingPostLikeId &&
                                                  m.UserId == existingUserId &&
                                                  m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                  m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                  m.PostId == existingPostId);
    }
}
