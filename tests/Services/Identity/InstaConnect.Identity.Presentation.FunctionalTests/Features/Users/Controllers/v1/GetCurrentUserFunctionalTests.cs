using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class GetCurrentUserFunctionalTests : BaseUserFunctionalTest
{
    public GetCurrentUserFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task GetCurrent_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentUserRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.GetCurrentStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetCurrent_ShouldReturnBadRequestResponse_WhenIdIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentUserRequest(
            null!
        );


        // Act
        var response = await UsersClient.GetCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetCurrent_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentUserRequest(SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await UsersClient.GetCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetCurrent_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentUserRequest(
            UserTestUtilities.InvalidId
        );

        // Act
        var response = await UsersClient.GetCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetCurrent_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentUserRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.GetCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetCurrent_ShouldReturnUserViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentUserRequest(existingUser.Id
        );

        // Act
        var response = await UsersClient.GetCurrentAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserQueryResponse>(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage);
    }

    [Fact]
    public async Task GetCurrent_ShouldReturnUserViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentUserRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingUser.Id)
        );

        // Act
        var response = await UsersClient.GetCurrentAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserQueryResponse>(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetCurrent_ShouldSaveUserViewModelCollectionToCacheService_WhenQueryIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentUserRequest(
            existingUser.Id
        );
        var queryKey = string.Format(UserCacheKeys.GetCurrentUser, existingUser.Id);

        // Act
        await UsersClient.GetCurrentAsync(request, CancellationToken);

        var response = await CacheHandler.GetAsync<UserQueryViewModel>(queryKey, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserQueryViewModel>(m => m.Id == existingUser.Id &&
                                          m.UserName == existingUser.UserName &&
                                          m.FirstName == existingUser.FirstName &&
                                          m.LastName == existingUser.LastName &&
                                          m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }
}
