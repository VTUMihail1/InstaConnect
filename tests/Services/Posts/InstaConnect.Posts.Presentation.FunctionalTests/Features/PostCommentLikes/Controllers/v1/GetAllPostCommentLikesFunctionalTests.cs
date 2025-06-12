namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostCommentLikes.Controllers.v1;

public class GetAllPostCommentLikesFunctionalTests : BasePostCommentLikeFunctionalTest
{
    public GetAllPostCommentLikesFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetAllPostCommentLikesRequest(
            DataFaker.GetString(length),
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            DataFaker.GetString(length),
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(PostCommentConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentConfigurations.IdMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostCommentIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            DataFaker.GetString(length),
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostCommentLikeDoesNotContainProperty()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.InvalidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.SortPropertyMinLength - 1)]
    [InlineData(SharedConfigurations.SortPropertyMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            DataFaker.GetString(length),
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            value,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }



    [Theory]
    [InlineData(SharedConfigurations.PageSizeMinValue - 1)]
    [InlineData(SharedConfigurations.PageSizeMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            value);

        // Act
        var response = await PostCommentLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentLikesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentLike.Id &&
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
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationCollectionResponse_WhenRequestIsValidAndUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetAllPostCommentLikesRequest(
            DataFaker.GetDifferentCaseString(existingPostCommentLike.UserId),
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentLikesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentLike.Id &&
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
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationCollectionResponse_WhenRequestIsValidAndUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            DataFaker.GetDifferentCaseString(existingPostCommentLike.User.UserName),
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentLikesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentLike.Id &&
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
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationCollectionResponse_WhenRequestIsValidAndUserIsNotFull()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            DataFaker.GetPrefixString(existingPostCommentLike.User.UserName),
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentLikesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentLike.Id &&
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
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationCollectionResponse_WhenRequestIsValidAndPostIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            DataFaker.GetDifferentCaseString(existingPostCommentLike.PostCommentId),
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostCommentLikesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentLike.Id &&
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
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationCollectionResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);

        // Act
        var response = await PostCommentLikesClient.GetAllAsync(CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentLike.Id &&
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
