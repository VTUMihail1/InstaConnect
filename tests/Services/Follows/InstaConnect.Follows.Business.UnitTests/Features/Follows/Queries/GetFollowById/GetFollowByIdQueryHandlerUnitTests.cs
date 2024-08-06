using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Shared.Business.Exceptions.Follow;
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
        var query = new GetFollowByIdQuery(InvalidId);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<FollowNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetFollowByIdQuery(ValidId);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await FollowReadRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetFollowByIdQuery(ValidId);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowQueryViewModel>(m => m.Id == ValidId &&
                                              m.FollowerId == ValidFollowCurrentUserId &&
                                              m.FollowerName == ValidUserName &&
                                              m.FollowerProfileImage == ValidUserProfileImage &&
                                              m.FollowingId == ValidFollowFollowingId &&
                                              m.FollowingName == ValidUserName &&
                                              m.FollowingProfileImage == ValidUserProfileImage);
    }
}
