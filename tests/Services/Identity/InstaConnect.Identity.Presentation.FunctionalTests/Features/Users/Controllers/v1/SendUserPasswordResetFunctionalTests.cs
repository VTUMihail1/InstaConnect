using System.Net;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Application.Contracts.Emails;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class SendUserPasswordResetFunctionalTests : BaseUserFunctionalTest
{
    public SendUserPasswordResetFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(UserConfigurations.EmailMinLength - 1)]
    [InlineData(UserConfigurations.EmailMaxLength + 1)]
    public async Task SendPasswordResetAsync_ShouldReturnBadRequestResponse_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetApiRoute(SharedTestUtilities.GetString(length)), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task SendPasswordResetAsync_ShouldReturnNotFoundResponse_WhenEmailIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetApiRoute(UserTestUtilities.InvalidEmail), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task SendPasswordResetAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetApiRoute(UserTestUtilities.ValidEmail), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task SendPasswordResetAsync_ShouldAddForgotPasswordTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        await HttpClient.GetAsync(GetApiRoute(UserTestUtilities.ValidEmail), CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        user!
            .ForgotPasswordTokens
            .Should()
            .NotBeEmpty();
    }

    [Fact]
    public async Task SendPasswordResetAsync_ShouldPublishUserForgotPasswordTokenCreatedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        await HttpClient.GetAsync(GetApiRoute(UserTestUtilities.ValidEmail), CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);
        var url = string.Format(ForgotPasswordOptions.UrlTemplate, existingUserId, user!.ForgotPasswordTokens.FirstOrDefault()!.Value);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserForgotPasswordTokenCreatedEvent>(m =>
                              m.Context.Message.Email == UserTestUtilities.ValidEmail &&
                              m.Context.Message.RedirectUrl == url, CancellationToken);
        // Assert
        result.Should().BeTrue();
    }

    private string GetApiRoute(string email)
    {
        var routeTemplate = "{0}/by-email/{1}/reset-password";

        var route = string.Format(
            routeTemplate,
            ApiRoute,
            email);

        return route;
    }
}
