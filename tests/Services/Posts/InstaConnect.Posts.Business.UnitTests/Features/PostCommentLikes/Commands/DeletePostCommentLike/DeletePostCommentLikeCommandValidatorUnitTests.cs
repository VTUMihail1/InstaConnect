﻿using FluentValidation.TestHelper;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.DeletePostCommentLike;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Business.Features.PostComments.Utilities;
using InstaConnect.Posts.Business.UnitTests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostCommentLikes.Commands.DeletePostCommentLike;

public class DeletePostCommentLikeCommandValidatorUnitTests : BasePostCommentLikeUnitTest
{
    private readonly DeletePostCommentLikeCommandValidator _commandValidator;

    public DeletePostCommentLikeCommandValidatorUnitTests()
    {
        _commandValidator = new DeletePostCommentLikeCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var command = new DeletePostCommentLikeCommand(
            null!,
            ValidCurrentUserId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentLikeBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentLikeBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new DeletePostCommentLikeCommand(
            Faker.Random.AlphaNumeric(length),
            ValidCurrentUserId
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
        var command = new DeletePostCommentLikeCommand(
            ValidId,
            null!
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new DeletePostCommentLikeCommand(
            ValidId,
            Faker.Random.AlphaNumeric(length)
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }
}