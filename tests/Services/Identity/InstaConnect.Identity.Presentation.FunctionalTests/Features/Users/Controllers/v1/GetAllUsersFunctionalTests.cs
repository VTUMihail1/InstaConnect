using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class GetAllUsersFunctionalTests : BaseUserFunctionalTest
{
    public GetAllUsersFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserBusinessConfigurations.LAST_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenLastNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            UserTestUtilities.ValidFirstName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserBusinessConfigurations.USER_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.USER_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserDoesNotContainProperty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.InvalidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.SortPropertyMinLength - 1)]
    [InlineData(SharedConfigurations.SortPropertyMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            value,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }



    [Theory]
    [InlineData(SharedConfigurations.PageSizeMinValue - 1)]
    [InlineData(SharedConfigurations.PageSizeMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            value);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUserPaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var userPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<UserPaginationQueryResponse>();

        // Assert
        userPaginationCollectionResponse
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidFirstName),
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var userPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<UserPaginationQueryResponse>();

        // Assert
        userPaginationCollectionResponse
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            UserTestUtilities.ValidFirstName,
            SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidLastName),
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var userPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<UserPaginationQueryResponse>();

        // Assert
        userPaginationCollectionResponse
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var userPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<UserPaginationQueryResponse>();

        // Assert
        userPaginationCollectionResponse
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidFirstName),
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var userPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<UserPaginationQueryResponse>();

        // Assert
        userPaginationCollectionResponse
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            UserTestUtilities.ValidFirstName,
            SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidLastName),
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var userPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<UserPaginationQueryResponse>();

        // Assert
        userPaginationCollectionResponse
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var route = GetApiRoute(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidName),
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var userPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<UserPaginationQueryResponse>();

        // Assert
        userPaginationCollectionResponse
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(ApiRoute, CancellationToken);

        var userPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<UserPaginationQueryResponse>();

        // Assert
        userPaginationCollectionResponse
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    private string GetApiRoute(string firstName, string lastName, string userName, SortOrder sortOrder, string sortPropertyName, int page, int pageSize)
    {
        var routeTemplate = "{0}?firstName={1}&lastName={2}&userName={3}&sortOrder={4}&sortPropertyName={5}&page={6}&pageSize={7}";

        var route = string.Format(
            routeTemplate,
            ApiRoute,
            firstName,
            lastName,
            userName,
            sortOrder,
            sortPropertyName,
            page,
            pageSize);

        return route;
    }
}
