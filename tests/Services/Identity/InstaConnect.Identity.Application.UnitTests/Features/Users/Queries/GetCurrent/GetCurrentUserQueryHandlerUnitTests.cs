using FluentAssertions;

using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrent;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Users;

using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Queries.GetCurrent;

public class GetCurrentUserQueryHandlerUnitTests : BaseUserUnitTest
{
    private readonly GetCurrentUserQueryHandler _queryHandler;

    public GetCurrentUserQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            UserReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var query = new GetCurrentUserQuery(UserTestUtilities.InvalidId);

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
        var query = new GetCurrentUserQuery(existingUser.Id);

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
        var query = new GetCurrentUserQuery(existingUser.Id);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserQueryViewModel>(m => m.Id == existingUser.Id &&
                                            m.UserName == existingUser.UserName &&
                                            m.FirstName == existingUser.FirstName &&
                                            m.LastName == existingUser.LastName &&
                                            m.ProfileImage == existingUser.ProfileImage);
    }
}
