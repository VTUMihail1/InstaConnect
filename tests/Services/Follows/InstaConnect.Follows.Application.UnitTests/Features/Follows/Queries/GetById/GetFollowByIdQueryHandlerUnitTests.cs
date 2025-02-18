using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

namespace InstaConnect.Follows.Application.UnitTests.Features.Follows.Queries.GetById;

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
                                              m.FollowerName == existingFollow.Follower.UserName &&
                                              m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                              m.FollowingId == existingFollow.FollowingId &&
                                              m.FollowingName == existingFollow.Following.UserName &&
                                              m.FollowingProfileImage == existingFollow.Following.ProfileImage);
    }
}
