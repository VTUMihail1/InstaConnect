namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Controllers.v1;

public class UpdateChatMessageFunctionalTests : BaseChatMessagePresentationCommandFunctionalTest
{
	private readonly UpdateChatMessageApiRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateChatMessageApiRequestBuilder _requestBuilder;
	private readonly UpdateChatMessageApiRequest _request;

	public UpdateChatMessageFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
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

		await base.OnInitializeAsync();
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await HttpClient.UpdateUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantOneId(messageTransformer, request);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantTwoId(messageTransformer, request);
	}

	[Theory]
	[ChatMessageIdTooShortData]
	[ChatMessageIdTooLongData]
	public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenMessageIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessageIdTooShortWithMessageData]
	[ChatMessageIdTooLongWithMessageData]
	public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenMessageIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForMessageId(messageTransformer, request);
	}

	[Theory]
	[ChatMessageContentNullData]
	[ChatMessageContentEmptyData]
	[ChatMessageContentTooShortData]
	[ChatMessageContentTooLongData]
	public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenContentIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessageContentNullWithMessageData]
	[ChatMessageContentEmptyWithMessageData]
	[ChatMessageContentTooShortWithMessageData]
	[ChatMessageContentTooLongWithMessageData]
	public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenContentIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Act
		var response = await HttpClient.UpdateProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForContent(messageTransformer, request);
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteChatAsync(Chat, CancellationToken);

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveChatNotFoundProblemDetails_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteChatAsync(Chat, CancellationToken);

		// Act
		var response = await HttpClient.UpdateProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatNotFound(_request);
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveNotFoundStatusCode_WhenMessageIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteChatMessageAsync(ChatMessage, CancellationToken);

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveChatMessageNotFoundProblemDetails_WhenMessageIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteChatMessageAsync(ChatMessage, CancellationToken);

		// Act
		var response = await HttpClient.UpdateProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatMessageNotFound(_request);
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveForbiddenStatusCode_WhenParticipantOneIdIsInvalid()
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeForbidden();
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveChatMessageForbiddenProblemDetails_WhenParticipantOneIdIsInvalid()
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.UpdateProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatMessageForbidden(request);
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveOkStatusCode_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveResponse_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.UpdateAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessage, _request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, request);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveResponse_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessage, request);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.UpdateAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishChatMessageUpdatedNotification_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.UpdateAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.UpdatedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishChatMessageUpdatedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.UpdatedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishChatMessageUpdatedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.UpdatedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishChatMessageUpdatedNotification_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.UpdatedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveInvertedOkStatusCode_WhenRequestIsValid()
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).WithMessageId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveInvertedResponse_WhenRequestIsValid()
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessage, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, request);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveInvertedResponse_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).WithMessageId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessage, request);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenRequestIsValid()
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(request);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).WithMessageId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(request);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenRequestIsValid()
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.UpdatedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.UpdatedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.UpdatedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwo.Id).Build();
		await ServiceScope.UpdateChatMessageAsync(updatedChatMessage, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).WithMessageId(transformer).Build();

		// Act
		var response = await HttpClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.UpdatedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}
}
