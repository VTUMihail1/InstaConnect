using System.Linq.Expressions;
using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllFilteredPostComments;
using InstaConnect.Posts.Business.UnitTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostComments.Models.Filters;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostComments.Queries.GetAllFilteredPostComments;

public class GetAllFilteredPostCommentsQueryHandlerUnitTests : BasePostCommentUnitTest
{
    private readonly GetAllFilteredPostCommentsQueryHandler _queryHandler;

    public GetAllFilteredPostCommentsQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostCommentReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetAllMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllFilteredPostCommentsQuery(
            ValidPostCommentCurrentUserId,
            ValidUserName,
            ValidPostCommentPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        Expression<Func<PostComment, bool>> expectedExpression = pc =>
             (string.IsNullOrEmpty(ValidPostCommentCurrentUserId) || pc.UserId.Equals(ValidPostCommentCurrentUserId)) &&
             (string.IsNullOrEmpty(ValidUserName) || pc.User!.UserName.Equals(ValidUserName)) &&
             (string.IsNullOrEmpty(ValidPostCommentPostId) || pc.PostId.Equals(ValidPostCommentPostId));

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostCommentReadRepository
            .Received(1)
            .GetAllFilteredAsync(Arg.Is<PostCommentFilteredCollectionReadQuery>(m =>
                                                                        m.Expression.Compile().ToString() == expectedExpression.Compile().ToString() &&
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommentViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllFilteredPostCommentsQuery(
            ValidPostCommentCurrentUserId,
            ValidUserName,
            ValidPostCommentPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == ValidId &&
                                                           m.UserId == ValidPostCommentCurrentUserId &&
                                                           m.UserName == ValidUserName &&
                                                           m.UserProfileImage == ValidUserProfileImage &&
                                                           m.PostId == ValidPostCommentPostId &&
                                                           m.Content == ValidContent) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
