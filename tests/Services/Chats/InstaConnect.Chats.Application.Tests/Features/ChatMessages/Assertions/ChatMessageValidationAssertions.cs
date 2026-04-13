namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageValidationAssertions
{
    extension(TestValidationResult<AddChatMessageCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForParticipantOneId(IStringMessageTransformer messageTransformer, AddChatMessageCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ParticipantOneId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForParticipantTwoId(IStringMessageTransformer messageTransformer, AddChatMessageCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ParticipantTwoId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForContent(IStringMessageTransformer messageTransformer, AddChatMessageCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Content, messageTransformer, request);
        }
    }

    extension(TestValidationResult<UpdateChatMessageCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForParticipantOneId(IStringMessageTransformer messageTransformer, UpdateChatMessageCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ParticipantOneId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForParticipantTwoId(IStringMessageTransformer messageTransformer, UpdateChatMessageCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ParticipantTwoId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForMessageId(IStringMessageTransformer messageTransformer, UpdateChatMessageCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.MessageId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForContent(IStringMessageTransformer messageTransformer, UpdateChatMessageCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Content, messageTransformer, request);
        }
    }

    extension(TestValidationResult<DeleteChatMessageCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForParticipantOneId(IStringMessageTransformer messageTransformer, DeleteChatMessageCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ParticipantOneId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForParticipantTwoId(IStringMessageTransformer messageTransformer, DeleteChatMessageCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ParticipantTwoId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForMessageId(IStringMessageTransformer messageTransformer, DeleteChatMessageCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.MessageId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetChatMessageByIdQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForParticipantTwoId(IStringMessageTransformer messageTransformer, GetChatMessageByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ParticipantTwoId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForMessageId(IStringMessageTransformer messageTransformer, GetChatMessageByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.MessageId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentUserId(IStringMessageTransformer messageTransformer, GetChatMessageByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
        }
    }


    extension(TestValidationResult<GetAllChatMessagesQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForParticipantTwoId(IStringMessageTransformer messageTransformer, GetAllChatMessagesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ParticipantTwoId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentUserId(IStringMessageTransformer messageTransformer, GetAllChatMessagesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPage(IIntMessageTransformer messageTransformer, GetAllChatMessagesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPageSize(IIntMessageTransformer messageTransformer, GetAllChatMessagesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortOrder(IEnumMessageTransformer<CommonSortOrder> messageTransformer, GetAllChatMessagesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortTerm(IEnumMessageTransformer<ChatMessagesSortTerm> messageTransformer, GetAllChatMessagesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
        }
    }
}
