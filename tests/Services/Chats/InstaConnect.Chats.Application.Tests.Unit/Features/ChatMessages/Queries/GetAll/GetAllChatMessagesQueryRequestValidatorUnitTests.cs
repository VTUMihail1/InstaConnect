using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Queries.GetAll;

public class GetAllChatMessagesQueryRequestValidatorUnitTests : BaseChatMessageApplicationQueryUnitTest
{
	private readonly GetAllChatMessagesQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllChatMessagesQueryRequestBuilder _requestBuilder;
	private readonly GetAllChatMessagesQueryRequest _request;

	private readonly GetAllChatMessagesQueryRequestValidator _requestValidator;

	public GetAllChatMessagesQueryRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ChatMessage);
		_request = _requestBuilder.Build();

		_requestValidator = new();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var result = _requestValidator.TestValidate(request);

		// Assert
		result.ShouldHaveValidationErrorForParticipantTwoId(messageTransformer, request);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
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
	[ChatMessagesSortOrderEmptyWithMessageData]
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
	[ChatMessagesSortTermEmptyWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenSortTermIsInvalid(
		IEnumTransformer<ChatMessagesSortTerm> transformer, IEnumMessageTransformer<ChatMessagesSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var result = _requestValidator.TestValidate(request);

		// Assert
		result.ShouldHaveValidationErrorForSortTerm(messageTransformer, request);
	}

	[Theory]
	[ChatMessagePageTooSmallWithMessageData]
	[ChatMessagePageTooLargeWithMessageData]
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
	[ChatMessagePageSizeTooSmallWithMessageData]
	[ChatMessagePageSizeTooLargeWithMessageData]
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

	[Fact]
	public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenRequestIsValid()
	{
		// Act
		var result = _requestValidator.TestValidate(_request);

		// Assert
		result.ShouldNotHaveAnyValidationErrorProperties();
	}
}
