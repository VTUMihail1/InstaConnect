using System.Globalization;
using System.Net;

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

public class GetCurrentDetailedUserFunctionalTests : BaseUserFunctionalTest
{
    public GetCurrentDetailedUserFunctionalTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task GetCurrentDetailed_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentDetailedUserRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.GetCurrentDetailedStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetCurrentDetailed_ShouldReturnBadRequestResponse_WhenIdIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentDetailedUserRequest(
            null
        );

        // Act
        var response = await UsersClient.GetCurrentDetailedStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetCurrentDetailed_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentDetailedUserRequest(
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await UsersClient.GetCurrentDetailedStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetCurrentDetailed_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentDetailedUserRequest(
            UserTestUtilities.InvalidId
        );

        // Act
        var response = await UsersClient.GetCurrentDetailedStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetCurrentDetailed_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentDetailedUserRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.GetCurrentDetailedStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetCurrentDetailed_ShouldReturnUserViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentDetailedUserRequest(existingUser.Id
        );

        // Act
        var response = await UsersClient.GetCurrentDetailedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserDetailedQueryResponse>(m => m.Id == existingUser.Id &&
                                          m.Email == existingUser.Email &&
                                          m.UserName == existingUser.UserName &&
                                          m.FirstName == existingUser.FirstName &&
                                          m.LastName == existingUser.LastName &&
                                          m.ProfileImage == existingUser.ProfileImage);
    }

    [Fact]
    public async Task GetCurrentDetailed_ShouldReturnUserViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentDetailedUserRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingUser.Id)
        );

        // Act
        var response = await UsersClient.GetCurrentDetailedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserDetailedQueryResponse>(m => m.Id == existingUser.Id &&
                                          m.Email == existingUser.Email &&
                                          m.UserName == existingUser.UserName &&
                                          m.FirstName == existingUser.FirstName &&
                                          m.LastName == existingUser.LastName &&
                                          m.ProfileImage == existingUser.ProfileImage);
    }

    [Fact]
    public async Task GetCurrentDetailed_ShouldSaveUserViewModelCollectionToCacheService_WhenQueryIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetCurrentDetailedUserRequest(
            existingUser.Id
        );
        var queryKey = string.Format(
            CultureInfo.InvariantCulture,
            UserCacheKeys.GetCurrentDetailedUser,
            existingUser.Id);

        // Act
        await UsersClient.GetCurrentDetailedAsync(request, CancellationToken);

        var response = await CacheHandler.GetAsync<UserDetailedQueryViewModel>(queryKey, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserDetailedQueryViewModel>(m => m.Id == existingUser.Id &&
                                          m.Email == existingUser.Email &&
                                          m.UserName == existingUser.UserName &&
                                          m.FirstName == existingUser.FirstName &&
                                          m.LastName == existingUser.LastName &&
                                          m.ProfileImage == existingUser.ProfileImage);
    }
}
