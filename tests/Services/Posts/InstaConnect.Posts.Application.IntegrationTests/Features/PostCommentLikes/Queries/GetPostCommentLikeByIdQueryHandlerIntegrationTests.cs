using InstaConnect.Common.Exceptions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostCommentLikes.Queries;

public class GetPostCommentLikeByIdQueryHandlerIntegrationTests : BasePostCommentLikeIntegrationTest
{
    public GetPostCommentLikeByIdQueryHandlerIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var query = new GetPostCommentLikeByIdQuery(null);

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentLikeConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentLikeConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetPostCommentLikeByIdQuery(DataFaker.GetString(length));

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentLikeNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetPostCommentLikeByIdQuery(PostCommentLikeTestUtilities.InvalidId);

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

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
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikeQueryViewModel>(m => m.Id == existingPostCommentLike.Id &&
                                                  m.UserId == existingPostCommentLike.UserId &&
                                                  m.UserName == existingPostCommentLike.User.UserName &&
                                                  m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                                  m.PostCommentId == existingPostCommentLike.PostCommentId);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetPostCommentLikeByIdQuery(DataFaker.GetDifferentCaseString(existingPostCommentLike.Id));

        // Act
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

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
