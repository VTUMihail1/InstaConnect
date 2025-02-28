using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Common.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Controllers.v1;

public class GetAllPostCommentsFunctionalTests : BasePostCommentFunctionalTest
{
    public GetAllPostCommentsFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetAllPostCommentsRequest(
            SharedTestUtilities.GetString(length),
            existingPostComment.User.UserName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            SharedTestUtilities.GetString(length),
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            existingPostComment.User.UserName,
            SharedTestUtilities.GetString(length),
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostCommentDoesNotContainProperty()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            existingPostComment.User.UserName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.InvalidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.SortPropertyMinLength - 1)]
    [InlineData(SharedConfigurations.SortPropertyMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            existingPostComment.User.UserName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            existingPostComment.User.UserName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            value,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }



    [Theory]
    [InlineData(SharedConfigurations.PageSizeMinValue - 1)]
    [InlineData(SharedConfigurations.PageSizeMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            existingPostComment.User.UserName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            value);

        // Act
        var response = await PostCommentsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            existingPostComment.User.UserName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentPaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            existingPostComment.User.UserName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostComment.Id &&
                                                               m.UserId == existingPostComment.UserId &&
                                                               m.UserName == existingPostComment.User.UserName &&
                                                               m.UserProfileImage == existingPostComment.User.ProfileImage &&
                                                               m.PostId == existingPostComment.PostId &&
                                                               m.Content == existingPostComment.Content) &&
                                                               mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentPaginationCollectionResponse_WhenRequestIsValidAndUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetAllPostCommentsRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostComment.UserId),
            existingPostComment.User.UserName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostComment.Id &&
                                                               m.UserId == existingPostComment.UserId &&
                                                               m.UserName == existingPostComment.User.UserName &&
                                                               m.UserProfileImage == existingPostComment.User.ProfileImage &&
                                                               m.PostId == existingPostComment.PostId &&
                                                               m.Content == existingPostComment.Content) &&
                                                               mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentPaginationCollectionResponse_WhenRequestIsValidAndUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            SharedTestUtilities.GetNonCaseMatchingString(existingPostComment.User.UserName),
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostComment.Id &&
                                                               m.UserId == existingPostComment.UserId &&
                                                               m.UserName == existingPostComment.User.UserName &&
                                                               m.UserProfileImage == existingPostComment.User.ProfileImage &&
                                                               m.PostId == existingPostComment.PostId &&
                                                               m.Content == existingPostComment.Content) &&
                                                               mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentPaginationCollectionResponse_WhenRequestIsValidAndUserNameIsNotFull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            SharedTestUtilities.GetHalfStartString(existingPostComment.User.UserName),
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostComment.Id &&
                                                               m.UserId == existingPostComment.UserId &&
                                                               m.UserName == existingPostComment.User.UserName &&
                                                               m.UserProfileImage == existingPostComment.User.ProfileImage &&
                                                               m.PostId == existingPostComment.PostId &&
                                                               m.Content == existingPostComment.Content) &&
                                                               mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentPaginationCollectionResponse_WhenRequestIsValidAndPostIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            existingPostComment.User.UserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingPostComment.PostId),
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostComment.Id &&
                                                               m.UserId == existingPostComment.UserId &&
                                                               m.UserName == existingPostComment.User.UserName &&
                                                               m.UserProfileImage == existingPostComment.User.ProfileImage &&
                                                               m.PostId == existingPostComment.PostId &&
                                                               m.Content == existingPostComment.Content) &&
                                                               mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentPaginationCollectionResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);

        // Act
        var response = await PostCommentsClient.GetAllAsync(CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostComment.Id &&
                                                               m.UserId == existingPostComment.UserId &&
                                                               m.UserName == existingPostComment.User.UserName &&
                                                               m.UserProfileImage == existingPostComment.User.ProfileImage &&
                                                               m.PostId == existingPostComment.PostId &&
                                                               m.Content == existingPostComment.Content) &&
                                                               mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }
}
