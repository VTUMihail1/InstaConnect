namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.Chats.Controllers.v1;

public class GetChatByIdFunctionalTests : BaseChatPresentationQueryFunctionalTest
{
	private readonly GetChatByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetChatByIdApiRequestBuilder _requestBuilder;
	private readonly GetChatByIdApiRequest _request;

	public GetChatByIdFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
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
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await Client.GetByIdUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Client.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantTwoId(messageTransformer, request);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentUserId(messageTransformer, request);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteChatAsync(Chat, CancellationToken);

		// Act
		var response = await Client.GetByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveChatNotFoundProblemDetails_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteChatAsync(Chat, CancellationToken);

		// Act
		var response = await Client.GetByIdProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatNotFound(_request);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Client.GetByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Client.GetByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chat, _request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Client.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chat, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chat, request);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveInvertedOkStatusCode_WhenRequestIsValid()
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id, transformer).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id, transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveInvertedResponse_WhenRequestIsValid()
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Client.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(Chat, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveInvertedResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id, transformer).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Client.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(Chat, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id, transformer).Build();

		// Act
		var response = await Client.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(Chat, request);
	}
}
