using System.Linq.Expressions;
using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Follows.Data.Features.Follows.Models.Filters;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Queries.GetAllFollows;

public class GetAllFollowsQueryHandlerUnitTests : BaseFollowUnitTest
{
    private readonly GetAllFollowsQueryHandler _queryHandler;

    public GetAllFollowsQueryHandlerUnitTests()
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

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await FollowReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<FollowCollectionReadQuery>(m =>
                                                                        m.FollowerId == ValidFollowCurrentUserId &&
                                                                        m.FollowerName == ValidUserName &&
                                                                        m.FollowingId == ValidFollowFollowingId &&
                                                                        m.FollowingName == ValidUserName &&
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
