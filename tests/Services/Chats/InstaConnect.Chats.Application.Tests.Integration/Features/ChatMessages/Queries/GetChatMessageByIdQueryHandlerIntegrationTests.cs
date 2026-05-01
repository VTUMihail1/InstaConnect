namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Queries;

public class GetChatMessageByIdQueryHandlerIntegrationTests : BaseChatMessageApplicationQueryIntegrationTest
{
	private readonly GetChatMessageByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetChatMessageByIdQueryRequestBuilder _requestBuilder;
	private readonly GetChatMessageByIdQueryRequest _request;

	public GetChatMessageByIdQueryHandlerIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
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
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
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
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessage, _request);
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

		// Assert
		response.ShouldSatisfy(ChatMessage, request);
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

		// Assert
		response.ShouldSatisfy(ChatMessage, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(ChatMessage, request);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestIsValid()
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(ChatMessage, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id, transformer).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(ChatMessage, request);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithMessageId(transformer).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(ChatMessage, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id, transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(ChatMessage, request);
	}
}
