using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Queries.GetAll;

public class GetAllPostsQueryRequestValidatorUnitTests : BasePostApplicationUnitTest
{
    private readonly GetAllPostsQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostsQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostsQueryRequest _request;

    private readonly GetAllPostsQueryRequestValidator _requestValidator;

    public GetAllPostsQueryRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, User);
        _request = _requestBuilder.Build();

        _requestValidator = new();
    }

    [Theory]
    [UserIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForUserId(messageTransformer, request);
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenUserNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForUserName(messageTransformer, request);
    }

    [Theory]
    [PostTitleTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenTitleIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForTitle(messageTransformer, request);
    }

    [Theory]
    [SortOrderEmptyWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortOrder(messageTransformer, request);
    }

    [Theory]
    [PostSortPropertyEmptyWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostSortProperty> transformer, IEnumMessageTransformer<PostSortProperty> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortProperty(messageTransformer, request);
    }

    [Theory]
    [PostPageTooSmallWithMessageData]
    [PostPageTooLargeWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenPageIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPage(messageTransformer, request);
    }

    [Theory]
    [PostPageSizeTooSmallWithMessageData]
    [PostPageSizeTooLargeWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenPageSizeIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPageSize(messageTransformer, request);
    }

    [Theory]
    [UserIdEmptyData]
    [UserIdNullData]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenUserIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }

    [Theory]
    [UserNameEmptyData]
    [UserNameNullData]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenUserNameIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }

    [Theory]
    [PostTitleEmptyData]
    [PostTitleNullData]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenTitleIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenRequestIsValid()
    {
        // Act
        var result = _requestValidator.TestValidate(_request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }
}
