using InstaConnect.Identity.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class GetAllUsersFunctionalTests : BaseUserFunctionalTest
{
    public GetAllUsersFunctionalTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(UserConfigurations.FirstNameMinLength - 1)]
    [InlineData(UserConfigurations.FirstNameMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            SharedTestUtilities.GetString(length),
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.LastNameMinLength - 1)]
    [InlineData(UserConfigurations.LastNameMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenLastNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            existingUser.FirstName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            SharedTestUtilities.GetString(length),
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserDoesNotContainProperty()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.InvalidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.SortPropertyMinLength - 1)]
    [InlineData(SharedConfigurations.SortPropertyMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            value,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }



    [Theory]
    [InlineData(SharedConfigurations.PageSizeMinValue - 1)]
    [InlineData(SharedConfigurations.PageSizeMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            value);

        // Act
        var response = await UsersClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUserPaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUserPaginationCollectionResponse_WhenRequestIsValidAndFirstNameCaseDoesNotMatch()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingUser.FirstName),
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUserPaginationCollectionResponse_WhenRequestIsValidAndLastNameCaseDoesNotMatch()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            existingUser.FirstName,
            SharedTestUtilities.GetNonCaseMatchingString(existingUser.LastName),
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUserPaginationCollectionResponse_WhenRequestIsValidAndNameCaseDoesNotMatch()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingUser.UserName),
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUserPaginationCollectionResponse_WhenRequestIsValidAndFirstNameIsNotFull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            SharedTestUtilities.GetHalfStartString(existingUser.FirstName),
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUserPaginationCollectionResponse_WhenRequestIsValidAndLastNameIsNotFull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            existingUser.FirstName,
            SharedTestUtilities.GetHalfStartString(existingUser.LastName),
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUserPaginationCollectionResponse_WhenRequestIsValidAndNameIsNotFull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetAllUsersRequest(
            SharedTestUtilities.GetHalfStartString(existingUser.UserName),
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await UsersClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUserPaginationCollectionResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);

        // Act
        var response = await UsersClient.GetAllAsync(CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
