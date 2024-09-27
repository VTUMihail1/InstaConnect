using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserByName;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Queries.GetUserByName;

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
        var query = new GetUserByNameQuery(InvalidName);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByNameMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetUserByNameQuery(ValidName);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await UserReadRepository
            .Received(1)
            .GetByNameAsync(ValidName, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnUserViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetUserByNameQuery(ValidName);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserQueryViewModel>(m => m.Id == ValidId &&
                                            m.UserName == ValidName &&
                                            m.FirstName == ValidFirstName &&
                                            m.LastName == ValidLastName &&
                                            m.ProfileImage == ValidProfileImage);
    }
}
