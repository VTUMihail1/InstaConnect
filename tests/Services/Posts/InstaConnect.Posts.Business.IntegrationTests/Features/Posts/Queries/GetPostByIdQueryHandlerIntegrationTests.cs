using FluentAssertions;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetPostById;
using InstaConnect.Posts.Business.IntegrationTests.Features.Posts.Utilities;
using InstaConnect.Posts.Business.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Posts;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Business.IntegrationTests.Features.Posts.Queries;

public class GetPostByIdQueryHandlerIntegrationTests : BasePostIntegrationTest
{
    public GetPostByIdQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetPostByIdQuery(null!);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetPostByIdQuery(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetPostByIdQuery(PostTestUtilities.InvalidId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetPostByIdQuery(existingPostId);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostQueryViewModel>(m => m.Id == existingPostId &&
                                          m.UserId == existingUserId &&
                                          m.UserName == PostTestUtilities.ValidUserName &&
                                          m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                          m.Title == PostTestUtilities.ValidTitle &&
                                          m.Content == PostTestUtilities.ValidContent);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetPostByIdQuery(SharedTestUtilities.GetNonCaseMatchingString(existingPostId));

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostQueryViewModel>(m => m.Id == existingPostId &&
                                          m.UserId == existingUserId &&
                                          m.UserName == PostTestUtilities.ValidUserName &&
                                          m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                          m.Title == PostTestUtilities.ValidTitle &&
                                          m.Content == PostTestUtilities.ValidContent);
    }
}
