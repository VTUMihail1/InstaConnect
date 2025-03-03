﻿using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Queries.GetById;

public class GetPostCommentByIdQueryValidatorUnitTests : BasePostCommentUnitTest
{
    private readonly GetPostCommentByIdQueryValidator _validator;

    public GetPostCommentByIdQueryValidatorUnitTests()
    {
        _validator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var query = new GetPostCommentByIdQuery(null);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetPostCommentByIdQuery(SharedTestUtilities.GetString(length));

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var query = new GetPostCommentByIdQuery(existingPostComment.Id);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
