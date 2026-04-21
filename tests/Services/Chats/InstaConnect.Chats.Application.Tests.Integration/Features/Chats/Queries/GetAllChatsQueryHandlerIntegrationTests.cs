using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.Chats.Queries;

public class GetAllChatsQueryHandlerIntegrationTests : BaseChatApplicationQueryIntegrationTest
{
    private readonly GetAllChatsQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllChatsQueryRequestBuilder _requestBuilder;
    private readonly GetAllChatsQueryRequest _request;

    public GetAllChatsQueryHandlerIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
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

    [Theory]
    [UserNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenParticipantTwoNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForParticipantTwoNameAsync(
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

    [Theory]
    [ChatsSortOrderEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForSortOrderAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [ChatsSortTermEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortTermIsInvalid(
        IEnumTransformer<ChatsSortTerm> transformer, IEnumMessageTransformer<ChatsSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForSortTermAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [ChatPageTooSmallWithMessageData]
    [ChatPageTooLargeWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForPageAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [ChatPageSizeTooSmallWithMessageData]
    [ChatPageSizeTooLargeWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageSizeIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForPageSizeAsync(
            messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ParticipantOne, Chats, _request);
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndParticipantTwoNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ParticipantOne, Chats, request);
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
        response.ShouldSatisfy(ParticipantOne, Chats, request);
    }

    [Theory]
    [ChatsSortOrderWithAscendingTermData]
    [ChatsSortOrderWithDescendingTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Chat> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ParticipantOne, Chats, request, termTransformer);
    }

    [Theory]
    [ChatsSortTermWithCreatedAtTermData]
    [ChatsSortTermWithParticipantTwoNameTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
        IEnumTransformer<ChatsSortTerm> transformer, ISortEnumTermTransformer<Chat> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(ParticipantOne, Chats, request, termTransformer);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ParticipantTwo, Chats, request);
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantTwoNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name, transformer).WithCurrentUserId(ParticipantTwo.Id).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ParticipantTwo, Chats, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndCurrentUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id, transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ParticipantTwo, Chats, request);
    }

    [Theory]
    [ChatsSortOrderWithAscendingTermData]
    [ChatsSortOrderWithDescendingTermData]
    public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Chat> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id).WithSortOrder(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ParticipantTwo, Chats, request, termTransformer);
    }

    [Theory]
    [ChatsSortTermWithCreatedAtTermData]
    [ChatsSortTermWithParticipantTwoNameTermData]
    public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndSortTermAreValid(
        IEnumTransformer<ChatsSortTerm> transformer, ISortEnumTermTransformer<Chat> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(ParticipantOne.Name).WithCurrentUserId(ParticipantTwo.Id).WithSortTerm(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(ParticipantTwo, Chats, request, termTransformer);
    }
}
