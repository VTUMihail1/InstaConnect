using InstaConnect.Identity.Application.Features.Users.Queries.GetDetailedById;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Queries.GetDetailedById;

public class GetDetailedUserByIdQueryHandlerUnitTests : BaseUserUnitTest
{
    private readonly GetDetailedUserByIdQueryHandler _queryHandler;

    public GetDetailedUserByIdQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            UserReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetDetailedUserByIdQuery(UserTestUtilities.InvalidId);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var query = new GetDetailedUserByIdQuery(existingUser.Id);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await UserReadRepository
            .Received(1)
            .GetByIdAsync(existingUser.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnUserViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var query = new GetDetailedUserByIdQuery(existingUser.Id);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserDetailedQueryViewModel>(m => m.Id == existingUser.Id &&
                                            m.UserName == existingUser.UserName &&
                                            m.FirstName == existingUser.FirstName &&
                                            m.LastName == existingUser.LastName &&
                                            m.Email == existingUser.Email &&
                                            m.ProfileImage == existingUser.ProfileImage);
    }
}
