using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Identity.Web.Features.Users.Models.Bindings;
using InstaConnect.Identity.Web.Features.Users.Models.Responses;
using InstaConnect.Identity.Web.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Emails;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Web.FunctionalTests.Features.Users.Controllers.v1;

public class RegisterUserFunctionalTests : BaseUserFunctionalTest
{
    public RegisterUserFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.USER_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.USER_NAME_MAX_LENGTH + 1)]
    public async Task RegisterAsync_ShouldReturnBadRequestResponse_WhenNameLengthIsInvalid(int length)
    {
        // Arrange
        var request = new RegisterUserBindingModel(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.EMAIL_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.EMAIL_MAX_LENGTH + 1)]
    public async Task RegisterAsync_ShouldReturnBadRequestResponse_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var request = new RegisterUserBindingModel(
            UserTestUtilities.ValidAddName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.PASSWORD_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.PASSWORD_MAX_LENGTH + 1)]
    public async Task RegisterAsync_ShouldReturnBadRequestResponse_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var invalidPassword = SharedTestUtilities.GetString(length);
        var request = new RegisterUserBindingModel(
            UserTestUtilities.ValidAddName,
            invalidPassword,
            invalidPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnBadRequestResponse_WhenPasswordDoesNotMatchConfirmPassword()
    {
        // Arrange
        var request = new RegisterUserBindingModel(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.InvalidPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH + 1)]
    public async Task RegisterAsync_ShouldReturnBadRequestResponse_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var request = new RegisterUserBindingModel(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.LAST_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH + 1)]
    public async Task RegisterAsync_ShouldReturnBadRequestResponse_WhenLastNameLengthIsInvalid(int length)
    {
        // Arrange
        var request = new RegisterUserBindingModel(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidAddFormFile);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnBadRequestResponse_WhenEmailIsAlreadyTaken()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new RegisterUserBindingModel(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnBadRequestResponse_WhenNameIsAlreadyTaken()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new RegisterUserBindingModel(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new RegisterUserBindingModel(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task RegisterAsync_ShouldRegisterUser_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new RegisterUserBindingModel(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserCommandResponse>();

        var user = await UserWriteRepository.GetByIdAsync(userViewResponse!.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == userViewResponse.Id &&
                              p.FirstName == UserTestUtilities.ValidAddFirstName &&
                              p.LastName == UserTestUtilities.ValidAddLastName &&
                              p.UserName == UserTestUtilities.ValidAddName &&
                              p.Email == UserTestUtilities.ValidAddEmail &&
                              PasswordHasher.Verify(UserTestUtilities.ValidAddPassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidAddProfileImage);
    }

    [Fact]
    public async Task RegisterAsync_ShouldRegisterUser_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new RegisterUserBindingModel(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            null);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserCommandResponse>();

        var user = await UserWriteRepository.GetByIdAsync(userViewResponse!.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == userViewResponse.Id &&
                              p.FirstName == UserTestUtilities.ValidAddFirstName &&
                              p.LastName == UserTestUtilities.ValidAddLastName &&
                              p.UserName == UserTestUtilities.ValidAddName &&
                              p.Email == UserTestUtilities.ValidAddEmail &&
                              PasswordHasher.Verify(UserTestUtilities.ValidAddPassword, p.PasswordHash) &&
                              p.ProfileImage == null);
    }

    [Fact]
    public async Task RegisterAsync_ShouldPublishUserCreatedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new RegisterUserBindingModel(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserCommandResponse>();

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserCreatedEvent>(m =>
                              m.Context.Message.Id == userViewResponse!.Id &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidAddFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidAddLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidAddName &&
                              m.Context.Message.Email == UserTestUtilities.ValidAddEmail &&
                              m.Context.Message.ProfileImage == UserTestUtilities.ValidAddProfileImage, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task RegisterAsync_ShouldPublishUserCreatedEvent_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new RegisterUserBindingModel(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            null);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserCommandResponse>();

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserCreatedEvent>(m =>
                              m.Context.Message.Id == userViewResponse!.Id &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidAddFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidAddLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidAddName &&
                              m.Context.Message.Email == UserTestUtilities.ValidAddEmail &&
                              m.Context.Message.ProfileImage == null, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task RegisterAsync_ShouldPublishUserConfirmEmailTokenCreatedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new RegisterUserBindingModel(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PostAsync(GetApiRoute(), formData, CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserCommandResponse>();

        var user = await UserWriteRepository.GetByIdAsync(userViewResponse!.Id, CancellationToken);
        var url = string.Format(EmailConfirmationOptions.UrlTemplate, user!.Id, user.EmailConfirmationTokens.FirstOrDefault()!.Value);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserConfirmEmailTokenCreatedEvent>(m =>
                              m.Context.Message.Email == UserTestUtilities.ValidAddEmail &&
                              m.Context.Message.RedirectUrl == url);

        // Assert
        result.Should().BeTrue();
    }

    private string GetApiRoute()
    {
        var routeTemplate = "{0}/register";

        var route = string.Format(
            routeTemplate,
            ApiRoute);

        return route;
    }

    private MultipartFormDataContent GetFormData(RegisterUserBindingModel registerUserBindingModel)
    {
        var multipartContent = new MultipartFormDataContent
        {
            { new StringContent(registerUserBindingModel.UserName), nameof(registerUserBindingModel.UserName) },
            { new StringContent(registerUserBindingModel.Email), nameof(registerUserBindingModel.Email) },
            { new StringContent(registerUserBindingModel.Password), nameof(registerUserBindingModel.Password) },
            { new StringContent(registerUserBindingModel.ConfirmPassword), nameof(registerUserBindingModel.ConfirmPassword) },
            { new StringContent(registerUserBindingModel.FirstName), nameof(registerUserBindingModel.FirstName) },
            { new StringContent(registerUserBindingModel.LastName), nameof(registerUserBindingModel.LastName) }
        };

        if (registerUserBindingModel.ProfileImage != null)
        {
            var streamContent = new StreamContent(registerUserBindingModel.ProfileImage.OpenReadStream());
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(registerUserBindingModel.ProfileImage.ContentType);
            multipartContent.Add(streamContent, nameof(registerUserBindingModel.ProfileImage), registerUserBindingModel.ProfileImage.FileName);
        }

        return multipartContent;
    }
}
