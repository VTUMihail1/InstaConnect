using FluentAssertions;

using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Filters;

using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Queries.GetAll;

public class GetAllUsersQueryHandlerUnitTests : BaseUserUnitTest
{
    private readonly GetAllUsersQueryHandler _queryHandler;

    public GetAllUsersQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            UserReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetAllMethod_WhenQueryIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await UserReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<UserCollectionReadQuery>(m =>
                                                                        m.FirstName == existingUser.FirstName &&
                                                                        m.LastName == existingUser.LastName &&
                                                                        m.UserName == existingUser.UserName &&
                                                                        m.Page == UserTestUtilities.ValidPageValue &&
                                                                        m.Page == UserTestUtilities.ValidPageValue &&
                                                                        m.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == UserTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == UserTestUtilities.ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                           m.UserName == existingUser.UserName &&
                                                           m.ProfileImage == existingUser.ProfileImage &&
                                                           m.FirstName == existingUser.FirstName &&
                                                           m.LastName == existingUser.LastName) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
