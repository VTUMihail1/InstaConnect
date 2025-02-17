using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class GetAllPostsControllerUnitTests : BasePostUnitTest
{
    private readonly PostController _postController;

    public GetAllPostsControllerUnitTests()
    {
        _postController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostPaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postController.GetAllAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == existingPost.Id &&
                                                                 m.Title == existingPost.Title &&
                                                                 m.Content == existingPost.Content &&
                                                                 m.UserId == existingPost.UserId &&
                                                                 m.UserName == existingPost.User.UserName &&
                                                                 m.UserProfileImage == existingPost.User.ProfileImage) &&
                                                              mc.Page == PostTestUtilities.ValidPageValue &&
                                                              mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                              mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            existingPost.User.UserName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllPostsQuery>(m =>
                  m.UserId == existingPost.UserId &&
                  m.UserName == existingPost.User.UserName &&
                  m.Title == existingPost.Title &&
                  m.SortOrder == PostTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostTestUtilities.ValidSortPropertyName &&
                  m.Page == PostTestUtilities.ValidPageValue &&
                  m.PageSize == PostTestUtilities.ValidPageSizeValue), CancellationToken);
    }
}
