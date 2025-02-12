using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllPostLikes;
using InstaConnect.Posts.Application.IntegrationTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostLikes.Queries;

public class GetAllPostLikesQueryHandlerIntegrationTests : BasePostLikeIntegrationTest
{
    public GetAllPostLikesQueryHandlerIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {
    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            SharedTestUtilities.GetString(length),
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            SharedTestUtilities.GetString(length),
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            SharedTestUtilities.GetString(length),
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            null,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenMessageDoesNotContaintSortPropertyName()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.InvalidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(SharedConfigurations.SortOrderMinLength - 1)]
    [InlineData(SharedConfigurations.SortOrderMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            value,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(SharedConfigurations.PageSizeMinValue - 1)]
    [InlineData(SharedConfigurations.PageSizeMaxValue + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
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
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            null,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLike.Id &&
                                                                    m.UserId == existingPostLike.UserId &&
                                                                    m.UserName == existingPostLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                                    m.PostId == existingPostLike.PostId) &&
                                                           mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenUserIdIsEmpty()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            string.Empty,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLike.Id &&
                                                                    m.UserId == existingPostLike.UserId &&
                                                                    m.UserName == existingPostLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                                    m.PostId == existingPostLike.PostId) &&
                                                           mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostLike.UserId),
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLike.Id &&
                                                                    m.UserId == existingPostLike.UserId &&
                                                                    m.UserName == existingPostLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                                    m.PostId == existingPostLike.PostId) &&
                                                           mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenUserNameIsNull()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            null,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLike.Id &&
                                                                    m.UserId == existingPostLike.UserId &&
                                                                    m.UserName == existingPostLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                                    m.PostId == existingPostLike.PostId) &&
                                                           mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenUserNameIsEmpty()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            string.Empty,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLike.Id &&
                                                                    m.UserId == existingPostLike.UserId &&
                                                                    m.UserName == existingPostLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                                    m.PostId == existingPostLike.PostId) &&
                                                           mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            SharedTestUtilities.GetNonCaseMatchingString(existingPostLike.User.UserName),
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLike.Id &&
                                                                    m.UserId == existingPostLike.UserId &&
                                                                    m.UserName == existingPostLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                                    m.PostId == existingPostLike.PostId) &&
                                                           mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenPostIdIsNull()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            null,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLike.Id &&
                                                                    m.UserId == existingPostLike.UserId &&
                                                                    m.UserName == existingPostLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                                    m.PostId == existingPostLike.PostId) &&
                                                           mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenPostIdIsEmpty()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            string.Empty,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLike.Id &&
                                                                    m.UserId == existingPostLike.UserId &&
                                                                    m.UserName == existingPostLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                                    m.PostId == existingPostLike.PostId) &&
                                                           mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenPostIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingPostLike.PostId),
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLike.Id &&
                                                                    m.UserId == existingPostLike.UserId &&
                                                                    m.UserName == existingPostLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                                    m.PostId == existingPostLike.PostId) &&
                                                           mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostLikeViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLike.Id &&
                                                                    m.UserId == existingPostLike.UserId &&
                                                                    m.UserName == existingPostLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                                    m.PostId == existingPostLike.PostId) &&
                                                           mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
