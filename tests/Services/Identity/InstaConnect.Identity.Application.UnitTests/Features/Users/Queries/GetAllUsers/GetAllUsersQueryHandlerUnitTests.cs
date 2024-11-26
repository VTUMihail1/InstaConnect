using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAllUsers;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Filters;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Queries.GetAllUsers;

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
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
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
                                                                        m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                        m.LastName == UserTestUtilities.ValidLastName &&
                                                                        m.UserName == UserTestUtilities.ValidName &&
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
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == UserTestUtilities.ValidId &&
                                                           m.Id == UserTestUtilities.ValidId &&
                                                           m.UserName == UserTestUtilities.ValidName &&
                                                           m.ProfileImage == UserTestUtilities.ValidProfileImage &&
                                                           m.FirstName == UserTestUtilities.ValidFirstName &&
                                                           m.LastName == UserTestUtilities.ValidLastName) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
