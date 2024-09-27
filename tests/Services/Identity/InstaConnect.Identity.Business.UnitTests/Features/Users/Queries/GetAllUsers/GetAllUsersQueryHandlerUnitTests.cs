using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.Features.Users.Queries.GetAllUsers;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
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
            ValidName,
            ValidFirstName,
            ValidLastName,
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
                                                                        m.FirstName == ValidFirstName &&
                                                                        m.LastName == ValidLastName &&
                                                                        m.UserName == ValidName &&
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
            ValidName,
            ValidFirstName,
            ValidLastName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == ValidId &&
                                                           m.Id == ValidId &&
                                                           m.UserName == ValidName &&
                                                           m.ProfileImage == ValidProfileImage &&
                                                           m.FirstName == ValidFirstName &&
                                                           m.LastName == ValidLastName) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
