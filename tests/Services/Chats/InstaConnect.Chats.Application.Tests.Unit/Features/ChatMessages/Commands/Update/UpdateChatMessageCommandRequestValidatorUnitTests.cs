namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Commands.Update;

public class UpdateChatMessageCommandRequestValidatorUnitTests : BaseChatMessageApplicationCommandUnitTest
{
    private readonly UpdateChatMessageCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdateChatMessageCommandRequestBuilder _requestBuilder;
    private readonly UpdateChatMessageCommandRequest _request;

    private readonly UpdateChatMessageCommandRequestValidator _requestValidator;

    public UpdateChatMessageCommandRequestValidatorUnitTests()
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
    [ChatMessageIdNullWithMessageData]
    [ChatMessageIdEmptyWithMessageData]
    [ChatMessageIdTooShortWithMessageData]
    [ChatMessageIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenMessageIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithMessageId(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForMessageId(messageTransformer, request);
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
