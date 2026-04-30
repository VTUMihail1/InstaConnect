using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Controllers.v1;

public class GetAllChatMessagesFunctionalTests : BaseChatMessagePresentationQueryFunctionalTest
{
	private readonly GetAllChatMessagesApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllChatMessagesApiRequestBuilder _requestBuilder;
	private readonly GetAllChatMessagesApiRequest _request;

	public GetAllChatMessagesFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ChatMessage);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserRangeAsync(ParticipantOnes, CancellationToken);
		await ServiceScope.AddUserRangeAsync(ParticipantTwos, CancellationToken);
		await ServiceScope.AddChatRangeAsync(Chats, CancellationToken);
		await ServiceScope.AddChatMessageRangeAsync(ChatMessages, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await HttpClient.GetAllUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantTwoId(messageTransformer, request);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentUserId(messageTransformer, request);
	}

	[Theory]
	[ChatMessagesSortOrderEmptyData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessagesSortOrderEmptyWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer,
		IEnumMessageTransformer<CommonSortOrder> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await HttpClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortOrder(messageTransformer, request);
	}

	[Theory]
	[ChatMessagesSortTermEmptyData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortTermIsInvalid(
		IEnumTransformer<ChatMessagesSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessagesSortTermEmptyWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortTermIsInvalid(
		IEnumTransformer<ChatMessagesSortTerm> transformer,
		IEnumMessageTransformer<ChatMessagesSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await HttpClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortTerm(messageTransformer, request);
	}

	[Theory]
	[ChatMessagePageTooSmallData]
	[ChatMessagePageTooLargeData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessagePageTooSmallWithMessageData]
	[ChatMessagePageTooLargeWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await HttpClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPage(messageTransformer, request);
	}

	[Theory]
	[ChatMessagePageSizeTooSmallData]
	[ChatMessagePageSizeTooLargeData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessagePageSizeTooSmallWithMessageData]
	[ChatMessagePageSizeTooLargeWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await HttpClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPageSize(messageTransformer, request);
	}

	[Fact]
	public async Task GetAllAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteChatAsync(Chat, CancellationToken);

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessagesSortOrderAscendingData]
	[ChatMessagesSortOrderDescendingData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessagesSortTermCreatedAtData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<ChatMessagesSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chat, ChatMessages, _request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chat, ChatMessages, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chat, ChatMessages, request);
	}

	[Theory]
	[ChatMessagesSortOrderWithAscendingTermData]
	[ChatMessagesSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await HttpClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chat, ChatMessages, request, termTransformer);
	}

	[Theory]
	[ChatMessagesSortTermWithCreatedAtTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<ChatMessagesSortTerm> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await HttpClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chat, ChatMessages, request, termTransformer);
	}

	[Fact]
	public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestIsValid()
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id, transformer).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id, transformer).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessagesSortOrderAscendingData]
	[ChatMessagesSortOrderDescendingData]
	public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).WithSortOrder(transformer).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessagesSortTermCreatedAtData]
	public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<ChatMessagesSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).WithSortTerm(transformer).Build();

		// Act
		var response = await HttpClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestIsValid()
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await HttpClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(Chat, ChatMessages, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveInvertedResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id, transformer).WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await HttpClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(Chat, ChatMessages, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id, transformer).Build();

		// Act
		var response = await HttpClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(Chat, ChatMessages, request);
	}

	[Theory]
	[ChatMessagesSortOrderWithAscendingTermData]
	[ChatMessagesSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).WithSortOrder(transformer).Build();

		// Act
		var response = await HttpClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(Chat, ChatMessages, request, termTransformer);
	}

	[Theory]
	[ChatMessagesSortTermWithCreatedAtTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<ChatMessagesSortTerm> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).WithSortTerm(transformer).Build();

		// Act
		var response = await HttpClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(Chat, ChatMessages, request, termTransformer);
	}
}
