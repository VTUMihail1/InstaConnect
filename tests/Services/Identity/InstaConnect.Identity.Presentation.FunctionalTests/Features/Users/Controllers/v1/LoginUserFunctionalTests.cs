namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class LoginUserFunctionalTests : BaseUserFunctionalTest
{
    public LoginUserFunctionalTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenEmailIsNull()
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var request = new LoginUserRequest(
            new(
            null,
            UserTestUtilities.ValidPassword)
        );

        // Act
        var response = await UsersClient.LoginStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.EmailMinLength - 1)]
    [InlineData(UserConfigurations.EmailMaxLength + 1)]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var request = new LoginUserRequest(
            new(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidPassword)
        );

        // Act
        var response = await UsersClient.LoginStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenPasswordIsNull()
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var request = new LoginUserRequest(
            new(
            UserTestUtilities.ValidPassword,
            null)
        );

        // Act
        var response = await UsersClient.LoginStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.PasswordMinLength - 1)]
    [InlineData(UserConfigurations.PasswordMaxLength + 1)]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var request = new LoginUserRequest(
            new(
            existingUserClaim.User.Email,
            SharedTestUtilities.GetString(length))
        );

        // Act
        var response = await UsersClient.LoginStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenEmailIsInvalid()
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var request = new LoginUserRequest(
            new(
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidPassword)
        );

        // Act
        var response = await UsersClient.LoginStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenPasswordIsInvalid()
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var request = new LoginUserRequest(
            new(
            existingUserClaim.User.Email,
            UserTestUtilities.ValidAddPassword)
        );

        // Act
        var response = await UsersClient.LoginStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnBadRequestResponse_WhenEmailIsNotConfirmed()
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimWithUnconfirmedUserEmailAsync(CancellationToken);
        var request = new LoginUserRequest(
            new(
            existingUserClaim.User.Email,
            UserTestUtilities.ValidPassword)
        );

        // Act
        var response = await UsersClient.LoginStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var request = new LoginUserRequest(
            new(
            existingUserClaim.User.Email,
            UserTestUtilities.ValidPassword)
        );

        // Act
        var response = await UsersClient.LoginStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task LoginAsync_ShouldLoginUser_WhenRequestIsValid()
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var request = new LoginUserRequest(
            new(
            existingUserClaim.User.Email,
            UserTestUtilities.ValidPassword)
        );

        // Act
        var response = await UsersClient.LoginAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserTokenCommandResponse>(p => !string.IsNullOrEmpty(p.Value) && p.ValidUntil != default);
    }
}
