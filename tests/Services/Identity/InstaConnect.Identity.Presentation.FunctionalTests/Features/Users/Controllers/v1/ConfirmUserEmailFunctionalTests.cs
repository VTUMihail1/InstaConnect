using System.Net;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Web.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Web.FunctionalTests.Features.Users.Controllers.v1;

public class ConfirmUserEmailFunctionalTests : BaseUserFunctionalTest
{
    public ConfirmUserEmailFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task ConfirmEmailAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(SharedTestUtilities.GetString(length), existingEmailConfirmationTokenValue), null, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserBusinessConfigurations.TOKEN_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.TOKEN_MAX_LENGTH + 1)]
    public async Task ConfirmEmailAsync_ShouldReturnBadRequestResponse_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(existingUserId, SharedTestUtilities.GetString(length)), null, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task ConfirmEmailAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(UserTestUtilities.InvalidId, existingEmailConfirmationTokenValue), null, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task ConfirmEmailAsync_ShouldReturnBadRequestResponse_WhenEmailIsAlreadyConfirmed()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(existingUserId, existingEmailConfirmationTokenValue), null, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task ConfirmEmailAsync_ShouldReturnNotFoundResponse_WhenTokenIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(existingUserId, UserTestUtilities.InvalidEmailConfirmationTokenValue), null, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task ConfirmEmailAsync_ShouldReturnForbiddenResponse_WhenUserDoesNotOwnToken()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenUserId = await CreateUserAsync(CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingEmailConfirmationTokenUserId, UserTestUtilities.ValidUntil, CancellationToken);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(existingUserId, existingEmailConfirmationTokenValue), null, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task ConfirmEmailAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(existingUserId, existingEmailConfirmationTokenValue), null, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task ConfirmEmailAsync_ShouldRemoveEmailConfirmationTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);

        // Act
        await HttpClient.PostAsync(GetApiRoute(existingUserId, existingEmailConfirmationTokenValue), null!, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        user!
            .EmailConfirmationTokens
            .Should()
            .BeEmpty();
    }



    private string GetApiRoute(string id, string token)
    {
        var routeTemplate = "{0}/{1}/confirm-email/{2}";

        var route = string.Format(
            routeTemplate,
            ApiRoute,
            id,
            token);

        return route;
    }
}
