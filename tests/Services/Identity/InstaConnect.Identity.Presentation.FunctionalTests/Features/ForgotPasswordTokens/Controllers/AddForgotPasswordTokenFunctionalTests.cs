using InstaConnect.Shared.Application.Contracts.ForgotPasswordTokens;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.ForgotPasswordTokens.Controllers;

public class AddForgotPasswordTokenFunctionalTests : BaseForgotPasswordTokenFunctionalTest
{
    public AddForgotPasswordTokenFunctionalTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(UserConfigurations.EmailMinLength - 1)]
    [InlineData(UserConfigurations.EmailMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddForgotPasswordTokenRequest(
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await ForgotPasswordTokensClient.AddStatusCodeAsync(request, CancellationToken);

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
        var request = new AddForgotPasswordTokenRequest(
            UserTestUtilities.ValidAddEmail
        );

        // Act
        var response = await ForgotPasswordTokensClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddForgotPasswordTokenRequest(
            existingUser.Email
        );

        // Act
        var response = await ForgotPasswordTokensClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task AddAsync_ShouldAddForgotPasswordTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddForgotPasswordTokenRequest(
            existingUser.Email
        );

        // Act
        await ForgotPasswordTokensClient.AddStatusCodeAsync(request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingUser.Id, CancellationToken);

        // Assert
        user!
            .ForgotPasswordTokens
            .Should()
            .NotBeEmpty();
    }

    [Fact]
    public async Task AddAsync_ShouldPublishUserForgotPasswordTokenCreatedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddForgotPasswordTokenRequest(
            existingUser.Email
        );

        // Act
        await ForgotPasswordTokensClient.AddStatusCodeAsync(request, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUser.Id, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserForgotPasswordTokenCreatedEvent>(m =>
                              m.Context.Message.Email == existingUser.Email);
        // Assert
        result
            .Should()
            .BeTrue();
    }
}
