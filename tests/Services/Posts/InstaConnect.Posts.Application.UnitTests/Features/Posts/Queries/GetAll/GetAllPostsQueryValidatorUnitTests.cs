using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Queries.GetAll;

public class GetAllPostsQueryValidatorUnitTests : BasePostUnitTest
{
    private readonly GetAllPostsQueryBuilder _queryBuilder;
    private readonly GetAllPostsQueryValidator _queryValidator;

    public GetAllPostsQueryValidatorUnitTests()
    {
        _queryBuilder = new();
        _queryValidator = new();
    }

    [Theory]
    [UserIdOutOfBoundsMaxData]
    public void TestValidate_ShouldHaveAnError_WhenUserIdLengthIsInvalid(string userId)
    {
        // Arrange
        var request = _queryBuilder.WithUserId(userId).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForUserId();
    }

    [Theory]
    [UserNameOutOfBoundsMaxData]
    public void TestValidate_ShouldHaveAnError_WhenUserNameLengthIsInvalid(string userName)
    {
        // Arrange
        var request = _queryBuilder.WithUserName(userName).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForUserName();
    }

    [Theory]
    [PostTitleOutOfBoundsMaxData]
    public void TestValidate_ShouldHaveAnError_WhenTitleLengthIsInvalid(string title)
    {
        // Arrange
        var request = _queryBuilder.WithTitle(title).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForTitle();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenSortOrderIsEmpty()
    {
        // Arrange
        var request = _queryBuilder.WithEmptySortOrder().Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortProperty();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenSortPropertyIsEmpty()
    {
        // Arrange
        var request = _queryBuilder.WithEmptySortProperty().Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortProperty();
    }

    [Theory]
    [PostPageOutOfBoundsMinData]
    [PostPageOutOfBoundsMaxData]
    public void TestValidate_ShouldHaveAnError_WhenPageIsInvalid(int page)
    {
        // Arrange
        var request = _queryBuilder.WithPage(page).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPage();
    }

    [Theory]
    [PostPageSizeOutOfBoundsMinData]
    [PostPageSizeOutOfBoundsMaxData]
    public void TestValidate_ShouldHaveAnError_WhenPageSizeIsInvalid(int pageSize)
    {
        // Arrange
        var request = _queryBuilder.WithPageSize(pageSize).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPageSize();
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
