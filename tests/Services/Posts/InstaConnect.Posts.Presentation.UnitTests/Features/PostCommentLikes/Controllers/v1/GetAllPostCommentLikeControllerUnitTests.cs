using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostCommentLikes.Controllers.v1;

public class GetAllPostCommentLikeControllerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly PostCommentLikeController _postCommentLikeController;

    public GetAllPostCommentLikeControllerUnitTests()
    {
        _postCommentLikeController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postCommentLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postCommentLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == existingPostCommentLike.Id &&
                                                                 m.PostCommentId == existingPostCommentLike.PostCommentId &&
                                                                 m.UserId == existingPostCommentLike.UserId &&
                                                                 m.UserName == existingPostCommentLike.User.UserName &&
                                                                 m.UserProfileImage == existingPostCommentLike.User.ProfileImage) &&
                                                              mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                              mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                              mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            existingPostCommentLike.User.UserName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue
        );

        // Act
        await _postCommentLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllPostCommentLikesQuery>(m =>
                  m.UserId == existingPostCommentLike.UserId &&
                  m.UserName == existingPostCommentLike.User.UserName &&
                  m.PostCommentId == existingPostCommentLike.PostCommentId &&
                  m.SortOrder == PostCommentLikeTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostCommentLikeTestUtilities.ValidSortPropertyName &&
                  m.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                  m.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue), CancellationToken);
    }
}
