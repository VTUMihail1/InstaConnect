using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
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
        var existingFollowerId = CreateUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingFollowerId, existingFollowingId);
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
        var existingFollowerId = CreateUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingFollowerId, existingFollowingId);
        var query = new GetFollowByIdQuery(existingFollowId);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await FollowReadRepository
            .Received(1)
            .GetByIdAsync(existingFollowId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingFollowerId = CreateUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingFollowerId, existingFollowingId);
        var query = new GetFollowByIdQuery(existingFollowId);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowQueryViewModel>(m => m.Id == existingFollowId &&
                                              m.FollowerId == existingFollowerId &&
                                              m.FollowerName == UserTestUtilities.ValidName &&
                                              m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                              m.FollowingId == existingFollowingId &&
                                              m.FollowingName == UserTestUtilities.ValidName &&
                                              m.FollowingProfileImage == UserTestUtilities.ValidProfileImage);
    }
}
