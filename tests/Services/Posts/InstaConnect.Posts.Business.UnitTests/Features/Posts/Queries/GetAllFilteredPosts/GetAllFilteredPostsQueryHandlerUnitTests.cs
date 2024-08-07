using System.Linq.Expressions;
using FluentAssertions;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetAllFilteredPosts;
using InstaConnect.Posts.Business.UnitTests.Features.Posts.Utilities;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Posts.Models.Filters;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.Posts.Queries.GetAllFilteredPosts;

public class GetAllFilteredPostsQueryHandlerUnitTests : BasePostUnitTest
{
    private readonly GetAllPostsQueryHandler _queryHandler;

    public GetAllFilteredPostsQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetAllMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllPostsQuery(
            ValidPostCurrentUserId,
            ValidTitle,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        Expression<Func<Post, bool>> expectedExpression = p =>
             (string.IsNullOrEmpty(ValidPostCurrentUserId) || p.UserId.Equals(ValidPostCurrentUserId)) &&
             (string.IsNullOrEmpty(ValidUserName) || p.User!.UserName.Equals(ValidUserName)) &&
             (string.IsNullOrEmpty(ValidTitle) || p.Title.Equals(ValidTitle));

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<PostFilteredCollectionReadQuery>(m =>
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
        var query = new GetAllPostsQuery(
            ValidPostCurrentUserId,
            ValidTitle,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == ValidId &&
                                                           m.UserId == ValidPostCurrentUserId &&
                                                           m.UserName == ValidUserName &&
                                                           m.UserProfileImage == ValidUserProfileImage &&
                                                           m.Title == ValidTitle &&
                                                           m.Content == ValidContent) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
