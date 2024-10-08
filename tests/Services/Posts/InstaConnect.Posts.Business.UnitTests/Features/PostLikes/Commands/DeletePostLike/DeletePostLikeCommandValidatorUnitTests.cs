﻿using FluentValidation.TestHelper;
using InstaConnect.Posts.Business.Features.PostLikes.Commands.DeletePostLike;
using InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Commands.DeletePostLike;

public class DeletePostLikeCommandValidatorUnitTests : BasePostLikeUnitTest
{
    private readonly DeletePostLikeCommandValidator _commandValidator;

    public DeletePostLikeCommandValidatorUnitTests()
    {
        _commandValidator = new DeletePostLikeCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var command = new DeletePostLikeCommand(
            null!,
            PostLikeTestUtilities.ValidCurrentUserId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new DeletePostLikeCommand(
            SharedTestUtilities.GetString(length),
            PostLikeTestUtilities.ValidCurrentUserId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new DeletePostLikeCommand(
            PostLikeTestUtilities.ValidId,
            null!
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new DeletePostLikeCommand(
            PostLikeTestUtilities.ValidId,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new DeletePostLikeCommand(
            PostLikeTestUtilities.ValidId,
            PostLikeTestUtilities.ValidCurrentUserId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
