namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Controllers.v1;

public class AddChatMessageFunctionalTests : BaseChatMessagePresentationCommandFunctionalTest
{
	private readonly AddChatMessageApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddChatMessageApiRequestBuilder _requestBuilder;
	private readonly AddChatMessageApiRequest _request;

	public AddChatMessageFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddUserAsync(ParticipantTwo, CancellationToken);
		await ServiceScope.AddChatAsync(Chat, CancellationToken);
		await NotificationClient.ConnectAsync(CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await HttpClient.AddUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await HttpClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantOneId(messageTransformer, request);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantTwoId(messageTransformer, request);
	}

	[Theory]
	[ChatMessageContentNullData]
	[ChatMessageContentEmptyData]
	[ChatMessageContentTooShortData]
	[ChatMessageContentTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenContentIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Act
		var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessageContentNullWithMessageData]
	[ChatMessageContentEmptyWithMessageData]
	[ChatMessageContentTooShortWithMessageData]
	[ChatMessageContentTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenContentIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Act
		var response = await HttpClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForContent(messageTransformer, request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteChatAsync(Chat, CancellationToken);

		// Act
		var response = await HttpClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveChatNotFoundProblemDetails_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteChatAsync(Chat, CancellationToken);

		// Act
		var response = await HttpClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, _request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, request);
	}

	[Fact]
	public async Task AddAsync_ShouldAddChatMessage_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}


	[Fact]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.AddAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveInvertedOkStatusCode_WhenRequestIsValid()
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenRequestIsValid()
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, request);
	}

	[Fact]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenRequestIsValid()
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenRequestIsValid()
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await HttpClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}
}
