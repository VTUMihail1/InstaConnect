using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.Features.Users.Queries.GetAllUsers;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Data.Features.Users.Models.Filters;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Queries.GetAllUsers;

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
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await UserReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<UserCollectionReadQuery>(m =>
                                                                        m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                        m.LastName == UserTestUtilities.ValidLastName &&
                                                                        m.UserName == UserTestUtilities.ValidName &&
                                                                        m.Page == ValidPageValue &&
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
