using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Shared.Common.Exceptions.Follow;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Queries.GetFollowById;

public class GetFollowByIdQueryHandlerUnitTests : BaseFollowUnitTest
{
    private readonly GetFollowByIdQueryHandler _queryHandler;

    public GetFollowByIdQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            FollowReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowFollowNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetFollowByIdQuery(FollowTestUtilities.InvalidId);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<FollowNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetFollowByIdQuery(FollowTestUtilities.ValidId);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await FollowReadRepository
            .Received(1)
            .GetByIdAsync(FollowTestUtilities.ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetFollowByIdQuery(FollowTestUtilities.ValidId);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowQueryViewModel>(m => m.Id == FollowTestUtilities.ValidId &&
                                              m.FollowerId == FollowTestUtilities.ValidFollowCurrentUserId &&
                                              m.FollowerName == FollowTestUtilities.ValidUserName &&
                                              m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                              m.FollowingId == FollowTestUtilities.ValidFollowFollowingId &&
                                              m.FollowingName == FollowTestUtilities.ValidUserName &&
                                              m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage);
    }
}
