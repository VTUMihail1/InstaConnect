using System.Net;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class DeleteByIdUserFunctionalTests : BaseUserFunctionalTest
{
    public DeleteByIdUserFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act

        var response = await HttpClient.DeleteAsync(GetApiRoute(existingUserId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldReturnForbiddenResponse_WhenUserIsNotAdmin()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(GetApiRoute(existingUserId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Forbidden);
    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task DeleteByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;
        ValidJwtConfig[AppClaims.Admin] = AppClaims.Admin;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(GetApiRoute(SharedTestUtilities.GetString(length)), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;
        ValidJwtConfig[AppClaims.Admin] = AppClaims.Admin;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(GetApiRoute(UserTestUtilities.InvalidId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;
        ValidJwtConfig[AppClaims.Admin] = AppClaims.Admin;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(GetApiRoute(existingUserId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldDeleteByIdUser_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;
        ValidJwtConfig[AppClaims.Admin] = AppClaims.Admin;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        await HttpClient.DeleteAsync(GetApiRoute(existingUserId), CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        user
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldPublishUserDeletedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;
        ValidJwtConfig[AppClaims.Admin] = AppClaims.Admin;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        await HttpClient.DeleteAsync(GetApiRoute(existingUserId), CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserDeletedEvent>(m =>
                              m.Context.Message.Id == existingUserId, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }

    private string GetApiRoute(string id)
    {
        var routeTemplate = "{0}/{1}";

        var route = string.Format(
            routeTemplate,
            ApiRoute,
            id);

        return route;
    }
}
