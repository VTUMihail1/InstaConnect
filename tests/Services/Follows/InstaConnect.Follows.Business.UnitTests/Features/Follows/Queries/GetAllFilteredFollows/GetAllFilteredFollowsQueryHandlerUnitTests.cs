using System.Linq.Expressions;
using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFilteredFollows;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Follows.Data.Features.Follows.Models.Filters;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Queries.GetAllFilteredFollows;

public class GetAllFilteredFollowsQueryHandlerUnitTests : BaseFollowUnitTest
{
    private readonly GetAllFollowsQueryHandler _queryHandler;

    public GetAllFilteredFollowsQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            FollowReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetAllMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllFollowsQuery(
            ValidFollowCurrentUserId,
            ValidUserName,
            ValidFollowFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        Expression<Func<Follow, bool>> expectedExpression = f =>
             (string.IsNullOrEmpty(ValidFollowCurrentUserId) || f.FollowerId.Equals(ValidFollowCurrentUserId)) &&
             (string.IsNullOrEmpty(ValidUserName) || f.Follower!.UserName.Equals(ValidUserName)) &&
             (string.IsNullOrEmpty(ValidFollowFollowingId) || f.FollowingId.Equals(ValidFollowFollowingId)) &&
             (string.IsNullOrEmpty(ValidUserName) || f.Following!.UserName.Equals(ValidUserName));

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await FollowReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<FollowFilteredCollectionReadQuery>(m =>
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
        var query = new GetAllFollowsQuery(
            ValidFollowCurrentUserId,
            ValidUserName,
            ValidFollowFollowingId,
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
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == ValidId &&
                                                           m.FollowerId == ValidFollowCurrentUserId &&
                                                           m.FollowerName == ValidUserName &&
                                                           m.FollowerProfileImage == ValidUserProfileImage &&
                                                           m.FollowingId == ValidFollowFollowingId &&
                                                           m.FollowingName == ValidUserName &&
                                                           m.FollowingProfileImage == ValidUserProfileImage) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
