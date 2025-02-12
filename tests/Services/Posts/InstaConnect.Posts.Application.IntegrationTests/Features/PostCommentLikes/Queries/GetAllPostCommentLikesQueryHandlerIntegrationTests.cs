using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.Posts.Application.IntegrationTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostCommentLikes.Queries;

public class GetAllPostCommentLikesQueryHandlerIntegrationTests : BasePostCommentLikeIntegrationTest
{
    public GetAllPostCommentLikesQueryHandlerIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {
    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            SharedTestUtilities.GetString(length),
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

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
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            SharedTestUtilities.GetString(length),
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(PostCommentConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPostCommentIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            SharedTestUtilities.GetString(length),
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            null,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenMessageDoesNotContaintSortPropertyName()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.InvalidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

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
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

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
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            value,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

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
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            value);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenUserIdIsNull()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            null,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentLike.Id &&
                                                                    m.UserId == existingPostCommentLike.UserId &&
                                                                    m.UserName == existingPostCommentLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                                                    m.PostCommentId == existingPostCommentLike.PostCommentId) &&
                                                           mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenUserIdIsEmpty()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            string.Empty,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentLike.Id &&
                                                                    m.UserId == existingPostCommentLike.UserId &&
                                                                    m.UserName == existingPostCommentLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                                                    m.PostCommentId == existingPostCommentLike.PostCommentId) &&
                                                           mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostCommentLike.UserId),
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentLike.Id &&
                                                                    m.UserId == existingPostCommentLike.UserId &&
                                                                    m.UserName == existingPostCommentLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                                                    m.PostCommentId == existingPostCommentLike.PostCommentId) &&
                                                           mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenUserNameIsNull()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            null,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentLike.Id &&
                                                                    m.UserId == existingPostCommentLike.UserId &&
                                                                    m.UserName == existingPostCommentLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                                                    m.PostCommentId == existingPostCommentLike.PostCommentId) &&
                                                           mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenUserNameIsEmpty()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            string.Empty,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentLike.Id &&
                                                                    m.UserId == existingPostCommentLike.UserId &&
                                                                    m.UserName == existingPostCommentLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                                                    m.PostCommentId == existingPostCommentLike.PostCommentId) &&
                                                           mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            SharedTestUtilities.GetNonCaseMatchingString(existingPostCommentLike.User.UserName),
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentLike.Id &&
                                                                    m.UserId == existingPostCommentLike.UserId &&
                                                                    m.UserName == existingPostCommentLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                                                    m.PostCommentId == existingPostCommentLike.PostCommentId) &&
                                                           mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenPostIdIsNull()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            null,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentLike.Id &&
                                                                    m.UserId == existingPostCommentLike.UserId &&
                                                                    m.UserName == existingPostCommentLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                                                    m.PostCommentId == existingPostCommentLike.PostCommentId) &&
                                                           mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenPostIdIsEmpty()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            string.Empty,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentLike.Id &&
                                                                    m.UserId == existingPostCommentLike.UserId &&
                                                                    m.UserName == existingPostCommentLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                                                    m.PostCommentId == existingPostCommentLike.PostCommentId) &&
                                                           mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenPostIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingPostCommentLike.PostCommentId),
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentLike.Id &&
                                                                    m.UserId == existingPostCommentLike.UserId &&
                                                                    m.UserName == existingPostCommentLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                                                    m.PostCommentId == existingPostCommentLike.PostCommentId) &&
                                                           mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostCommentLikeViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostCommentLike.Id &&
                                                                    m.UserId == existingPostCommentLike.UserId &&
                                                                    m.UserName == existingPostCommentLike.User.UserName &&
                                                                    m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                                                    m.PostCommentId == existingPostCommentLike.PostCommentId) &&
                                                           mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
