using FluentValidation.TestHelper;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetPostCommentById;
using InstaConnect.Posts.Business.Features.PostComments.Utilities;
using InstaConnect.Posts.Business.UnitTests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostComments.Queries.GetPostCommentById;

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
        var query = new GetPostCommentByIdQuery(null!);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetPostCommentByIdQuery(Faker.Random.AlphaNumeric(length));

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }
}
