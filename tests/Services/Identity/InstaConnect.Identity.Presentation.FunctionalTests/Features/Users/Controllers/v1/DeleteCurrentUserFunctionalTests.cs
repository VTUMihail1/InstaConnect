using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Identity.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class DeleteCurrentUserFunctionalTests : BaseUserFunctionalTest
{
    public DeleteCurrentUserFunctionalTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new DeleteCurrentUserRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.DeleteCurrentStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldReturnBadRequestResponse_WhenIdIsNull()
    {
        // Arrange
        var request = new DeleteCurrentUserRequest(
            null
        );

        // Act
        var response = await UsersClient.DeleteCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task DeleteCurrentAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var request = new DeleteCurrentUserRequest(
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await UsersClient.DeleteCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var request = new DeleteCurrentUserRequest(
            UserTestUtilities.InvalidId
        );

        // Act
        var response = await UsersClient.DeleteCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new DeleteCurrentUserRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.DeleteCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldDeleteCurrentUser_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new DeleteCurrentUserRequest(
            existingUser.Id
        );

        // Act
        await UsersClient.DeleteCurrentAsync(request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingUser.Id, CancellationToken);

        // Assert
        user
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldPublishUserDeletedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new DeleteCurrentUserRequest(
            existingUser.Id
        );

        // Act
        await UsersClient.DeleteCurrentAsync(request, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserDeletedEvent>(m =>
                              m.Context.Message.Id == existingUser.Id, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
