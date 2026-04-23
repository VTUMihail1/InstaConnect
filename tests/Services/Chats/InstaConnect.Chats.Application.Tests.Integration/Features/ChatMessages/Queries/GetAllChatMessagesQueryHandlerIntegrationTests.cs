using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Tests.Features.Common.Utilities;
using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Queries;

public class GetAllChatMessagesQueryHandlerIntegrationTests : BaseChatMessageApplicationQueryIntegrationTest
{
    private readonly GetAllChatMessagesQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllChatMessagesQueryRequestBuilder _requestBuilder;
    private readonly GetAllChatMessagesQueryRequest _request;

    public GetAllChatMessagesQueryHandlerIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
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
    [ChatMessagesSortOrderEmptyWithMessageData]
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
    [ChatMessagesSortTermEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortTermIsInvalid(
        IEnumTransformer<ChatMessagesSortTerm> transformer, IEnumMessageTransformer<ChatMessagesSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForSortTermAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [ChatMessagePageTooSmallWithMessageData]
    [ChatMessagePageTooLargeWithMessageData]
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
    [ChatMessagePageSizeTooSmallWithMessageData]
    [ChatMessagePageSizeTooLargeWithMessageData]
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
    public async Task SendAsync_ShouldThrowChatNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteChatAsync(Chat, CancellationToken);

        // Assert
        await Sender.ShouldThrowChatNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Chat, ChatMessages, _request);
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
        response.ShouldSatisfy(Chat, ChatMessages, request);
    }

    [Theory]
    [ChatMessagesSortOrderWithAscendingTermData]
    [ChatMessagesSortOrderWithDescendingTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Chat, ChatMessages, request, termTransformer);
    }

    [Theory]
    [ChatMessagesSortTermWithCreatedAtTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
        IEnumTransformer<ChatMessagesSortTerm> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Chat, ChatMessages, request, termTransformer);
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
        response.ShouldSatisfy(Chat, ChatMessages, request);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(Chat, ChatMessages, request);
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
        response.ShouldSatisfyInverted(Chat, ChatMessages, request);
    }

    [Theory]
    [ChatMessagesSortOrderWithAscendingTermData]
    [ChatMessagesSortOrderWithDescendingTermData]
    public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).WithSortOrder(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(Chat, ChatMessages, request, termTransformer);
    }

    [Theory]
    [ChatMessagesSortTermWithCreatedAtTermData]
    public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndSortTermAreValid(
        IEnumTransformer<ChatMessagesSortTerm> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoId(ParticipantOne.Id).WithCurrentUserId(ParticipantTwo.Id).WithSortTerm(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInverted(Chat, ChatMessages, request, termTransformer);
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
        response.ShouldSatisfyInverted(Chat, ChatMessages, request);
    }
}
