﻿using FluentValidation.TestHelper;
using InstaConnect.Identity.Application.Features.Users.Commands.SendUserPasswordReset;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.SendUserPasswordReset;

public class AddForgotPasswordTokenCommandValidatorUnitTests : BaseForgotPasswordTokenUnitTest
{
    private readonly AddForgotPasswordTokenCommandValidator _commandValidator;

    public AddForgotPasswordTokenCommandValidatorUnitTests()
    {
        _commandValidator = new AddForgotPasswordTokenCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForEmail_WhenEmailIsNull()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddForgotPasswordTokenCommand(null!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.EmailMinLength - 1)]
    [InlineData(UserConfigurations.EmailMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForEmail_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddForgotPasswordTokenCommand(SharedTestUtilities.GetString(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddForgotPasswordTokenCommand(existingUser.Email);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
