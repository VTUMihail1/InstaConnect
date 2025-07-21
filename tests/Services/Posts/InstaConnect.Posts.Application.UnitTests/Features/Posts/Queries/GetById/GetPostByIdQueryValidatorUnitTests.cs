using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;

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

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenIdIsInvalid(string id, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithId(id).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForId(errorMessage);
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
