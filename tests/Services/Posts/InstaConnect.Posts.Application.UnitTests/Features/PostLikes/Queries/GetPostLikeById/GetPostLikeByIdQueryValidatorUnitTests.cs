using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Queries.GetPostLikeById;

public class GetPostLikeByIdQueryValidatorUnitTests : BasePostLikeUnitTest
{
    private readonly GetPostLikeByIdQueryValidator _validator;

    public GetPostLikeByIdQueryValidatorUnitTests()
    {
        _validator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(null);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeConfigurations.IdMinLength - 1)]
    [InlineData(PostLikeConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetPostLikeByIdQuery(SharedTestUtilities.GetString(length));

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var query = new GetPostLikeByIdQuery(existingPostLike.Id);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
