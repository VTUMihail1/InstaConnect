namespace InstaConnect.Chats.Application.Tests.Integration.Features.Chats.Commands;

public class AddChatIntegrationTests : BaseChatApplicationCommandIntegrationTest
{
	private readonly AddChatCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddChatCommandRequestBuilder _requestBuilder;
	private readonly AddChatCommandRequest _request;

	public AddChatIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ParticipantOne, ParticipantTwo);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddUserAsync(ParticipantTwo, CancellationToken);
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

	[Fact]
	public async Task SendAsync_ShouldThrowParticipantOneNotFoundException_WhenParticipantOneIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(ParticipantOne, CancellationToken);

		// Assert
		await Sender.ShouldThrowParticipantOneNotFoundExceptionForAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowParticipantTwoNotFoundException_WhenParticipantTwoIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(ParticipantTwo, CancellationToken);

		// Assert
		await Sender.ShouldThrowParticipantTwoNotFoundExceptionForAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddChatAsync(Chat, CancellationToken);

		// Assert
		await Sender.ShouldThrowChatAlreadyExistsExceptionAsync(_request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExistsAndParticipantOneIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddChatAsync(Chat, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Assert
		await Sender.ShouldThrowChatAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExistsAndParticipantTwoIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddChatAsync(Chat, CancellationToken);
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Assert
		await Sender.ShouldThrowChatAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddChatAsync(Chat, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Assert
		await Sender.ShouldThrowChatAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExistsAndParticipantOneIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddChatAsync(Chat, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Assert
		await Sender.ShouldThrowChatAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExistsAndParticipantTwoIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddChatAsync(Chat, CancellationToken);
		var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Assert
		await Sender.ShouldThrowChatAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chat, _request);
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
		var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chat, request);
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
		var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chat, request);
	}

	[Fact]
	public async Task SendAsync_ShouldAddChat_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddChat_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddChat_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishChatAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedChatAddedAsync(chat, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishChatAddedEvent_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedChatAddedAsync(chat, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishChatAddedEvent_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedChatAddedAsync(chat, CancellationToken);
	}
}
