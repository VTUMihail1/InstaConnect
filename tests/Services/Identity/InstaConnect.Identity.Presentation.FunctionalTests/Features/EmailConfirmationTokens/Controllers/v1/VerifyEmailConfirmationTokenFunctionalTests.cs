using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Identity.Common.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.EmailConfirmationTokens.Controllers.v1;

public class VerifyEmailConfirmationTokenFunctionalTests : BaseEmailConfirmationTokenFunctionalTest
{
    public VerifyEmailConfirmationTokenFunctionalTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task VerifyAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var request = new VerifyEmailConfirmationTokenRequest(
            existingEmailConfirmationToken.Value,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await EmailConfirmationTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(EmailConfirmationTokenConfigurations.ValueMinLength - 1)]
    [InlineData(EmailConfirmationTokenConfigurations.ValueMaxLength + 1)]
    public async Task VerifyAsync_ShouldReturnBadRequestResponse_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var request = new VerifyEmailConfirmationTokenRequest(
            SharedTestUtilities.GetString(length),
            existingEmailConfirmationToken.UserId
        );

        // Act
        var response = await EmailConfirmationTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task VerifyAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var request = new VerifyEmailConfirmationTokenRequest(
            existingEmailConfirmationToken.Value,
            UserTestUtilities.InvalidId
        );

        // Act
        var response = await EmailConfirmationTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task VerifyAsync_ShouldReturnBadRequestResponse_WhenEmailIsAlreadyConfirmed()
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenWithConfirmedUserEmailAsync(CancellationToken);
        var request = new VerifyEmailConfirmationTokenRequest(
            existingEmailConfirmationToken.Value,
            existingEmailConfirmationToken.UserId
        );

        // Act
        var response = await EmailConfirmationTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task VerifyAsync_ShouldReturnNotFoundResponse_WhenTokenIsInvalid()
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var request = new VerifyEmailConfirmationTokenRequest(
            EmailConfirmationTokenTestUtilities.InvalidValue,
            existingEmailConfirmationToken.UserId
        );

        // Act
        var response = await EmailConfirmationTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task VerifyAsync_ShouldReturnForbiddenResponse_WhenUserDoesNotOwnToken()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var request = new VerifyEmailConfirmationTokenRequest(
            existingEmailConfirmationToken.Value,
            existingUser.Id
        );

        // Act
        var response = await EmailConfirmationTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task VerifyAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var request = new VerifyEmailConfirmationTokenRequest(
            existingEmailConfirmationToken.Value,
            existingEmailConfirmationToken.UserId
        );

        // Act
        var response = await EmailConfirmationTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task VerifyAsync_ShouldRemoveEmailConfirmationTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var request = new VerifyEmailConfirmationTokenRequest(
            existingEmailConfirmationToken.Value,
            existingEmailConfirmationToken.UserId
        );

        // Act
        await EmailConfirmationTokensClient.VerifyAsync(request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingEmailConfirmationToken.UserId, CancellationToken);

        // Assert
        user!
            .EmailConfirmationTokens
            .Should()
            .BeEmpty();
    }

    [Fact]
    public async Task SendAsync_ShouldChangeUserPassword_WhenRequestIsValid()
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var request = new VerifyEmailConfirmationTokenRequest(
            existingEmailConfirmationToken.Value,
            existingEmailConfirmationToken.UserId
        );

        // Act
        await EmailConfirmationTokensClient.VerifyAsync(request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingEmailConfirmationToken.UserId, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == existingEmailConfirmationToken.User.Id &&
                              p.FirstName == existingEmailConfirmationToken.User.FirstName &&
                              p.LastName == existingEmailConfirmationToken.User.LastName &&
                              p.UserName == existingEmailConfirmationToken.User.UserName &&
                              p.Email == existingEmailConfirmationToken.User.Email &&
                              p.IsEmailConfirmed &&
                              p.ProfileImage == existingEmailConfirmationToken.User.ProfileImage);
    }
}
