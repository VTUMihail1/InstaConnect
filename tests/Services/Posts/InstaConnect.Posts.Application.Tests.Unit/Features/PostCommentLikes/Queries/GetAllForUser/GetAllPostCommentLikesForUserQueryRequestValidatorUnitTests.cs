using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Queries.GetAllForUser;

public class GetAllPostCommentLikesForUserQueryRequestValidatorUnitTests : BasePostCommentLikeApplicationQueryUnitTest
{
	private readonly GetAllPostCommentLikesForUserQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostCommentLikesForUserQueryRequestBuilder _requestBuilder;
	private readonly GetAllPostCommentLikesForUserQueryRequest _request;

	private readonly GetAllPostCommentLikesForUserQueryRequestValidator _requestValidator;

	public GetAllPostCommentLikesForUserQueryRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
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
	[PostCommentLikesSortOrderEmptyWithMessageData]
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
	[PostCommentLikesForUserSortTermEmptyWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenSortTermIsInvalid(
		IEnumTransformer<PostCommentLikesForUserSortTerm> transformer, IEnumMessageTransformer<PostCommentLikesForUserSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var result = _requestValidator.TestValidate(request);

		// Assert
		result.ShouldHaveValidationErrorForSortTerm(messageTransformer, request);
	}

	[Theory]
	[PostCommentLikePageTooSmallWithMessageData]
	[PostCommentLikePageTooLargeWithMessageData]
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
	[PostCommentLikePageSizeTooSmallWithMessageData]
	[PostCommentLikePageSizeTooLargeWithMessageData]
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
