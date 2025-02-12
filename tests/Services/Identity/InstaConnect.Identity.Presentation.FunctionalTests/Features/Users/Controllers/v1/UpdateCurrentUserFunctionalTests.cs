using System.Net;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class UpdateCurrentUserFunctionalTests : BaseUserFunctionalTest
{
    public UpdateCurrentUserFunctionalTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task UpdateCurrentAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await UsersClient.UpdateCurrentStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task UpdateCurrentAsync_ShouldReturnBadRequestResponse_WhenIdIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            null,
            new(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await UsersClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task UpdateCurrentAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            SharedTestUtilities.GetString(length),
            new(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await UsersClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task UpdateCurrentAsync_ShouldReturnBadRequestResponse_WhenNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await UsersClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.FirstNameMinLength - 1)]
    [InlineData(UserConfigurations.FirstNameMaxLength + 1)]
    public async Task UpdateCurrentAsync_ShouldReturnBadRequestResponse_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
            UserTestUtilities.ValidUpdateName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await UsersClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.LastNameMinLength - 1)]
    [InlineData(UserConfigurations.LastNameMaxLength + 1)]
    public async Task UpdateCurrentAsync_ShouldReturnBadRequestResponse_WhenLastNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await UsersClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateCurrentAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            UserTestUtilities.InvalidId,
            new(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await UsersClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task UpdateCurrentAsync_ShouldReturnBadRequestResponse_WhenNameIsAlreadyTaken()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingUserWithTakenName = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
            existingUserWithTakenName.UserName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await UsersClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateCurrentAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await UsersClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task UpdateCurrentAsync_ShouldUpdateCurrentUser_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await UsersClient.UpdateCurrentAsync(request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == response.Id &&
                              p.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              p.LastName == UserTestUtilities.ValidUpdateLastName &&
                              p.UserName == UserTestUtilities.ValidUpdateName &&
                              p.Email == existingUser.Email &&
                              PasswordHasher.Verify(UserTestUtilities.ValidPassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidUpdateProfileImage);
    }

    [Fact]
    public async Task UpdateCurrentAsync_ShouldUpdateCurrentUser_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            null)
        );

        // Act
        var response = await UsersClient.UpdateCurrentAsync(request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == response.Id &&
                              p.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              p.LastName == UserTestUtilities.ValidUpdateLastName &&
                              p.UserName == UserTestUtilities.ValidUpdateName &&
                              p.Email == existingUser.Email &&
                              PasswordHasher.Verify(UserTestUtilities.ValidPassword, p.PasswordHash) &&
                              p.ProfileImage == existingUser.ProfileImage);
    }

    [Fact]
    public async Task UpdateCurrentAsync_ShouldUpdateCurrentUser_WhenUserIsValidAndNameIsTheSame()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
            existingUser.UserName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await UsersClient.UpdateCurrentAsync(request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == response.Id &&
                              p.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              p.LastName == UserTestUtilities.ValidUpdateLastName &&
                              p.UserName == existingUser.UserName &&
                              p.Email == existingUser.Email &&
                              PasswordHasher.Verify(UserTestUtilities.ValidPassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidUpdateProfileImage);
    }

    [Fact]
    public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await UsersClient.UpdateCurrentAsync(request, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserUpdatedEvent>(m =>
                              m.Context.Message.Id == response.Id &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidUpdateLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidUpdateName &&
                              m.Context.Message.Email == existingUser.Email &&
                              m.Context.Message.ProfileImage == UserTestUtilities.ValidUpdateProfileImage, CancellationToken);

        // Assert
        result
            .Should()
            .BeTrue();
    }

    [Fact]
    public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            null)
        );

        // Act
        var response = await UsersClient.UpdateCurrentAsync(request, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserUpdatedEvent>(m =>
                              m.Context.Message.Id == response.Id &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidUpdateLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidUpdateName &&
                              m.Context.Message.Email == existingUser.Email &&
                              m.Context.Message.ProfileImage == existingUser.ProfileImage, CancellationToken);

        // Assert
        result
            .Should()
            .BeTrue();
    }
}
