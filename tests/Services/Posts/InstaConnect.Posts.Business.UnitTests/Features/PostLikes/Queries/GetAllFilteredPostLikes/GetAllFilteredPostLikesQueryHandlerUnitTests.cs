using System.Linq.Expressions;
using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllFilteredPostLikes;
using InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Filters;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Queries.GetAllFilteredPostLikes;

public class GetAllFilteredPostLikesQueryHandlerUnitTests : BasePostLikeUnitTest
{
    private readonly GetAllPostLikesQueryHandler _queryHandler;

    public GetAllFilteredPostLikesQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostLikeReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetAllMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllPostLikesQuery(
            ValidPostLikeCurrentUserId,
            ValidPostTitle,
            ValidPostLikePostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        Expression<Func<PostLike, bool>> expectedExpression = p =>
             (string.IsNullOrEmpty(ValidPostLikeCurrentUserId) || p.UserId.Equals(ValidPostLikeCurrentUserId)) &&
             (string.IsNullOrEmpty(ValidUserName) || p.User!.UserName.Equals(ValidUserName)) &&
             (string.IsNullOrEmpty(ValidPostLikePostId) || p.PostId.Equals(ValidPostLikePostId));

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostLikeReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<PostLikeFilteredCollectionReadQuery>(m =>
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
        var query = new GetAllPostLikesQuery(
            ValidPostLikeCurrentUserId,
            ValidUserName,
            ValidPostLikePostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == ValidId &&
                                                           m.UserId == ValidPostLikeCurrentUserId &&
                                                           m.UserName == ValidUserName &&
                                                           m.UserProfileImage == ValidUserProfileImage &&
                                                           m.PostId == ValidPostLikePostId) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
