namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Commands.Add;

public class AddChatMessageCommandRequestValidatorUnitTests : BaseChatMessageApplicationCommandUnitTest
{
	private readonly AddChatMessageCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddChatMessageCommandRequestBuilder _requestBuilder;
	private readonly AddChatMessageCommandRequest _request;

	private readonly AddChatMessageCommandRequestValidator _requestValidator;

	public AddChatMessageCommandRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat);
		_request = _requestBuilder.Build();

		_requestValidator = new();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var result = _requestValidator.TestValidate(request);

		// Assert
		result.ShouldHaveValidationErrorForParticipantOneId(messageTransformer, request);
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
	[ChatMessageContentNullWithMessageData]
	[ChatMessageContentEmptyWithMessageData]
	[ChatMessageContentTooShortWithMessageData]
	[ChatMessageContentTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenContentIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Act
		var result = _requestValidator.TestValidate(request);

		// Assert
		result.ShouldHaveValidationErrorForContent(messageTransformer, request);
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
