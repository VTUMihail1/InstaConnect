using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class GetCurrentDetailedUserFunctionalTests : BaseUserFunctionalTest
{
    public GetCurrentDetailedUserFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task GetCurrentDetailed_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetApiRoute(), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetCurrentDetailed_ShouldReturnBadRequestResponse_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetCurrentDetailed_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = SharedTestUtilities.GetString(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetCurrentDetailed_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = UserTestUtilities.InvalidId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetCurrentDetailed_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetCurrentDetailed_ShouldReturnUserViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(), CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserDetailedQueryViewModel>();

        // Assert
        userViewResponse
            .Should()
            .Match<UserDetailedQueryViewModel>(m => m.Id == existingUserId &&
                                                                    m.Email == UserTestUtilities.ValidEmail &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetCurrentDetailed_ShouldReturnUserViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = SharedTestUtilities.GetNonCaseMatchingString(existingUserId);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(), CancellationToken);

        var result = await response
            .Content
            .ReadFromJsonAsync<UserDetailedQueryViewModel>();

        // Assert
        result
            .Should()
            .Match<UserDetailedQueryViewModel>(m => m.Id == existingUserId &&
                                                                    m.Email == UserTestUtilities.ValidEmail &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetCurrentDetailed_ShouldSaveUserViewModelCollectionToCacheService_WhenQueryIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;
        var queryKey = string.Format(UserCacheKeys.GetCurrentDetailedUser, existingUserId);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        await HttpClient.GetAsync(GetApiRoute(), CancellationToken);

        var result = await CacheHandler.GetAsync<UserDetailedQueryViewModel>(queryKey, CancellationToken);

        // Assert
        result
            .Should()
            .Match<UserDetailedQueryViewModel>(m => m.Id == existingUserId &&
                                          m.Email == UserTestUtilities.ValidEmail &&
                                          m.UserName == UserTestUtilities.ValidName &&
                                          m.FirstName == UserTestUtilities.ValidFirstName &&
                                          m.LastName == UserTestUtilities.ValidLastName &&
                                          m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    private string GetApiRoute()
    {
        var routeTemplate = "{0}/current/detailed";

        var route = string.Format(
            routeTemplate,
            ApiRoute);

        return route;
    }
}
