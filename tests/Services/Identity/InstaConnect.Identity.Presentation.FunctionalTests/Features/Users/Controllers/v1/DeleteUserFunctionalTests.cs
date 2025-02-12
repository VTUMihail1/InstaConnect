using System.Net;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class DeleteUserFunctionalTests : BaseUserFunctionalTest
{
    public DeleteUserFunctionalTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new DeleteUserRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.DeleteStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnForbiddenResponse_WhenUserIsNotAdmin()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new DeleteUserRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.DeleteStatusCodeNonAdminAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new DeleteUserRequest(
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await UsersClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new DeleteUserRequest(
            UserTestUtilities.InvalidId
        );

        // Act
        var response = await UsersClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new DeleteUserRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteUser_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new DeleteUserRequest(
            existingUser.Id
        );

        // Act
        await UsersClient.DeleteAsync(request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingUser.Id, CancellationToken);

        // Assert
        user
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldPublishUserDeletedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new DeleteUserRequest(
            existingUser.Id
        );

        // Act
        await UsersClient.DeleteAsync(request, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserDeletedEvent>(m =>
                              m.Context.Message.Id == existingUser.Id, CancellationToken);

        // Assert
        result
            .Should()
            .BeTrue();
    }
}
