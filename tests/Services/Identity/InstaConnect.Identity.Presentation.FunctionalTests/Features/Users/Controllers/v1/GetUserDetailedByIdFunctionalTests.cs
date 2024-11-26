using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class GetDetailedByIdFunctionalTests : BaseUserFunctionalTest
{
    public GetDetailedByIdFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task GetDetailedById_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetApiRoute(existingUserId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetDetailedById_ShouldReturnForbiddenResponse_WhenUserIsNotAdmin()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(existingUserId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Forbidden);
    }

    [Theory]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task GetDetailedById_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[AppClaims.Admin] = AppClaims.Admin;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(SharedTestUtilities.GetString(length)), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetDetailedById_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[AppClaims.Admin] = AppClaims.Admin;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(UserTestUtilities.InvalidId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetDetailedById_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[AppClaims.Admin] = AppClaims.Admin;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(existingUserId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetDetailedById_ShouldReturnUserViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[AppClaims.Admin] = AppClaims.Admin;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(existingUserId), CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserDetailedQueryResponse>();

        // Assert
        userViewResponse
            .Should()
            .Match<UserDetailedQueryResponse>(m => m.Id == existingUserId &&
                                                                    m.Email == UserTestUtilities.ValidEmail &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetDetailedById_ShouldReturnUserViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[AppClaims.Admin] = AppClaims.Admin;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(SharedTestUtilities.GetNonCaseMatchingString(existingUserId)), CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserDetailedQueryResponse>();

        // Assert
        userViewResponse
            .Should()
            .Match<UserDetailedQueryResponse>(m => m.Id == existingUserId &&
                                                                    m.Email == UserTestUtilities.ValidEmail &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    private string GetApiRoute(string id)
    {
        var routeTemplate = "{0}/{1}/detailed";

        var route = string.Format(
            routeTemplate,
            ApiRoute,
            id);

        return route;
    }
}
