using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetByName;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Queries.GetByName;

public class GetUserByNameQueryHandlerUnitTests : BaseUserUnitTest
{
    private readonly GetUserByNameQueryHandler _queryHandler;

    public GetUserByNameQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            UserReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenNameIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var query = new GetUserByNameQuery(UserTestUtilities.ValidAddName);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByNameMethod_WhenQueryIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var query = new GetUserByNameQuery(existingUser.UserName);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await UserReadRepository
            .Received(1)
            .GetByNameAsync(existingUser.UserName, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnUserViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var query = new GetUserByNameQuery(existingUser.UserName);

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
