using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
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
            FollowTestUtilities.ValidFollowCurrentUserId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidFollowFollowingId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await FollowReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<FollowCollectionReadQuery>(m =>
                                                                        m.FollowerId == FollowTestUtilities.ValidFollowCurrentUserId &&
                                                                        m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                        m.FollowingId == FollowTestUtilities.ValidFollowFollowingId &&
                                                                        m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                                        m.Page == FollowTestUtilities.ValidPageValue &&
                                                                        m.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == FollowTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == FollowTestUtilities.ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllFollowsQuery(
            FollowTestUtilities.ValidFollowCurrentUserId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidFollowFollowingId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == FollowTestUtilities.ValidId &&
                                                           m.FollowerId == FollowTestUtilities.ValidFollowCurrentUserId &&
                                                           m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                           m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                           m.FollowingId == FollowTestUtilities.ValidFollowFollowingId &&
                                                           m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                           m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
