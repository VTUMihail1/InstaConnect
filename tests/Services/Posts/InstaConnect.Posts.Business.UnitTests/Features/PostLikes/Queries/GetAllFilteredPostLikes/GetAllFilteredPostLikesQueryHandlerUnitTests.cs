using System.Linq.Expressions;
using FluentAssertions;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllFilteredPostLikes;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetAllFilteredPosts;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Filters;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Posts.Models.Filters;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Queries.GetAllFilteredFollows;

public class GetAllFilteredPostLikesQueryHandlerUnitTests : BasePostLikeUnitTest
{
    private readonly GetAllFilteredPostLikesQueryHandler _queryHandler;

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
        var query = new GetAllFilteredPostLikesQuery(
            ValidPostLikeCurrentUserId,
            ValidTitle,
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
            .GetAllFilteredAsync(Arg.Is<PostLikeFilteredCollectionReadQuery>(m =>
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
        var query = new GetAllFilteredPostLikesQuery(
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
