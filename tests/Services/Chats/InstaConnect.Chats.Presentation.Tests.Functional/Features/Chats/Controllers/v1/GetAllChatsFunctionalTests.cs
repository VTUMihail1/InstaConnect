using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.Chats.Controllers.v1;

public class GetAllChatsFunctionalTests : BaseChatPresentationQueryFunctionalTest
{
    private readonly GetAllChatsApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllChatsApiRequestBuilder _requestBuilder;
    private readonly GetAllChatsApiRequest _request;

    public GetAllChatsFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Chat);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserRangeAsync(ParticipantOnes, CancellationToken);
        await ServiceScope.AddUserRangeAsync(ParticipantTwos, CancellationToken);
        await ServiceScope.AddChatRangeAsync(Chats, CancellationToken);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.GetAllChatsStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Theory]
    [UserNameTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenUserNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantTwoNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForParticipantTwoName(messageTransformer, request);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForCurrentUserId(messageTransformer, request);
    }

    [Theory]
    [ChatsSortOrderEmptyData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [ChatsSortOrderEmptyWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortOrder(messageTransformer, request);
    }

    [Theory]
    [ChatsSortTermEmptyData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortTermIsInvalid(
        IEnumTransformer<ChatsSortTerm> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [ChatsSortTermEmptyWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortTermIsInvalid(
        IEnumTransformer<ChatsSortTerm> transformer, IEnumMessageTransformer<ChatsSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortTerm(messageTransformer, request);
    }

    [Theory]
    [ChatPageTooSmallData]
    [ChatPageTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [ChatPageTooSmallWithMessageData]
    [ChatPageTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPage(messageTransformer, request);
    }

    [Theory]
    [ChatPageSizeTooSmallData]
    [ChatPageSizeTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [ChatPageSizeTooSmallWithMessageData]
    [ChatPageSizeTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPageSize(messageTransformer, request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantTwoNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [ChatsSortOrderAscendingData]
    [ChatsSortOrderDescendingData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [ChatsSortTermCreatedAtData]
    [ChatsSortTermParticipantTwoNameData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortTermAreValid(
        IEnumTransformer<ChatsSortTerm> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllChatsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ParticipantOne, Chats, _request);
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndParticipantTwoNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ParticipantOne, Chats, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ParticipantOne, Chats, request);
    }

    [Theory]
    [ChatsSortOrderWithAscendingTermData]
    [ChatsSortOrderWithDescendingTermData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Chat> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ParticipantOne, Chats, request, termTransformer);
    }

    [Theory]
    [ChatsSortTermWithCreatedAtTermData]
    [ChatsSortTermWithParticipantTwoNameTermData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
        IEnumTransformer<ChatsSortTerm> transformer, ISortEnumTermTransformer<Chat> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ParticipantOne, Chats, request, termTransformer);
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndParticipantTwoNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name, transformer).WithCurrentUserId(ParticipantTwo.Id).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id, transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [ChatsSortOrderAscendingData]
    [ChatsSortOrderDescendingData]
    public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id).WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [ChatsSortTermCreatedAtData]
    [ChatsSortTermParticipantTwoNameData]
    public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndSortTermAreValid(
        IEnumTransformer<ChatsSortTerm> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id).WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id).Build();

        // Act
        var response = await HttpClient.GetAllChatsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ParticipantTwo, Chats, request);
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantTwoNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name, transformer).WithCurrentUserId(ParticipantTwo.Id).Build();

        // Act
        var response = await HttpClient.GetAllChatsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ParticipantTwo, Chats, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndCurrentUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id, transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ParticipantTwo, Chats, request);
    }

    [Theory]
    [ChatsSortOrderWithAscendingTermData]
    [ChatsSortOrderWithDescendingTermData]
    public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Chat> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id).WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ParticipantTwo, Chats, request, termTransformer);
    }

    [Theory]
    [ChatsSortTermWithCreatedAtTermData]
    [ChatsSortTermWithParticipantTwoNameTermData]
    public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndSortTermAreValid(
        IEnumTransformer<ChatsSortTerm> transformer, ISortEnumTermTransformer<Chat> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id).WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllChatsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ParticipantTwo, Chats, request, termTransformer);
    }
}
