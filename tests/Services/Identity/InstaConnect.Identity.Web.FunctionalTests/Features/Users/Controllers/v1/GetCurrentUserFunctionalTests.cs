﻿using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Web.Features.Users.Models.Responses;
using InstaConnect.Identity.Web.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Web.FunctionalTests.Features.Users.Controllers.v1;

public class GetCurrentUserFunctionalTests : BaseUserFunctionalTest
{
    public GetCurrentUserFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task GetCurrent_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetApiRoute(), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetCurrent_ShouldReturnBadRequestResponse_WhenIdIsNull()
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
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task GetCurrent_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
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
    public async Task GetCurrent_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
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
    public async Task GetCurrent_ShouldReturnOkResponse_WhenRequestIsValid()
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
    public async Task GetCurrent_ShouldReturnUserViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(), CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserQueryResponse>();

        // Assert
        userViewResponse
            .Should()
            .Match<UserQueryResponse>(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetCurrent_ShouldReturnUserViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = SharedTestUtilities.GetNonCaseMatchingString(existingUserId);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(GetApiRoute(), CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserQueryResponse>();

        // Assert
        userViewResponse
            .Should()
            .Match<UserQueryResponse>(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetCurrent_ShouldSaveUserViewModelCollectionToCacheService_WhenQueryIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;
        var queryKey = string.Format(UserCacheKeys.GetCurrentUser, existingUserId);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        await HttpClient.GetAsync(GetApiRoute(), CancellationToken);

        var result = await CacheHandler.GetAsync<UserQueryViewModel>(queryKey, CancellationToken);

        // Assert
        result
            .Should()
            .Match<UserQueryViewModel>(m => m.Id == existingUserId &&
                                          m.UserName == UserTestUtilities.ValidName &&
                                          m.FirstName == UserTestUtilities.ValidFirstName &&
                                          m.LastName == UserTestUtilities.ValidLastName &&
                                          m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    private string GetApiRoute()
    {
        var routeTemplate = "{0}/current";

        var route = string.Format(
            routeTemplate,
            ApiRoute);

        return route;
    }
}
