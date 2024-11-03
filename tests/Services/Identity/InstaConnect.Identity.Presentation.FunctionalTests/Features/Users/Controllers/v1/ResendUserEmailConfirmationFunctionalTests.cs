using System.Net;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Web.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Emails;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Web.FunctionalTests.Features.Users.Controllers.v1;

public class ResendUserEmailConfirmationFunctionalTests : BaseUserFunctionalTest
{
    public ResendUserEmailConfirmationFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(UserBusinessConfigurations.EMAIL_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.EMAIL_MAX_LENGTH + 1)]
    public async Task ResendConfirmEmailAsync_ShouldReturnBadRequestResponse_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetApiRoute(SharedTestUtilities.GetString(length)), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task ResendConfirmEmailAsync_ShouldReturnNotFoundResponse_WhenEmailIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetApiRoute(UserTestUtilities.InvalidEmail), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task ResendConfirmEmailAsync_ShouldReturnBadRequestResponse_WhenEmailIsAlreadyConfirmed()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetApiRoute(UserTestUtilities.ValidEmail), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task ResendConfirmEmailAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetApiRoute(UserTestUtilities.ValidEmail), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task ResendConfirmEmailAsync_ShouldAddEmailConfirmationTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);

        // Act
        await HttpClient.GetAsync(GetApiRoute(UserTestUtilities.ValidEmail), CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        user!
            .EmailConfirmationTokens
            .Should()
            .NotBeEmpty();
    }

    [Fact]
    public async Task ResendConfirmEmailAsync_ShouldPublishUserConfirmEmailTokenCreatedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);

        // Act
        await HttpClient.GetAsync(GetApiRoute(UserTestUtilities.ValidEmail), CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);
        var url = string.Format(EmailConfirmationOptions.UrlTemplate, existingUserId, user!.EmailConfirmationTokens.FirstOrDefault()!.Value);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserConfirmEmailTokenCreatedEvent>(m =>
                              m.Context.Message.Email == UserTestUtilities.ValidEmail &&
                              m.Context.Message.RedirectUrl == url, CancellationToken);
        // Assert
        result.Should().BeTrue();
    }

    private string GetApiRoute(string email)
    {
        var routeTemplate = "{0}/by-email/{1}/confirm-email";

        var route = string.Format(
            routeTemplate,
            ApiRoute,
            email);

        return route;
    }
}
