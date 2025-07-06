using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Queries.GetById;

public class GetPostByIdQueryValidatorUnitTests : BasePostUnitTest
{
    private readonly GetPostByIdQueryBuilder _queryBuilder;
    private readonly GetPostByIdQueryValidator _queryValidator;

    public GetPostByIdQueryValidatorUnitTests()
    {
        _queryBuilder = new();
        _queryValidator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenIdIsNull()
    {
        // Arrange
        var request = _queryBuilder.WithoutId().Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForId();
    }

    [Theory]
    [PostIdOutOfBoundsMinData]
    [PostIdOutOfBoundsMaxData]
    public void TestValidate_ShouldHaveAnError_WhenIdLengthIsInvalid(string id)
    {
        // Arrange
        var request = _queryBuilder.WithId(id).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForId();
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenRequestIsValid()
    {
        // Arrange
        var request = _queryBuilder.Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }
}
