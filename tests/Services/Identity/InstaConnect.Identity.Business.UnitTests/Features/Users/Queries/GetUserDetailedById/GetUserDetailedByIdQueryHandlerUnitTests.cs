using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserDetailedById;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Queries.GetUserDetailedById;

public class GetUserDetailedByIdQueryHandlerUnitTests : BaseUserUnitTest
{
    private readonly GetUserDetailedByIdQueryHandler _queryHandler;

    public GetUserDetailedByIdQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            UserReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetUserDetailedByIdQuery(InvalidId);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetUserDetailedByIdQuery(ValidId);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await UserReadRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnUserViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetUserDetailedByIdQuery(ValidId);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserDetailedQueryViewModel>(m => m.Id == ValidId &&
                                            m.UserName == ValidName &&
                                            m.FirstName == ValidFirstName &&
                                            m.LastName == ValidLastName &&
                                            m.Email == ValidEmail &&
                                            m.ProfileImage == ValidProfileImage);
    }
}
