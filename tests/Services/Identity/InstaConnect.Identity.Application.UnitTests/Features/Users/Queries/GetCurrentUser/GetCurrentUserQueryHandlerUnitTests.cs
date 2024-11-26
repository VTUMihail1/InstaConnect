using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentUser;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Queries.GetCurrentUser;

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
        var query = new GetCurrentUserQuery(UserTestUtilities.ValidId);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await UserReadRepository
            .Received(1)
            .GetByIdAsync(UserTestUtilities.ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnUserViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetCurrentUserQuery(UserTestUtilities.ValidId);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserQueryViewModel>(m => m.Id == UserTestUtilities.ValidId &&
                                            m.UserName == UserTestUtilities.ValidName &&
                                            m.FirstName == UserTestUtilities.ValidFirstName &&
                                            m.LastName == UserTestUtilities.ValidLastName &&
                                            m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }
}
