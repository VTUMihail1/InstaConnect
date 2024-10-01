using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Business.UnitTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Data.Features.PostComments.Models.Filters;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostComments.Queries.GetAllPostComments;

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
        var query = new GetAllPostCommentsQuery(
            PostCommentTestUtilities.ValidPostCommentCurrentUserId,
            PostCommentTestUtilities.ValidUserName,
            PostCommentTestUtilities.ValidPostCommentPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostCommentReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<PostCommentCollectionReadQuery>(m =>
                                                                        m.UserId == PostCommentTestUtilities.ValidPostCommentCurrentUserId &&
                                                                        m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                        m.PostId == PostCommentTestUtilities.ValidPostCommentPostId &&
                                                                        m.Page == ValidPageValue &&
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommentViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllPostCommentsQuery(
            PostCommentTestUtilities.ValidPostCommentCurrentUserId,
            PostCommentTestUtilities.ValidUserName,
            PostCommentTestUtilities.ValidPostCommentPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == PostCommentTestUtilities.ValidId &&
                                                           m.UserId == PostCommentTestUtilities.ValidPostCommentCurrentUserId &&
                                                           m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                           m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                           m.PostId == PostCommentTestUtilities.ValidPostCommentPostId &&
                                                           m.Content == PostCommentTestUtilities.ValidContent) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
