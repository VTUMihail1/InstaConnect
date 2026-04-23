using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.Chats.Controllers.v1;

public class AddChatFunctionalTests : BaseChatPresentationCommandFunctionalTest
{
    private readonly AddChatApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddChatApiRequestBuilder _requestBuilder;
    private readonly AddChatApiRequest _request;

    public AddChatFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
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

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.AddChatStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenParticipantOneIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantOneId(transformer).Build();

        // Act
        var response = await HttpClient.AddChatStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantOneIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantOneId(transformer).Build();

        // Act
        var response = await HttpClient.AddChatProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForParticipantOneId(messageTransformer, request);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenParticipantTwoIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

        // Act
        var response = await HttpClient.AddChatStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantTwoIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

        // Act
        var response = await HttpClient.AddChatProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForParticipantTwoId(messageTransformer, request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenParticipantOneIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(ParticipantOne, CancellationToken);

        // Act
        var response = await HttpClient.AddChatStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task AddAsync_ShouldHaveParticipantOneNotFoundProblemDetails_WhenParticipantOneIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(ParticipantOne, CancellationToken);

        // Act
        var response = await HttpClient.AddChatProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyParticipantOneNotFound(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenParticipantTwoIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(ParticipantTwo, CancellationToken);

        // Act
        var response = await HttpClient.AddChatStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task AddAsync_ShouldHaveParticipantTwoNotFoundProblemDetails_WhenParticipantTwoIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(ParticipantTwo, CancellationToken);

        // Act
        var response = await HttpClient.AddChatProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyParticipantTwoNotFound(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveChatAlreadyExistsProblemDetails_WhenChatAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddChatAsync(Chat, CancellationToken);

        // Act
        var response = await HttpClient.AddChatProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyChatAlreadyExists(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveChatAlreadyExistsProblemDetails_WhenChatAlreadyExistsAndParticipantOneIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddChatAsync(Chat, CancellationToken);
        var request = _requestBuilder.WithParticipantOneId(transformer).Build();

        // Act
        var response = await HttpClient.AddChatProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyChatAlreadyExists(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveChatAlreadyExistsProblemDetails_WhenChatAlreadyExistsAndParticipantTwoIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddChatAsync(Chat, CancellationToken);
        var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

        // Act
        var response = await HttpClient.AddChatProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyChatAlreadyExists(request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveChatAlreadyExistsProblemDetails_WhenInvertedChatAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddChatAsync(Chat, CancellationToken);
        var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

        // Act
        var response = await HttpClient.AddChatProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyChatAlreadyExists(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveChatAlreadyExistsProblemDetails_WhenInvertedChatAlreadyExistsAndParticipantOneIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddChatAsync(Chat, CancellationToken);
        var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

        // Act
        var response = await HttpClient.AddChatProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyChatAlreadyExists(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveChatAlreadyExistsProblemDetails_WhenInvertedChatAlreadyExistsAndParticipantTwoIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddChatAsync(Chat, CancellationToken);
        var request = _requestBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

        // Act
        var response = await HttpClient.AddChatProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyChatAlreadyExists(request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddChatStatusCodeAsync(_request, CancellationToken);

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
        var response = await HttpClient.AddChatStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.AddChatStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddChatAsync(_request, CancellationToken);
        var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(chat, _request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndParticipantOneIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantOneId(transformer).Build();

        // Act
        var response = await HttpClient.AddChatAsync(request, CancellationToken);
        var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(chat, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndParticipantTwoIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

        // Act
        var response = await HttpClient.AddChatAsync(request, CancellationToken);
        var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(chat, request);
    }

    [Fact]
    public async Task AddAsync_ShouldAddChat_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddChatAsync(_request, CancellationToken);
        var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

        // Assert
        chat.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldAddChat_WhenRequestAndParticipantOneIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantOneId(transformer).Build();

        // Act
        var response = await HttpClient.AddChatAsync(request, CancellationToken);
        var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

        // Assert
        chat.ShouldSatisfy(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldAddChat_WhenRequestAndParticipantTwoIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

        // Act
        var response = await HttpClient.AddChatAsync(request, CancellationToken);
        var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

        // Assert
        chat.ShouldSatisfy(request);
    }

    [Fact]
    public async Task AddAsync_ShouldPublishChatAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddChatAsync(_request, CancellationToken);
        var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedChatAddedAsync(chat, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishChatAddedEvent_WhenRequestAndParticipantOneIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantOneId(transformer).Build();

        // Act
        var response = await HttpClient.AddChatAsync(request, CancellationToken);
        var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedChatAddedAsync(chat, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishChatAddedEvent_WhenRequestAndParticipantTwoIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

        // Act
        var response = await HttpClient.AddChatAsync(request, CancellationToken);
        var chat = await ServiceScope.GetChatByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedChatAddedAsync(chat, CancellationToken);
    }
}
