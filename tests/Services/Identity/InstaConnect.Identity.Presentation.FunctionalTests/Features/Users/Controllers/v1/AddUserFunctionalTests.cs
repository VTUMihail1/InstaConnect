using InstaConnect.Common.Application.Contracts.EmailConfirmationTokens;
using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Identity.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class AddUserFunctionalTests : BaseUserFunctionalTest
{
    public AddUserFunctionalTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenNameLengthIsInvalid(int length)
    {
        // Arrange
        var request = new AddUserRequest(
            new(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile)
        );

        // Act
        var response = await UsersClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.EmailMinLength - 1)]
    [InlineData(UserConfigurations.EmailMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var request = new AddUserRequest(
            new(
            UserTestUtilities.ValidAddName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile)
        );

        // Act
        var response = await UsersClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.PasswordMinLength - 1)]
    [InlineData(UserConfigurations.PasswordMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var password = SharedTestUtilities.GetString(length);
        var request = new AddUserRequest(
            new(
            UserTestUtilities.ValidAddName,
            password,
            password,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile)
        );

        // Act
        var response = await UsersClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenPasswordDoesNotMatchConfirmPassword()
    {
        // Arrange
        var request = new AddUserRequest(
            new(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile)
        );

        // Act
        var response = await UsersClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.FirstNameMinLength - 1)]
    [InlineData(UserConfigurations.FirstNameMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var request = new AddUserRequest(
            new(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile)
        );

        // Act
        var response = await UsersClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.LastNameMinLength - 1)]
    [InlineData(UserConfigurations.LastNameMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenLastNameLengthIsInvalid(int length)
    {
        // Arrange
        var request = new AddUserRequest(
            new(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidAddFormFile)
        );

        // Act
        var response = await UsersClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenEmailIsAlreadyTaken()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddUserRequest(
            new(
            UserTestUtilities.ValidAddName,
            existingUser.Email,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile)
        );

        // Act
        var response = await UsersClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenNameIsAlreadyTaken()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddUserRequest(
            new(
            existingUser.UserName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile)
        );

        // Act
        var response = await UsersClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddUserRequest(
            new(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile)
        );

        // Act
        var response = await UsersClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldRegisterUser_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddUserRequest(
            new(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile)
        );

        // Act
        var response = await UsersClient.AddAsync(request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == response.Id &&
                              p.FirstName == UserTestUtilities.ValidAddFirstName &&
                              p.LastName == UserTestUtilities.ValidAddLastName &&
                              p.UserName == UserTestUtilities.ValidAddName &&
                              p.Email == UserTestUtilities.ValidAddEmail &&
                              PasswordHasher.Verify(UserTestUtilities.ValidAddPassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidAddProfileImage);
    }

    [Fact]
    public async Task AddAsync_ShouldRegisterUser_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var request = new AddUserRequest(
            new(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            null)
        );

        // Act
        var response = await UsersClient.AddAsync(request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == response.Id &&
                              p.FirstName == UserTestUtilities.ValidAddFirstName &&
                              p.LastName == UserTestUtilities.ValidAddLastName &&
                              p.UserName == UserTestUtilities.ValidAddName &&
                              p.Email == UserTestUtilities.ValidAddEmail &&
                              PasswordHasher.Verify(UserTestUtilities.ValidAddPassword, p.PasswordHash) &&
                              p.ProfileImage == null);
    }

    [Fact]
    public async Task AddAsync_ShouldPublishUserCreatedEvent_WhenUserIsValid()
    {
        // Arrange
        var request = new AddUserRequest(
            new(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile)
        );

        // Act
        var response = await UsersClient.AddAsync(request, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserCreatedEvent>(m =>
                              m.Context.Message.Id == response.Id &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidAddFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidAddLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidAddName &&
                              m.Context.Message.Email == UserTestUtilities.ValidAddEmail &&
                              m.Context.Message.ProfileImage == UserTestUtilities.ValidAddProfileImage, CancellationToken);

        // Assert
        result
            .Should()
            .BeTrue();
    }

    [Fact]
    public async Task AddAsync_ShouldPublishUserCreatedEvent_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var request = new AddUserRequest(
            new(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            null)
        );

        // Act
        var response = await UsersClient.AddAsync(request, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserCreatedEvent>(m =>
                              m.Context.Message.Id == response.Id &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidAddFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidAddLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidAddName &&
                              m.Context.Message.Email == UserTestUtilities.ValidAddEmail &&
                              m.Context.Message.ProfileImage == null, CancellationToken);

        // Assert
        result
            .Should()
            .BeTrue();
    }

    [Fact]
    public async Task AddAsync_ShouldPublishUserConfirmEmailTokenCreatedEvent_WhenUserIsValid()
    {
        // Arrange
        var request = new AddUserRequest(
            new(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile)
        );

        // Act
        await UsersClient.AddAsync(request, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserConfirmEmailTokenCreatedEvent>(m =>
                              m.Context.Message.Email == UserTestUtilities.ValidAddEmail);

        // Assert
        result
            .Should()
            .BeTrue();
    }
}
