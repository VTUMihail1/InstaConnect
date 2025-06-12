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
        var query = _queryBuilder.WithUserId(userId).Create();

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorForUserId();
    }

    [Theory]
    [UserNameOutOfBoundsMaxData]
    public void TestValidate_ShouldHaveAnError_WhenUserNameLengthIsInvalid(string userName)
    {
        // Arrange
        var query = _queryBuilder.WithUserName(userName).Create();

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorForUserName();
    }

    [Theory]
    [PostTitleOutOfBoundsMaxData]
    public void TestValidate_ShouldHaveAnError_WhenTitleLengthIsInvalid(string title)
    {
        // Arrange
        var query = _queryBuilder.WithTitle(title).Create();

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorForTitle();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenSortOrderIsEmpty()
    {
        // Arrange
        var query = _queryBuilder.WithEmptySortOrder().Create();

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorForSortProperty();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenSortPropertyIsEmpty()
    {
        // Arrange
        var query = _queryBuilder.WithEmptySortProperty().Create();

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorForSortProperty();
    }

    [Theory]
    [PostPageOutOfBoundsMinData]
    [PostPageOutOfBoundsMaxData]
    public void TestValidate_ShouldHaveAnError_WhenPageIsInvalid(int page)
    {
        // Arrange
        var query = _queryBuilder.WithPage(page).Create();

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorForPage();
    }

    [Theory]
    [PostPageSizeOutOfBoundsMinData]
    [PostPageSizeOutOfBoundsMaxData]
    public void TestValidate_ShouldHaveAnError_WhenPageSizeIsInvalid(int pageSize)
    {
        // Arrange
        var query = _queryBuilder.WithPageSize(pageSize).Create();

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorForPageSize();
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenQueryIsValid()
    {
        // Arrange
        var query = _queryBuilder.Create();

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }
}
