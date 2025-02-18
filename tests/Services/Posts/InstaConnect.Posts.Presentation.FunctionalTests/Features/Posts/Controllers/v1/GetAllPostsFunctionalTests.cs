namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Controllers.v1;

public class GetAllPostsFunctionalTests : BasePostFunctionalTest
{
    public GetAllPostsFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            SharedTestUtilities.GetString(length),
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

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
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            SharedTestUtilities.GetString(length),
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(PostConfigurations.TitleMinLength - 1)]
    [InlineData(PostConfigurations.TitleMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            existingPost.User.UserName,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostDoesNotContainProperty()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.InvalidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

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
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

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
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            value,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

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
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            value);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
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
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValidAndUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPost.UserId),
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
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
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValidAndUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            SharedTestUtilities.GetNonCaseMatchingString(existingPost.User.UserName),
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
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
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValidAndUserNameIsNotFull()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            SharedTestUtilities.GetHalfStartString(existingPost.User.UserName),
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
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
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValidAndTitleCaseDoesNotMatch()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            existingPost.User.UserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingPost.Title),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
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
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValidAndTitleIsNotFull()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            existingPost.User.UserName,
            SharedTestUtilities.GetHalfStartString(existingPost.Title),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
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
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);

        // Act
        var response = await PostsClient.GetAllAsync(CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
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
