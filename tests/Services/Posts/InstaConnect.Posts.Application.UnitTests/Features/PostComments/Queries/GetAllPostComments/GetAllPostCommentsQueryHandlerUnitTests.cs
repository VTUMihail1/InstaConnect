using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Application.UnitTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Queries.GetAllPostComments;

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
                                                                        m.UserId == PostCommentTestUtilities.ValidPostCommentCurrentUserId &&
                                                                        m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                        m.PostId == PostCommentTestUtilities.ValidPostCommentPostId &&
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
        var query = new GetAllPostCommentsQuery(
            PostCommentTestUtilities.ValidPostCommentCurrentUserId,
            PostCommentTestUtilities.ValidUserName,
            PostCommentTestUtilities.ValidPostCommentPostId,
            PostCommentTestUtilities.ValidSortOrderProperty,
            PostCommentTestUtilities.ValidSortPropertyName,
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue);

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
                                                           mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
