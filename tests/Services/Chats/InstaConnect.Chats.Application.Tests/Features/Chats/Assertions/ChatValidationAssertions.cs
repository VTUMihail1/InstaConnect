using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatValidationAssertions
{
    extension(TestValidationResult<GetChatByIdQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForParticipantTwoId(
        IStringMessageTransformer messageTransformer,
        GetChatByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ParticipantTwoId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetChatByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<AddChatCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForParticipantOneId(
        IStringMessageTransformer messageTransformer,
        AddChatCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ParticipantOneId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForParticipantTwoId(
        IStringMessageTransformer messageTransformer,
        AddChatCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ParticipantTwoId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetAllChatsQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForParticipantTwoName(
            IStringMessageTransformer messageTransformer,
            GetAllChatsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ParticipantTwoName, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllChatsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPage(
            IIntMessageTransformer messageTransformer,
            GetAllChatsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllChatsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllChatsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortTerm(
            IEnumMessageTransformer<ChatsSortTerm> messageTransformer,
            GetAllChatsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
        }
    }
}
