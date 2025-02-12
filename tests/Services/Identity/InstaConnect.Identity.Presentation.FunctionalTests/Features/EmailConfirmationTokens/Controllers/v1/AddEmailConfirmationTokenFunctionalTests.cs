using System.Net;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Application.Contracts.Emails;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class AddEmailConfirmationTokenFunctionalTests : BaseEmailConfirmationTokenFunctionalTest
{
    public AddEmailConfirmationTokenFunctionalTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(UserConfigurations.EmailMinLength - 1)]
    [InlineData(UserConfigurations.EmailMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddEmailConfirmationTokenRequest(
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await EmailConfirmationTokensClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenEmailIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddEmailConfirmationTokenRequest(
            UserTestUtilities.ValidAddEmail
        );

        // Act
        var response = await EmailConfirmationTokensClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenEmailIsAlreadyConfirmed()
    {
        // Arrange
        var existingUser = await CreateUserWithConfirmedEmailAsync(CancellationToken);
        var request = new AddEmailConfirmationTokenRequest(
            existingUser.Email
        );

        // Act
        var response = await EmailConfirmationTokensClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddEmailConfirmationTokenRequest(
            existingUser.Email
        );

        // Act
        var response = await EmailConfirmationTokensClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task AddAsync_ShouldAddEmailConfirmationTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddEmailConfirmationTokenRequest(
            existingUser.Email
        );

        // Act
        await EmailConfirmationTokensClient.AddAsync(request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingUser.Id, CancellationToken);

        // Assert
        user!
            .EmailConfirmationTokens
            .Should()
            .NotBeEmpty();
    }

    [Fact]
    public async Task AddAsync_ShouldPublishUserConfirmEmailTokenCreatedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddEmailConfirmationTokenRequest(
            existingUser.Email
        );

        // Act
        await EmailConfirmationTokensClient.AddAsync(request, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUser.Id, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserConfirmEmailTokenCreatedEvent>(m =>
                              m.Context.Message.Email == existingUser.Email);
        // Assert
        result
            .Should()
            .BeTrue();
    }
}
