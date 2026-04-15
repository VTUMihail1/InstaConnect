using InstaConnect.Common.Application.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageValidationExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowInvalidValidationExceptionForParticipantOneIdAsync(
        IStringMessageTransformer messageTransformer,
        AddChatMessageCommandRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<AddChatMessageCommandRequest, string, AddChatMessageCommandResponse>(
                p => p.ParticipantOneId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
        IStringMessageTransformer messageTransformer,
        AddChatMessageCommandRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<AddChatMessageCommandRequest, string, AddChatMessageCommandResponse>(
                p => p.ParticipantTwoId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForParticipantOneIdAsync(
        IStringMessageTransformer messageTransformer,
        UpdateChatMessageCommandRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateChatMessageCommandRequest, string, UpdateChatMessageCommandResponse>(
                p => p.ParticipantOneId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
        IStringMessageTransformer messageTransformer,
        UpdateChatMessageCommandRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateChatMessageCommandRequest, string, UpdateChatMessageCommandResponse>(
                p => p.ParticipantTwoId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForParticipantOneIdAsync(
            IStringMessageTransformer messageTransformer,
            DeleteChatMessageCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync(
                p => p.ParticipantOneId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
            IStringMessageTransformer messageTransformer,
            DeleteChatMessageCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync(
                p => p.ParticipantTwoId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
            IStringMessageTransformer messageTransformer,
            GetChatMessageByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetChatMessageByIdQueryRequest, string, GetChatMessageByIdQueryResponse>(
                p => p.ParticipantTwoId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
            IStringMessageTransformer messageTransformer,
            GetAllChatMessagesQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllChatMessagesQueryRequest, string, GetAllChatMessagesQueryResponse>(
                p => p.ParticipantTwoId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForMessageIdAsync(
            IStringMessageTransformer messageTransformer,
            UpdateChatMessageCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateChatMessageCommandRequest, string, UpdateChatMessageCommandResponse>(
                p => p.MessageId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForMessageIdAsync(
            IStringMessageTransformer messageTransformer,
            DeleteChatMessageCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync(
                p => p.MessageId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForMessageIdAsync(
            IStringMessageTransformer messageTransformer,
            GetChatMessageByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetChatMessageByIdQueryRequest, string, GetChatMessageByIdQueryResponse>(
                p => p.MessageId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForContentAsync(
            IStringMessageTransformer messageTransformer,
            AddChatMessageCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<AddChatMessageCommandRequest, string, AddChatMessageCommandResponse>(
                p => p.Content,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForContentAsync(
            IStringMessageTransformer messageTransformer,
            UpdateChatMessageCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateChatMessageCommandRequest, string, UpdateChatMessageCommandResponse>(
                p => p.Content,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
            IStringMessageTransformer messageTransformer,
            GetChatMessageByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetChatMessageByIdQueryRequest, string, GetChatMessageByIdQueryResponse>(
                p => p.CurrentUserId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
            IStringMessageTransformer messageTransformer,
            GetAllChatMessagesQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllChatMessagesQueryRequest, string, GetAllChatMessagesQueryResponse>(
                p => p.CurrentUserId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
            IIntMessageTransformer messageTransformer,
            GetAllChatMessagesQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllChatMessagesQueryRequest, int, GetAllChatMessagesQueryResponse>(
                p => p.Page,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
            IIntMessageTransformer messageTransformer,
            GetAllChatMessagesQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllChatMessagesQueryRequest, int, GetAllChatMessagesQueryResponse>(
                p => p.PageSize,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllChatMessagesQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllChatMessagesQueryRequest, CommonSortOrder, GetAllChatMessagesQueryResponse>(
                p => p.SortOrder,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
            IEnumMessageTransformer<ChatMessagesSortTerm> messageTransformer,
            GetAllChatMessagesQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllChatMessagesQueryRequest, ChatMessagesSortTerm, GetAllChatMessagesQueryResponse>(
                p => p.SortTerm,
                messageTransformer,
                request,
                cancellationToken);
        }
    }
}
