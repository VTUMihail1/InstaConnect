using System.Linq.Expressions;
using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllFilteredPostCommentLikes;
using InstaConnect.Posts.Business.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Filters;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostCommentLikes.Queries.GetAllFilteredPostCommentLikes;

public class GetAllFilteredPostCommentLikesQueryHandlerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly GetAllPostCommentLikesQueryHandler _queryHandler;

    public GetAllFilteredPostCommentLikesQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostCommentLikeReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetAllMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllPostCommentLikesQuery(
            ValidPostCommentLikeCurrentUserId,
            ValidUserName,
            ValidPostCommentLikePostCommentId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        Expression<Func<PostCommentLike, bool>> expectedExpression = p =>
             (string.IsNullOrEmpty(ValidPostCommentLikeCurrentUserId) || p.UserId.Equals(ValidPostCommentLikeCurrentUserId)) &&
             (string.IsNullOrEmpty(ValidUserName) || p.User!.UserName.Equals(ValidUserName)) &&
             (string.IsNullOrEmpty(ValidPostCommentLikePostCommentId) || p.PostCommentId.Equals(ValidPostCommentLikePostCommentId));

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostCommentLikeReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<PostCommentLikeFilteredCollectionReadQuery>(m =>
                                                                        m.Expression.Compile().ToString() == expectedExpression.Compile().ToString() &&
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllPostCommentLikesQuery(
            ValidPostCommentLikeCurrentUserId,
            ValidUserName,
            ValidPostCommentLikePostCommentId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == ValidId &&
                                                           m.UserId == ValidPostCommentLikeCurrentUserId &&
                                                           m.UserName == ValidUserName &&
                                                           m.UserProfileImage == ValidUserProfileImage &&
                                                           m.PostCommentId == ValidPostCommentLikePostCommentId) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
