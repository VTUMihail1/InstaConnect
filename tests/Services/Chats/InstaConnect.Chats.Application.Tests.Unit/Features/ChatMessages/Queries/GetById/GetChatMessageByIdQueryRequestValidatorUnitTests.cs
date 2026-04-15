namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Queries.GetById;

public class GetChatMessageByIdQueryRequestValidatorUnitTests : BaseChatMessageApplicationQueryUnitTest
{
    private readonly GetChatMessageByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetChatMessageByIdQueryRequestBuilder _requestBuilder;
    private readonly GetChatMessageByIdQueryRequest _request;

    private readonly GetChatMessageByIdQueryRequestValidator _requestValidator;

    public GetChatMessageByIdQueryRequestValidatorUnitTests()
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

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenRequestIsValid()
    {
        // Act
        var result = _requestValidator.TestValidate(_request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }
}
