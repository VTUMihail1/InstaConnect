﻿using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Identity.Presentation.Features.Users.Models.Bindings;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class VerifyForgotPasswordTokenFunctionalTests : BaseForgotPasswordTokenFunctionalTest
{
    public VerifyForgotPasswordTokenFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task VerifyAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var request = new VerifyForgotPasswordTokenRequest(
            SharedTestUtilities.GetString(length), 
            existingForgotPasswordToken.Value,
            new(UserTestUtilities.ValidPassword, UserTestUtilities.ValidPassword)
        );

        // Act
        var response = await ForgotPasswordTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(ForgotPasswordTokenConfigurations.ValueMinLength - 1)]
    [InlineData(ForgotPasswordTokenConfigurations.ValueMaxLength + 1)]
    public async Task VerifyAsync_ShouldReturnBadRequestResponse_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var request = new VerifyForgotPasswordTokenRequest(
            existingForgotPasswordToken.UserId, 
            SharedTestUtilities.GetString(length),
            new(UserTestUtilities.ValidPassword, UserTestUtilities.ValidPassword)
        );

        // Act
        var response = await ForgotPasswordTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task VerifyAsync_ShouldReturnBadRequestResponse_WhenPasswordIsNull()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var request = new VerifyForgotPasswordTokenRequest(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            new(null!, null!)
        );

        // Act
        var response = await ForgotPasswordTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.PasswordMinLength - 1)]
    [InlineData(UserConfigurations.PasswordMaxLength + 1)]
    public async Task VerifyAsync_ShouldReturnBadRequestResponse_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var password = SharedTestUtilities.GetString(length);
        var request = new VerifyForgotPasswordTokenRequest(
            existingForgotPasswordToken.UserId, 
            existingForgotPasswordToken.Value,
            new(password, password)
        );

        // Act
        var response = await ForgotPasswordTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task VerifyAsync_ShouldReturnBadRequestResponse_WhenPasswordDoesNotMatchConfirmPassword()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var request = new VerifyForgotPasswordTokenRequest(
            existingForgotPasswordToken.UserId, 
            existingForgotPasswordToken.Value,
            new(UserTestUtilities.ValidUpdatePassword, UserTestUtilities.ValidPassword)
        );

        // Act
        var response = await ForgotPasswordTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task VerifyAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var request = new VerifyForgotPasswordTokenRequest(
            UserTestUtilities.InvalidId, 
            existingForgotPasswordToken.Value,
            new(UserTestUtilities.ValidUpdatePassword, UserTestUtilities.ValidUpdatePassword)
        );

        // Act
        var response = await ForgotPasswordTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task VerifyAsync_ShouldReturnNotFoundResponse_WhenTokenIsInvalid()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var request = new VerifyForgotPasswordTokenRequest(
            existingForgotPasswordToken.UserId, 
            ForgotPasswordTokenTestUtilities.InvalidValue,
            new(UserTestUtilities.ValidUpdatePassword, UserTestUtilities.ValidUpdatePassword)
        );

        // Act
        var response = await ForgotPasswordTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

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
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var request = new VerifyForgotPasswordTokenRequest(
            existingUser.Id, 
            existingForgotPasswordToken.Value,
            new(UserTestUtilities.ValidUpdatePassword, UserTestUtilities.ValidUpdatePassword)
        );

        // Act
        var response = await ForgotPasswordTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task VerifyAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var request = new VerifyForgotPasswordTokenRequest(
            existingForgotPasswordToken.UserId, 
            existingForgotPasswordToken.Value,
            new(UserTestUtilities.ValidUpdatePassword, UserTestUtilities.ValidUpdatePassword)
        );

        // Act
        var response = await ForgotPasswordTokensClient.VerifyStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task VerifyAsync_ShouldRemoveForgotPasswordTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var request = new VerifyForgotPasswordTokenRequest(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            new(UserTestUtilities.ValidUpdatePassword, UserTestUtilities.ValidUpdatePassword)
        );
        

        // Act
        await ForgotPasswordTokensClient.VerifyAsync(request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingForgotPasswordToken.UserId, CancellationToken);

        // Assert
        user!
            .ForgotPasswordTokens
            .Should()
            .BeEmpty();
    }

    [Fact]
    public async Task VerifyAsync_ShouldChangeUserPassword_WhenRequestIsValid()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var request = new VerifyForgotPasswordTokenRequest(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            new(UserTestUtilities.ValidUpdatePassword, UserTestUtilities.ValidUpdatePassword)
        );


        // Act
        await ForgotPasswordTokensClient.VerifyAsync(request, CancellationToken);

        var user = await UserWriteRepository.GetByIdAsync(existingForgotPasswordToken.UserId, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == user.Id &&
                              p.FirstName == user.FirstName &&
                              p.LastName == user.LastName &&
                              p.UserName == user.UserName &&
                              p.Email == user.Email &&
                              PasswordHasher.Verify(UserTestUtilities.ValidUpdatePassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidProfileImage);
    }
}
