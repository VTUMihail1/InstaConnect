using FluentAssertions;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllPosts;
using InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Queries;

public class GetAllPostsQueryHandlerIntegrationTests : BasePostIntegrationTest
{
    public GetAllPostsQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Theory]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            existingUserId,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(PostBusinessConfigurations.TITLE_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.TITLE_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            existingUserId,
            PostTestUtilities.ValidUserName,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

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
        var query = new GetAllPostsQuery(
            existingUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            null!,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

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
        var query = new GetAllPostsQuery(
            existingUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.InvalidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

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
        var query = new GetAllPostsQuery(
            existingUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

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
        var query = new GetAllPostsQuery(
            existingUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            value,
            PostTestUtilities.ValidPageSizeValue);

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
        var query = new GetAllPostsQuery(
            existingUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            value);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenUserIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            null!,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                                    m.Title == PostTestUtilities.ValidTitle &&
                                                                    m.Content == PostTestUtilities.ValidContent) &&
                                                           mc.Page == PostTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenUserIdIsEmpty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            string.Empty,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                                    m.Title == PostTestUtilities.ValidTitle &&
                                                                    m.Content == PostTestUtilities.ValidContent) &&
                                                           mc.Page == PostTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            SharedTestUtilities.GetNonCaseMatchingString(existingUserId),
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                                    m.Title == PostTestUtilities.ValidTitle &&
                                                                    m.Content == PostTestUtilities.ValidContent) &&
                                                           mc.Page == PostTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenUserNameIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            existingUserId,
            null!,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                                    m.Title == PostTestUtilities.ValidTitle &&
                                                                    m.Content == PostTestUtilities.ValidContent) &&
                                                           mc.Page == PostTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenUserNameIsEmpty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            existingUserId,
            string.Empty,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                                    m.Title == PostTestUtilities.ValidTitle &&
                                                                    m.Content == PostTestUtilities.ValidContent) &&
                                                           mc.Page == PostTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            existingUserId,
            SharedTestUtilities.GetNonCaseMatchingString(PostTestUtilities.ValidUserName),
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                                    m.Title == PostTestUtilities.ValidTitle &&
                                                                    m.Content == PostTestUtilities.ValidContent) &&
                                                           mc.Page == PostTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenTitleIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            existingUserId,
            PostTestUtilities.ValidUserName,
            null!,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                                    m.Title == PostTestUtilities.ValidTitle &&
                                                                    m.Content == PostTestUtilities.ValidContent) &&
                                                           mc.Page == PostTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenTitleIsEmpty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            existingUserId,
            PostTestUtilities.ValidUserName,
            string.Empty,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                                    m.Title == PostTestUtilities.ValidTitle &&
                                                                    m.Content == PostTestUtilities.ValidContent) &&
                                                           mc.Page == PostTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenTitleCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            existingUserId,
            PostTestUtilities.ValidUserName,
            SharedTestUtilities.GetNonCaseMatchingString(PostTestUtilities.ValidTitle),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                                    m.Title == PostTestUtilities.ValidTitle &&
                                                                    m.Content == PostTestUtilities.ValidContent) &&
                                                           mc.Page == PostTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenTitleIsNotFull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            existingUserId,
            PostTestUtilities.ValidUserName,
            SharedTestUtilities.GetHalfStartString(PostTestUtilities.ValidTitle),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                                    m.Title == PostTestUtilities.ValidTitle &&
                                                                    m.Content == PostTestUtilities.ValidContent) &&
                                                           mc.Page == PostTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var query = new GetAllPostsQuery(
            existingUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                                    m.Title == PostTestUtilities.ValidTitle &&
                                                                    m.Content == PostTestUtilities.ValidContent) &&
                                                           mc.Page == PostTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
