using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Queries.GetById;

public class GetPostCommentLikeByIdQueryValidatorUnitTests : BasePostCommentLikeUnitTest
{
    private readonly GetPostCommentLikeByIdQueryValidator _validator;

    public GetPostCommentLikeByIdQueryValidatorUnitTests()
    {
        _validator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var query = new GetPostCommentLikeByIdQuery(null);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentLikeConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentLikeConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetPostCommentLikeByIdQuery(SharedTestUtilities.GetString(length));

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var query = new GetPostCommentLikeByIdQuery(existingPostCommentLike.Id);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
