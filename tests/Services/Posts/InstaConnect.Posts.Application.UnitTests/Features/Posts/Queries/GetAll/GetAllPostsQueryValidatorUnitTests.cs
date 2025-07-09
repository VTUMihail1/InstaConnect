using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

using Xunit.Sdk;

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
    [UserIdTooLongData]
    public void TestValidate_ShouldHaveAnError_WhenUserIdLengthIsInvalid(string userId, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithUserId(userId).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForUserId(errorMessage);
    }

    [Theory]
    [UserNameTooLongData]
    public void TestValidate_ShouldHaveAnError_WhenUserNameLengthIsInvalid(string userName, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithUserName(userName).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForUserName(errorMessage);
    }

    [Theory]
    [PostTitleTooLongData]
    public void TestValidate_ShouldHaveAnError_WhenTitleLengthIsInvalid(string title, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithTitle(title).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForTitle(errorMessage);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenSortOrderIsEmpty()
    {
        // Arrange
        var request = _queryBuilder.WithEmptySortOrder().Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortProperty(CommonErrorMessages.GetSortOrderEmpty());
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenSortPropertyIsEmpty()
    {
        // Arrange
        var request = _queryBuilder.WithEmptySortProperty().Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortProperty(PostErrorMessages.GetSortPropertyEmpty());
    }

    [Theory]
    [PostPageTooSmallData]
    [PostPageTooLargeData]
    public void TestValidate_ShouldHaveAnError_WhenPageIsInvalid(int page, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithPage(page).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPage(errorMessage);
    }

    [Theory]
    [PostPageSizeTooSmallData]
    [PostPageSizeTooLargeData]
    public void TestValidate_ShouldHaveAnError_WhenPageSizeIsInvalid(int pageSize, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithPageSize(pageSize).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPageSize(errorMessage);
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
