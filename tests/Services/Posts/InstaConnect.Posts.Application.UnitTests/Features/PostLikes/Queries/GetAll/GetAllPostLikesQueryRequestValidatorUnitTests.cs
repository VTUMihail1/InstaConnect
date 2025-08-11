using InstaConnect.Common.Models.Enums;
using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Application.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetAllQueryRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Page;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.PageSize;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.SortProperty;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;

namespace InstaConnect.PostLikes.Application.UnitTests.Features.PostLikes.Queries.GetAll;

public class GetAllPostLikesQueryRequestValidatorUnitTests : BasePostLikeApplicationUnitTest
{
    private readonly GetAllPostLikesQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostLikesQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostLikesQueryRequest _request;

    private readonly GetAllPostLikesQueryRequestValidator _requestValidator;

    public GetAllPostLikesQueryRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike, User);
        _request = _requestBuilder.Create();

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
        var request = _requestBuilder.WithId(_request.Filter.Id, transformer).Create();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForId(errorMessage);
    }

    [Theory]
    [UserIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenUserIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.Filter.UserId, transformer).Create();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForUserId(errorMessage);
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenUserNameIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(_request.Filter.UserName, transformer).Create();

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
        var request = _requestBuilder.WithSortOrder(_request.Sorting.Order, transformer).Create();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortOrder(errorMessage);
    }

    [Theory]
    [PostLikeSortPropertyEmptyWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostLikeSortProperty> transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(_request.Sorting.Property, transformer).Create();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortProperty(errorMessage);
    }

    [Theory]
    [PostLikePageTooSmallWithMessageData]
    [PostLikePageTooLargeWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenPageIsInvalid(
        IIntTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithPage(_request.Pagination.Page, transformer).Create();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPage(errorMessage);
    }

    [Theory]
    [PostLikePageSizeTooSmallWithMessageData]
    [PostLikePageSizeTooLargeWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenPageSizeIsInvalid(
        IIntTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(_request.Pagination.PageSize, transformer).Create();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPageSize(errorMessage);
    }

    [Theory]
    [UserIdEmptyData]
    [UserIdNullData]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenUserIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.Filter.UserId, transformer).Create();

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
        var request = _requestBuilder.WithUserName(_request.Filter.UserName, transformer).Create();

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
