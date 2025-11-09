using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Queries.GetAll;

public class GetAllPostCommentLikesQueryRequestValidatorUnitTests : BasePostCommentLikeApplicationUnitTest
{
    private readonly GetAllPostCommentLikesQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentLikesQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentLikesQueryRequest _request;

    private readonly GetAllPostCommentLikesQueryRequestValidator _requestValidator;

    public GetAllPostCommentLikesQueryRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike, User);
        _request = _requestBuilder.Build();

        _requestValidator = new();
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Filter.Id, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForId(errorMessage);
    }

    [Theory]
    [PostCommentIdNullWithMessageData]
    [PostCommentIdEmptyWithMessageData]
    [PostCommentIdTooShortWithMessageData]
    [PostCommentIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenCommentIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.Filter.CommentId, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForId(errorMessage);
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenUserNameIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(_request.Filter.UserName, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForUserName(errorMessage);
    }

    [Theory]
    [SortOrderEmptyWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenSortOrderIsInvalid(
        IEnumTransformer<SortOrder> transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(_request.Sorting.Order, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortOrder(errorMessage);
    }

    [Theory]
    [PostCommentLikeSortPropertyEmptyWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostCommentLikeSortProperty> transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(_request.Sorting.Property, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortProperty(errorMessage);
    }

    [Theory]
    [PostCommentLikePageTooSmallWithMessageData]
    [PostCommentLikePageTooLargeWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenPageIsInvalid(
        IIntTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithPage(_request.Pagination.Page, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPage(errorMessage);
    }

    [Theory]
    [PostCommentLikePageSizeTooSmallWithMessageData]
    [PostCommentLikePageSizeTooLargeWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenPageSizeIsInvalid(
        IIntTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(_request.Pagination.PageSize, transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPageSize(errorMessage);
    }

    [Theory]
    [UserNameEmptyData]
    [UserNameNullData]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenUserNameIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(_request.Filter.UserName, transformer).Build();

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
