using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Features.Users.Models.Bindings;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class ResetUserPasswordFunctionalTests : BaseUserFunctionalTest
{
    public ResetUserPasswordFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task ResetPasswordAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var request = new ResetUserPasswordBindingModel(UserTestUtilities.ValidPassword, UserTestUtilities.ValidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(SharedTestUtilities.GetString(length), existingForgotPasswordTokenValue), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserBusinessConfigurations.TOKEN_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.TOKEN_MAX_LENGTH + 1)]
    public async Task ResetPasswordAsync_ShouldReturnBadRequestResponse_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var request = new ResetUserPasswordBindingModel(UserTestUtilities.ValidPassword, UserTestUtilities.ValidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(existingUserId, SharedTestUtilities.GetString(length)), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task ResetPasswordAsync_ShouldReturnBadRequestResponse_WhenPasswordIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var request = new ResetUserPasswordBindingModel(null!, null!);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(existingUserId, existingForgotPasswordTokenValue), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.PASSWORD_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.PASSWORD_MAX_LENGTH + 1)]
    public async Task ResetPasswordAsync_ShouldReturnBadRequestResponse_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var invalidPassword = SharedTestUtilities.GetString(length);
        var request = new ResetUserPasswordBindingModel(invalidPassword, invalidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(existingUserId, existingForgotPasswordTokenValue), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task ResetPasswordAsync_ShouldReturnBadRequestResponse_WhenPasswordDoesNotMatchConfirmPassword()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var request = new ResetUserPasswordBindingModel(UserTestUtilities.ValidPassword, UserTestUtilities.InvalidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(existingUserId, existingForgotPasswordTokenValue), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task ResetPasswordAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var request = new ResetUserPasswordBindingModel(UserTestUtilities.ValidPassword, UserTestUtilities.ValidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(UserTestUtilities.InvalidId, existingForgotPasswordTokenValue), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task ResetPasswordAsync_ShouldReturnNotFoundResponse_WhenTokenIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var request = new ResetUserPasswordBindingModel(UserTestUtilities.ValidPassword, UserTestUtilities.ValidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(existingUserId, UserTestUtilities.InvalidForgotPasswordTokenValue), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task ResetPasswordAsync_ShouldReturnForbiddenResponse_WhenUserDoesNotOwnToken()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenUserId = await CreateUserAsync(CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingForgotPasswordTokenUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var request = new ResetUserPasswordBindingModel(UserTestUtilities.ValidPassword, UserTestUtilities.ValidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(existingUserId, existingForgotPasswordTokenValue), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task ResetPasswordAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var request = new ResetUserPasswordBindingModel(UserTestUtilities.ValidPassword, UserTestUtilities.ValidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(existingUserId, existingForgotPasswordTokenValue), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task ResetPasswordAsync_ShouldRemoveForgotPasswordTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var request = new ResetUserPasswordBindingModel(UserTestUtilities.ValidPassword, UserTestUtilities.ValidPassword);

        // Act
        await HttpClient.PostAsJsonAsync(GetApiRoute(existingUserId, existingForgotPasswordTokenValue), request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        user!
            .ForgotPasswordTokens
            .Should()
            .BeEmpty();
    }



    private string GetApiRoute(string id, string token)
    {
        var routeTemplate = "{0}/{1}/reset-password/{2}";

        var route = string.Format(
            routeTemplate,
            ApiRoute,
            id,
            token);

        return route;
    }
}
