﻿using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class EditCurrentUserFunctionalTests : BaseUserFunctionalTest
{
    public EditCurrentUserFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task EditCurrentAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new UpdateUserForm(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile);

        var formData = GetFormData(request);

        // Act
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldReturnBadRequestResponse_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new UpdateUserForm(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile);

        var formData = GetFormData(request);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task EditCurrentAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new UpdateUserForm(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile);

        var formData = GetFormData(request);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = SharedTestUtilities.GetString(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task EditCurrentAsync_ShouldReturnBadRequestResponse_WhenNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new UpdateUserForm(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile);

        var formData = GetFormData(request);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.FirstNameMinLength - 1)]
    [InlineData(UserConfigurations.FirstNameMaxLength + 1)]
    public async Task EditCurrentAsync_ShouldReturnBadRequestResponse_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new UpdateUserForm(
            UserTestUtilities.ValidUpdateName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile);

        var formData = GetFormData(request);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.LastNameMinLength - 1)]
    [InlineData(UserConfigurations.LastNameMaxLength + 1)]
    public async Task EditCurrentAsync_ShouldReturnBadRequestResponse_WhenLastNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new UpdateUserForm(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdateFormFile);

        var formData = GetFormData(request);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new UpdateUserForm(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile);

        var formData = GetFormData(request);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = UserTestUtilities.InvalidId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldReturnBadRequestResponse_WhenNameIsAlreadyTaken()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingUserTakenNameId = await CreateUserAsync(UserTestUtilities.ValidTakenEmail, UserTestUtilities.ValidTakenName, true, CancellationToken);
        var request = new Form(
            UserTestUtilities.ValidTakenName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile);

        var formData = GetFormData(request);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new UpdateUserForm(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile);

        var formData = GetFormData(request);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldEditCurrentUser_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new UpdateUserForm(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile);

        var formData = GetFormData(request);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserCommandResponse>();

        var user = await UserWriteRepository.GetByIdAsync(userViewResponse!.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == userViewResponse.Id &&
                              p.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              p.LastName == UserTestUtilities.ValidUpdateLastName &&
                              p.UserName == UserTestUtilities.ValidUpdateName &&
                              p.Email == UserTestUtilities.ValidEmail &&
                              PasswordHasher.Verify(UserTestUtilities.ValidPassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidUpdateProfileImage);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldEditCurrentUser_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new UpdateUserForm(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            null);

        var formData = GetFormData(request);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserCommandResponse>();

        var user = await UserWriteRepository.GetByIdAsync(userViewResponse!.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == userViewResponse.Id &&
                              p.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              p.LastName == UserTestUtilities.ValidUpdateLastName &&
                              p.UserName == UserTestUtilities.ValidUpdateName &&
                              p.Email == UserTestUtilities.ValidEmail &&
                              PasswordHasher.Verify(UserTestUtilities.ValidPassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldEditCurrentUser_WhenUserIsValidAndNameIsTheSame()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new UpdateUserForm(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            null);

        var formData = GetFormData(request);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserCommandResponse>();

        var user = await UserWriteRepository.GetByIdAsync(userViewResponse!.Id, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == userViewResponse.Id &&
                              p.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              p.LastName == UserTestUtilities.ValidUpdateLastName &&
                              p.UserName == UserTestUtilities.ValidName &&
                              p.Email == UserTestUtilities.ValidEmail &&
                              PasswordHasher.Verify(UserTestUtilities.ValidPassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldPublishUserUpdatedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new UpdateUserForm(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateFormFile);

        var formData = GetFormData(request);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserCommandResponse>();

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserUpdatedEvent>(m =>
                              m.Context.Message.Id == userViewResponse!.Id &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidUpdateLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidUpdateName &&
                              m.Context.Message.Email == UserTestUtilities.ValidEmail &&
                              m.Context.Message.ProfileImage == UserTestUtilities.ValidUpdateProfileImage, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldPublishUserUpdatedEvent_WhenUserIsValidAndFormFileIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var request = new UpdateUserForm(
            UserTestUtilities.ValidUpdateName,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            null);

        var formData = GetFormData(request);
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsync(GetApiRoute(), formData, CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserCommandResponse>();

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserUpdatedEvent>(m =>
                              m.Context.Message.Id == userViewResponse!.Id &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidUpdateLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidUpdateName &&
                              m.Context.Message.Email == UserTestUtilities.ValidEmail &&
                              m.Context.Message.ProfileImage == UserTestUtilities.ValidProfileImage, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }

    private string GetApiRoute()
    {
        var routeTemplate = "{0}/current";

        var route = string.Format(
            routeTemplate,
            ApiRoute);

        return route;
    }

    private MultipartFormDataContent GetFormData(UpdateUserForm editCurrentUserBindingModel)
    {
        var multipartContent = new MultipartFormDataContent
        {
            { new StringContent(editCurrentUserBindingModel.UserName), nameof(editCurrentUserBindingModel.UserName) },
            { new StringContent(editCurrentUserBindingModel.FirstName), nameof(editCurrentUserBindingModel.FirstName) },
            { new StringContent(editCurrentUserBindingModel.LastName), nameof(editCurrentUserBindingModel.LastName) }
        };

        if (editCurrentUserBindingModel.ProfileImage != null)
        {
            var streamContent = new StreamContent(editCurrentUserBindingModel.ProfileImage.OpenReadStream());
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(editCurrentUserBindingModel.ProfileImage.ContentType);
            multipartContent.Add(streamContent, nameof(editCurrentUserBindingModel.ProfileImage), editCurrentUserBindingModel.ProfileImage.FileName);
        }

        return multipartContent;
    }
}
