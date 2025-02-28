using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostComments.Queries;

public class GetPostCommentByIdQueryHandlerIntegrationTests : BasePostCommentIntegrationTest
{
    public GetPostCommentByIdQueryHandlerIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var query = new GetPostCommentByIdQuery(null);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetPostCommentByIdQuery(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetPostCommentByIdQuery(PostCommentTestUtilities.InvalidId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetPostCommentByIdQuery(existingPostComment.Id);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentQueryViewModel>(m => m.Id == existingPostComment.Id &&
                                                  m.UserId == existingPostComment.UserId &&
                                                  m.UserName == existingPostComment.User.UserName &&
                                                  m.UserProfileImage == existingPostComment.User.ProfileImage &&
                                                  m.PostId == existingPostComment.PostId &&
                                                  m.Content == existingPostComment.Content);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var query = new GetPostCommentByIdQuery(SharedTestUtilities.GetNonCaseMatchingString(existingPostComment.Id));

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentQueryViewModel>(m => m.Id == existingPostComment.Id &&
                                                  m.UserId == existingPostComment.UserId &&
                                                  m.UserName == existingPostComment.User.UserName &&
                                                  m.UserProfileImage == existingPostComment.User.ProfileImage &&
                                                  m.PostId == existingPostComment.PostId &&
                                                  m.Content == existingPostComment.Content);
    }
}
