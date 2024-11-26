using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Application.IntegrationTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostComments.Queries;

public class GetAllPostCommentsQueryHandlerIntegrationTests : BasePostCommentIntegrationTest
{
    public GetAllPostCommentsQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Theory]
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            SharedTestUtilities.GetString(length),
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            SharedTestUtilities.GetString(length),
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(PostCommentBusinessConfigurations.POST_ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.POST_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
            SharedTestUtilities.GetString(length),
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            null!,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenMessageDoesNotContaintSortPropertyName()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.InvalidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(SharedBusinessConfigurations.SORT_ORDER_MIN_LENGTH - 1)]
    [InlineData(SharedBusinessConfigurations.SORT_ORDER_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            value,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MAX_VALUE + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            value);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenUserIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            null!,
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId &&
                                                                    m.Content == PostCommentTestUtilities.ValidContent) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenUserIdIsEmpty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            string.Empty,
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId &&
                                                                    m.Content == PostCommentTestUtilities.ValidContent) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            SharedTestUtilities.GetNonCaseMatchingString(existingUserId),
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId &&
                                                                    m.Content == PostCommentTestUtilities.ValidContent) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenUserNameIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            null!,
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId &&
                                                                    m.Content == PostCommentTestUtilities.ValidContent) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenUserNameIsEmpty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            string.Empty,
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId &&
                                                                    m.Content == PostCommentTestUtilities.ValidContent) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            SharedTestUtilities.GetNonCaseMatchingString(PostCommentTestUtilities.ValidUserName),
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId &&
                                                                    m.Content == PostCommentTestUtilities.ValidContent) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenPostIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
            null!,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId &&
                                                                    m.Content == PostCommentTestUtilities.ValidContent) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenPostIdIsEmpty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
            string.Empty,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId &&
                                                                    m.Content == PostCommentTestUtilities.ValidContent) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenPostIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingPostId),
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId &&
                                                                    m.Content == PostCommentTestUtilities.ValidContent) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostCommentsQuery(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId &&
                                                                    m.Content == PostCommentTestUtilities.ValidContent) &&
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
