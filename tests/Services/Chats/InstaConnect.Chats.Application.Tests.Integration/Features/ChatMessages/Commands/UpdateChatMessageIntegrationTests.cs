using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Commands;

public class UpdateChatMessageIntegrationTests : BaseChatMessageApplicationCommandIntegrationTest
{
    private readonly UpdateChatMessageCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdateChatMessageCommandRequestBuilder _requestBuilder;
    private readonly UpdateChatMessageCommandRequest _request;

    public UpdateChatMessageIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(ChatMessage);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(ParticipantOne, CancellationToken);
        await ServiceScope.AddUserAsync(ParticipantTwo, CancellationToken);
        await ServiceScope.AddChatAsync(Chat, CancellationToken);
        await ServiceScope.AddChatMessageAsync(ChatMessage, CancellationToken);
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenParticipantOneIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantOneId(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForParticipantOneIdAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenParticipantTwoIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [ChatMessageIdNullWithMessageData]
    [ChatMessageIdEmptyWithMessageData]
    [ChatMessageIdTooShortWithMessageData]
    [ChatMessageIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenMessageIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithMessageId(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForMessageIdAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [ChatMessageContentNullWithMessageData]
    [ChatMessageContentEmptyWithMessageData]
    [ChatMessageContentTooShortWithMessageData]
    [ChatMessageContentTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenContentIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithContent(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForContentAsync(
            messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowChatNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteChatAsync(Chat, CancellationToken);

        // Assert
        await Sender.ShouldThrowChatNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowChatMessageNotFoundException_WhenMessageIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteChatMessageAsync(ChatMessage, CancellationToken);

        // Assert
        await Sender.ShouldThrowChatMessageNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowChatMessageForbiddenException_WhenParticipantOneIdIsInvalid()
    {
        // Arrange
        var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

        // Assert
        await Sender.ShouldThrowChatMessageForbiddenExceptionAsync(request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(chatMessage, _request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndParticipantOneIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantOneId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(chatMessage, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndParticipantTwoIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(chatMessage, request);
    }

    [Theory]
    [ChatMessageIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndMessageIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithMessageId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(chatMessage, request);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdateChatMessage_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        chatMessage.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldUpdateChatMessage_WhenRequestAndParticipantOneIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantOneId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        chatMessage.ShouldSatisfy(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldUpdateChatMessage_WhenRequestAndParticipantTwoIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        chatMessage.ShouldSatisfy(request);
    }

    [Theory]
    [ChatMessageIdDifferentCaseData]
    public async Task SendAsync_ShouldUpdateChatMessage_WhenRequestAndMessageIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithMessageId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        chatMessage.ShouldSatisfy(request);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestIsValid()
    {
        // Arrange
        var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
        await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
        var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(chatMessage, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantOneIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
        await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
        var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(chatMessage, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantTwoIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
        await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
        var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(chatMessage, request);
    }

    [Theory]
    [ChatMessageIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndMessageIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
        await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
        var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).WithMessageId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(chatMessage, request);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdateInvertedChatMessage_WhenRequestIsValid()
    {
        // Arrange
        var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
        await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
        var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        chatMessage.ShouldSatisfyInverted(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldUpdateInvertedChatMessage_WhenRequestAndParticipantOneIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
        await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
        var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        chatMessage.ShouldSatisfyInverted(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldUpdateInvertedChatMessage_WhenRequestAndParticipantTwoIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
        await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
        var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        chatMessage.ShouldSatisfyInverted(request);
    }

    [Theory]
    [ChatMessageIdDifferentCaseData]
    public async Task SendAsync_ShouldUpdateInvertedChatMessage_WhenRequestAndMessageIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
        await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
        var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).WithMessageId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

        // Assert
        chatMessage.ShouldSatisfyInverted(request);
    }
}
