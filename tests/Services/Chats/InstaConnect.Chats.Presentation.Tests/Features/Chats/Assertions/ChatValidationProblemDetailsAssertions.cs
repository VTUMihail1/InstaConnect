using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Assertions;

public static class ChatValidationProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyInvalidValidationForParticipantTwoId(
            IStringMessageTransformer messageTransformer,
            GetChatByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.ParticipantTwoId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForParticipantOneId(
            IStringMessageTransformer messageTransformer,
            AddChatApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.ParticipantOneId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForParticipantTwoId(
            IStringMessageTransformer messageTransformer,
            AddChatApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Body.ParticipantTwoId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetChatByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllChatsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForParticipantTwoName(
            IStringMessageTransformer messageTransformer,
            GetAllChatsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.ParticipantTwoName,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPage(
            IIntMessageTransformer messageTransformer,
            GetAllChatsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Page,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllChatsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.PageSize,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllChatsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortOrder,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortTerm(
            IEnumMessageTransformer<ChatsSortTerm> messageTransformer,
            GetAllChatsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortTerm,
                messageTransformer,
                request);
        }
    }
}
