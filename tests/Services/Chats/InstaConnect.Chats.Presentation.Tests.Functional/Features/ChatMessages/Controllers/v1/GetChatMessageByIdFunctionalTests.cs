using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Controllers.v1;

public class GetChatMessageByIdFunctionalTests : BaseChatMessagePresentationQueryFunctionalTest
{
    private readonly GetChatMessageByIdApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetChatMessageByIdApiRequestBuilder _requestBuilder;
    private readonly GetChatMessageByIdApiRequest _request;

    public GetChatMessageByIdFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
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

    [Fact]
    public async Task GetByIdAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.GetChatMessageByIdStatusCodeUnauthorizedAsync(_request, CancellationToken);

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
        var response = await HttpClient.GetChatMessageByIdStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetChatMessageByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForParticipantTwoId(messageTransformer, request);
    }

    [Theory]
    [ChatMessageIdTooShortData]
    [ChatMessageIdTooLongData]
    public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenMessageIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithMessageId(transformer).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [ChatMessageIdTooShortWithMessageData]
    [ChatMessageIdTooLongWithMessageData]
    public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenMessageIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithMessageId(transformer).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForMessageId(messageTransformer, request);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForCurrentUserId(messageTransformer, request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteChatAsync(Chat, CancellationToken);

        // Act
        var response = await HttpClient.GetChatMessageByIdStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveChatNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteChatAsync(Chat, CancellationToken);

        // Act
        var response = await HttpClient.GetChatMessageByIdProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyChatNotFound(_request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenMessageIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteChatMessageAsync(ChatMessage, CancellationToken);

        // Act
        var response = await HttpClient.GetChatMessageByIdStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveChatMessageNotFoundProblemDetails_WhenMessageIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteChatMessageAsync(ChatMessage, CancellationToken);

        // Act
        var response = await HttpClient.GetChatMessageByIdProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyChatMessageNotFound(_request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetChatMessageByIdStatusCodeAsync(_request, CancellationToken);

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
        var response = await HttpClient.GetChatMessageByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [ChatMessageIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndMessageIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithMessageId(transformer).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetChatMessageByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetChatMessageByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ChatMessage, _request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndParticipantTwoIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ChatMessage, request);
    }

    [Theory]
    [ChatMessageIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndMessageIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithMessageId(transformer).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ChatMessage, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ChatMessage, request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveInvertedOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetChatMessageByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [ChatMessageIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndMessageIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).WithMessageId(transformer).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetChatMessageByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveInvertedResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ChatMessage, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveInvertedResponse_WhenRequestAndParticipantTwoIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id, transformer).WithCurrentUserId(ParticipantTwo.Id).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ChatMessage, request);
    }

    [Theory]
    [ChatMessageIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveInvertedResponse_WhenRequestAndMessageIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).WithMessageId(transformer).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ChatMessage, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenRequestAndCurrentUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id, transformer).Build();

        // Act
        var response = await HttpClient.GetChatMessageByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ChatMessage, request);
    }
}
