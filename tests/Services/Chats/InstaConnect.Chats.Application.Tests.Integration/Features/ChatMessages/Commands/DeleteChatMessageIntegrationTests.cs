namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Commands;

public class DeleteChatMessageIntegrationTests : BaseChatMessageApplicationCommandIntegrationTest
{
	private readonly DeleteChatMessageCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteChatMessageCommandRequestBuilder _requestBuilder;
	private readonly DeleteChatMessageCommandRequest _request;

	public DeleteChatMessageIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
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

		await NotificationClient.ConnectAsync(CancellationToken);
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
	public async Task SendAsync_ShouldThrowChatMessageForbiddenException_WhenUserIdIsInvalid()
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Assert
		await Sender.ShouldThrowChatMessageForbiddenExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteChatMessage_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(ChatMessage.Id, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(ChatMessage.Id, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(ChatMessage.Id, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteChatMessage_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(ChatMessage.Id, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldPublishChatMessageDeletedNotification_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var notification = await NotificationClient.DeletedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishChatMessageDeletedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var notification = await NotificationClient.DeletedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishChatMessageDeletedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var notification = await NotificationClient.DeletedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishChatMessageDeletedNotification_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var notification = await NotificationClient.DeletedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(ChatMessage);
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteInvertedChatMessage_WhenRequestIsValid()
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(ChatMessage.Id, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteInvertedChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(ChatMessage.Id, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteInvertedChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(ChatMessage.Id, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteInvertedChatMessage_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).WithMessageId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(ChatMessage.Id, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenRequestIsValid()
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var notification = await NotificationClient.DeletedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var notification = await NotificationClient.DeletedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var notification = await NotificationClient.DeletedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).WithMessageId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var notification = await NotificationClient.DeletedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(ChatMessage);
	}
}
