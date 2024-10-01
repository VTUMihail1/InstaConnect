using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllPostLikes;
using InstaConnect.Posts.Business.IntegrationTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Business.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Business.IntegrationTests.Features.PostLikes.Queries;

public class GetAllPostLikesQueryHandlerIntegrationTests : BasePostLikeIntegrationTest
{
    public GetAllPostLikesQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Theory]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            Faker.Random.AlphaNumeric(length),
            PostLikeTestUtilities.ValidUserName,
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
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
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
    [InlineData(PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
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
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
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
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
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
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
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
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
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
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
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
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenUserIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            null!,
            PostLikeTestUtilities.ValidUserName,
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
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLikeId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenUserIdIsEmpty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            string.Empty,
            PostLikeTestUtilities.ValidUserName,
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
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLikeId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            GetNonCaseMatchingString(existingUserId),
            PostLikeTestUtilities.ValidUserName,
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
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLikeId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenUserNameIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
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
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLikeId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenUserNameIsEmpty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
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
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLikeId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingUserId,
            GetNonCaseMatchingString(PostLikeTestUtilities.ValidUserName),
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
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLikeId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenPostIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
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
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLikeId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenPostIdIsEmpty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
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
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLikeId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenPostIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
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
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLikeId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
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
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLikeId &&
                                                                    m.UserId == existingUserId &&
                                                                    m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                                    m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                                    m.PostId == existingPostId) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
