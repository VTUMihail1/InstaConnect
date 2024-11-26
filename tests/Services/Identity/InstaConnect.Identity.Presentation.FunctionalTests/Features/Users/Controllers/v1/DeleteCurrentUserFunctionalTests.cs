using System.Net;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class DeleteCurrentUserFunctionalTests : BaseUserFunctionalTest
{
    public DeleteCurrentUserFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.DeleteAsync(GetApiRoute(), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldReturnBadRequestResponse_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(GetApiRoute(), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task DeleteCurrentAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = SharedTestUtilities.GetString(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(GetApiRoute(), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = UserTestUtilities.InvalidId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(GetApiRoute(), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.DeleteAsync(GetApiRoute(), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldDeleteCurrentUser_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        await HttpClient.DeleteAsync(GetApiRoute(), CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        user
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldPublishUserDeletedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        await HttpClient.DeleteAsync(GetApiRoute(), CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserDeletedEvent>(m =>
                              m.Context.Message.Id == existingUserId, CancellationToken);

        // Assert
        result.Should().BeTrue();
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
