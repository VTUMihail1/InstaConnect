using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostComments.Controllers.v1;

public class GetAllPostCommentControllerUnitTests : BasePostCommentUnitTest
{
    private readonly PostCommentController _postCommentController;

    public GetAllPostCommentControllerUnitTests()
    {
        _postCommentController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            existingPostComment.User.UserName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postCommentController.GetAllAsync(request, CancellationToken);

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
        var existingPostComment = CreatePostComment();
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            existingPostComment.User.UserName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postCommentController.GetAllAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == existingPostComment.Id &&
                                                                 m.PostId == existingPostComment.PostId &&
                                                                 m.Content == existingPostComment.Content &&
                                                                 m.UserId == existingPostComment.UserId &&
                                                                 m.UserName == existingPostComment.User.UserName &&
                                                                 m.UserProfileImage == existingPostComment.User.ProfileImage) &&
                                                              mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                              mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                              mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var request = new GetAllPostCommentsRequest(
            existingPostComment.UserId,
            existingPostComment.User.UserName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue
        );

        // Act
        await _postCommentController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllPostCommentsQuery>(m =>
                  m.UserId == existingPostComment.UserId &&
                  m.UserName == existingPostComment.User.UserName &&
                  m.PostId == existingPostComment.PostId &&
                  m.SortOrder == PostCommentTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostCommentTestUtilities.ValidSortPropertyName &&
                  m.Page == PostCommentTestUtilities.ValidPageValue &&
                  m.PageSize == PostCommentTestUtilities.ValidPageSizeValue), CancellationToken);
    }
}
