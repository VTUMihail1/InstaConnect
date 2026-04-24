using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.UserClaims.Queries.GetAll;

public class GetAllUserClaimsQueryRequestValidatorUnitTests : BaseUserClaimApplicationQueryUnitTest
{
    private readonly GetAllUserClaimsQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllUserClaimsQueryRequestBuilder _requestBuilder;
    private readonly GetAllUserClaimsQueryRequest _request;

    private readonly GetAllUserClaimsQueryRequestValidator _requestValidator;

    public GetAllUserClaimsQueryRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(UserClaim);
        _request = _requestBuilder.Build();

        _requestValidator = new();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForId(messageTransformer, request);
    }

    [Theory]
    [UserIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenCurrentIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentId(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForCurrentId(messageTransformer, request);
    }

    [Theory]
    [UserClaimsSortOrderEmptyWithMessageData]
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
    [UserClaimsSortTermEmptyWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenSortTermIsInvalid(
        IEnumTransformer<UserClaimsSortTerm> transformer, IEnumMessageTransformer<UserClaimsSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortTerm(messageTransformer, request);
    }

    [Theory]
    [UserClaimPageTooSmallWithMessageData]
    [UserClaimPageTooLargeWithMessageData]
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
    [UserClaimPageSizeTooSmallWithMessageData]
    [UserClaimPageSizeTooLargeWithMessageData]
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
    [UserIdNullData]
    [UserIdEmptyData]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenCurrentIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentId(transformer).Build();

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
