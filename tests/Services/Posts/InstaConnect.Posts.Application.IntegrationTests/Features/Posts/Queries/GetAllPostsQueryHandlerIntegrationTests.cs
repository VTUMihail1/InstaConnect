using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Queries;

public class GetAllPostsQueryHandlerIntegrationTests : BasePostIntegrationTest
{
    public GetAllPostsQueryHandlerIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {
    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            SharedTestUtilities.GetString(length),
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            SharedTestUtilities.GetString(length),
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(PostConfigurations.TitleMinLength - 1)]
    [InlineData(PostConfigurations.TitleMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            existingPost.User.UserName,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            null,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenMessageDoesNotContaintSortPropertyName()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.InvalidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(SharedConfigurations.SortOrderMinLength - 1)]
    [InlineData(SharedConfigurations.SortOrderMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            value,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(SharedConfigurations.PageSizeMinValue - 1)]
    [InlineData(SharedConfigurations.PageSizeMaxValue + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            value);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenUserIdIsNull()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            null,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPost.Id &&
                                                                    m.UserId == existingPost.UserId &&
                                                                    m.UserName == existingPost.User.UserName &&
                                                                    m.UserProfileImage == existingPost.User.ProfileImage &&
                                                                    m.Title == existingPost.Title &&
                                                                    m.Content == existingPost.Content) &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            string.Empty,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPost.Id &&
                                                                    m.UserId == existingPost.UserId &&
                                                                    m.UserName == existingPost.User.UserName &&
                                                                    m.UserProfileImage == existingPost.User.ProfileImage &&
                                                                    m.Title == existingPost.Title &&
                                                                    m.Content == existingPost.Content) &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            SharedTestUtilities.GetNonCaseMatchingString(existingPost.UserId),
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPost.Id &&
                                                                    m.UserId == existingPost.UserId &&
                                                                    m.UserName == existingPost.User.UserName &&
                                                                    m.UserProfileImage == existingPost.User.ProfileImage &&
                                                                    m.Title == existingPost.Title &&
                                                                    m.Content == existingPost.Content) &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            null,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPost.Id &&
                                                                    m.UserId == existingPost.UserId &&
                                                                    m.UserName == existingPost.User.UserName &&
                                                                    m.UserProfileImage == existingPost.User.ProfileImage &&
                                                                    m.Title == existingPost.Title &&
                                                                    m.Content == existingPost.Content) &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            string.Empty,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPost.Id &&
                                                                    m.UserId == existingPost.UserId &&
                                                                    m.UserName == existingPost.User.UserName &&
                                                                    m.UserProfileImage == existingPost.User.ProfileImage &&
                                                                    m.Title == existingPost.Title &&
                                                                    m.Content == existingPost.Content) &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            SharedTestUtilities.GetNonCaseMatchingString(existingPost.User.UserName),
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPost.Id &&
                                                                    m.UserId == existingPost.UserId &&
                                                                    m.UserName == existingPost.User.UserName &&
                                                                    m.UserProfileImage == existingPost.User.ProfileImage &&
                                                                    m.Title == existingPost.Title &&
                                                                    m.Content == existingPost.Content) &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            existingPost.User.UserName,
            null,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPost.Id &&
                                                                    m.UserId == existingPost.UserId &&
                                                                    m.UserName == existingPost.User.UserName &&
                                                                    m.UserProfileImage == existingPost.User.ProfileImage &&
                                                                    m.Title == existingPost.Title &&
                                                                    m.Content == existingPost.Content) &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            existingPost.User.UserName,
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
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPost.Id &&
                                                                    m.UserId == existingPost.UserId &&
                                                                    m.UserName == existingPost.User.UserName &&
                                                                    m.UserProfileImage == existingPost.User.ProfileImage &&
                                                                    m.Title == existingPost.Title &&
                                                                    m.Content == existingPost.Content) &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            existingPost.User.UserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingPost.Title),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPost.Id &&
                                                                    m.UserId == existingPost.UserId &&
                                                                    m.UserName == existingPost.User.UserName &&
                                                                    m.UserProfileImage == existingPost.User.ProfileImage &&
                                                                    m.Title == existingPost.Title &&
                                                                    m.Content == existingPost.Content) &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            existingPost.User.UserName,
            SharedTestUtilities.GetHalfStartString(existingPost.Title),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPost.Id &&
                                                                    m.UserId == existingPost.UserId &&
                                                                    m.UserName == existingPost.User.UserName &&
                                                                    m.UserProfileImage == existingPost.User.ProfileImage &&
                                                                    m.Title == existingPost.Title &&
                                                                    m.Content == existingPost.Content) &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPost.Id &&
                                                                    m.UserId == existingPost.UserId &&
                                                                    m.UserName == existingPost.User.UserName &&
                                                                    m.UserProfileImage == existingPost.User.ProfileImage &&
                                                                    m.Title == existingPost.Title &&
                                                                    m.Content == existingPost.Content) &&
                                                           mc.Page == PostTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
