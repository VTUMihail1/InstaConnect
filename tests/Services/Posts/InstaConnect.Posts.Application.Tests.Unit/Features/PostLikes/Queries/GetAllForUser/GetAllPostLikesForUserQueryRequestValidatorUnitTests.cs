using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortTerm;
using InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortTerm.ForUser;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Queries.GetAllForUser;

public class GetAllPostLikesForUserQueryRequestValidatorUnitTests : BasePostLikeApplicationQueryUnitTest
{
    private readonly GetAllPostLikesForUserQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostLikesForUserQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostLikesForUserQueryRequest _request;

    private readonly GetAllPostLikesForUserQueryRequestValidator _requestValidator;

    public GetAllPostLikesForUserQueryRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();

        _requestValidator = new();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
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
    [UserIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenCurrentUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForCurrentUserId(messageTransformer, request);
    }

    [Theory]
    [PostLikesSortOrderEmptyWithMessageData]
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
    [PostLikesForUserSortTermEmptyWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenSortTermIsInvalid(
        IEnumTransformer<PostLikesForUserSortTerm> transformer, IEnumMessageTransformer<PostLikesForUserSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortTerm(messageTransformer, request);
    }

    [Theory]
    [PostLikePageTooSmallWithMessageData]
    [PostLikePageTooLargeWithMessageData]
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
    [PostLikePageSizeTooSmallWithMessageData]
    [PostLikePageSizeTooLargeWithMessageData]
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
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenCurrentUserIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

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
