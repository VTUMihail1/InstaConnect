using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Features.Users.Models.Bindings;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class LoginUserFunctionalTests : BaseUserFunctionalTest
{
    public LoginUserFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenEmailIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new LoginUserBody(
            null!,
            UserTestUtilities.ValidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.EmailMinLength - 1)]
    [InlineData(UserConfigurations.EmailMaxLength + 1)]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenEmailengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new LoginUserBody(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenPasswordIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new LoginUserBody(
            UserTestUtilities.ValidPassword,
            null!);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.PasswordMinLength - 1)]
    [InlineData(UserConfigurations.PasswordMaxLength + 1)]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new LoginUserBody(
            UserTestUtilities.ValidEmail,
            SharedTestUtilities.GetString(length));

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenEmailIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new Body(
            UserTestUtilities.InvalidEmail,
            UserTestUtilities.ValidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenPasswordIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new Body(
            UserTestUtilities.ValidEmail,
            UserTestUtilities.InvalidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenEmailIsNotConfirmed()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var request = new LoginUserBody(
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new LoginUserBody(
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(), request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task LoginAsync_ShouldLoginUser_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new LoginUserBody(
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword);

        // Act
        var response = await HttpClient.PostAsJsonAsync(GetApiRoute(), request, CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserTokenCommandResponse>();

        // Assert
        userViewResponse
            .Should()
            .Match<UserTokenCommandResponse>(p => !string.IsNullOrEmpty(p.Value) && p.ValidUntil != default);
    }

    private string GetApiRoute()
    {
        var routeTemplate = "{0}/login";

        var route = string.Format(
            routeTemplate,
            ApiRoute);

        return route;
    }
}
