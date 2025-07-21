using InstaConnect.Common.Exceptions;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

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
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeConfigurations.IdMinLength - 1)]
    [InlineData(PostLikeConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(DataFaker.GetString(length));

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostLikeNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(PostLikeTestUtilities.InvalidId);

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

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
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

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
        var query = new GetPostLikeByIdQuery(DataFaker.GetDifferentCaseString(existingPostLike.Id));

        // Act
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

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
