using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Business.IntegrationTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Business.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Business.IntegrationTests.Features.PostComments.Queries;

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
            Faker.Random.AlphaNumeric(length),
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
            Faker.Random.AlphaNumeric(length),
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
            Faker.Random.AlphaNumeric(length),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
            ValidSortOrderProperty,
            null!,
            ValidPageValue,
            ValidPageSizeValue);

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
            ValidSortOrderProperty,
            InvalidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
            ValidSortOrderProperty,
            Faker.Random.AlphaNumeric(length),
            ValidPageValue,
            ValidPageSizeValue);

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
            ValidSortOrderProperty,
            ValidSortPropertyName,
            value,
            ValidPageSizeValue);

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
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
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
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
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
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
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
            GetNonCaseMatchingString(existingUserId),
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
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
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
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
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
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
            GetNonCaseMatchingString(PostCommentTestUtilities.ValidUserName),
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
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
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
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
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
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
            GetNonCaseMatchingString(existingPostId),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
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
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
