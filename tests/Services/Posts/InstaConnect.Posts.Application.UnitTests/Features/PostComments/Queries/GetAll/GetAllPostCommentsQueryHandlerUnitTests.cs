using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Queries.GetAll;

public class GetAllPostCommentsQueryHandlerUnitTests : BasePostCommentUnitTest
{
    private readonly GetAllPostCommentsQueryHandler _queryHandler;

    public GetAllPostCommentsQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostCommentReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetAllMethod_WhenQueryIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            existingPostComment.User.UserName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostCommentReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<PostCommentCollectionReadQuery>(m =>
                                                                        m.UserId == existingPostComment.UserId &&
                                                                        m.UserName == existingPostComment.User.UserName &&
                                                                        m.PostId == existingPostComment.PostId &&
                                                                        m.Page == PostCommentTestUtilities.ValidPageValue &&
                                                                        m.Page == PostCommentTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostCommentTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostCommentTestUtilities.ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommentViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var query = new GetAllPostCommentsQuery(
            existingPostComment.UserId,
            existingPostComment.User.UserName,
            existingPostComment.PostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostComment.Id &&
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
