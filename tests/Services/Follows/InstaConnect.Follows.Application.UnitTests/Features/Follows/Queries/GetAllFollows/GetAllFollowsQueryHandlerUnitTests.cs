﻿using FluentAssertions;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Application.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Filters;
using NSubstitute;

namespace InstaConnect.Follows.Application.UnitTests.Features.Follows.Queries.GetAllFollows;

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
        var existingFollow = CreateFollow();
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            UserTestUtilities.ValidName,
            existingFollow.FollowingId,
            UserTestUtilities.ValidName,
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
                                                                        m.FollowerId == existingFollow.FollowerId &&
                                                                        m.FollowerName == UserTestUtilities.ValidName &&
                                                                        m.FollowingId == existingFollow.FollowingId &&
                                                                        m.FollowingName == UserTestUtilities.ValidName &&
                                                                        m.Page == FollowTestUtilities.ValidPageValue &&
                                                                        m.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == FollowTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == FollowTestUtilities.ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            UserTestUtilities.ValidName,
            existingFollow.FollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingFollow.Id &&
                                                           m.FollowerId == existingFollow.FollowerId &&
                                                           m.FollowerName == UserTestUtilities.ValidName &&
                                                           m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                           m.FollowingId == existingFollow.FollowingId &&
                                                           m.FollowingName == UserTestUtilities.ValidName &&
                                                           m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == FollowTestUtilities.ValidPageValue &&
                                                           mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
