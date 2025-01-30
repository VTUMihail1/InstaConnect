using FluentAssertions;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Application.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Follow;
using NSubstitute;

namespace InstaConnect.Follows.Application.UnitTests.Features.Follows.Queries.GetFollowById;

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
        var existingFollow = CreateFollow();
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
        var existingFollow = CreateFollow();
        var query = new GetFollowByIdQuery(existingFollow.Id);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await FollowReadRepository
            .Received(1)
            .GetByIdAsync(existingFollow.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var query = new GetFollowByIdQuery(existingFollow.Id);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowQueryViewModel>(m => m.Id == existingFollow.Id &&
                                              m.FollowerId == existingFollow.FollowerId &&
                                              m.FollowerName == UserTestUtilities.ValidName &&
                                              m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                              m.FollowingId == existingFollow.FollowingId &&
                                              m.FollowingName == UserTestUtilities.ValidName &&
                                              m.FollowingProfileImage == UserTestUtilities.ValidProfileImage);
    }
}
