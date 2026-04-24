using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyChatNotFound(
            AddChatMessageApiRequest request)
        {
            problemDetails.ShouldSatisfyChatNotFound(
                r => r.ParticipantOneId,
                r => r.ParticipantTwoId,
                request);
        }

        public void ShouldSatisfyChatNotFound(
            UpdateChatMessageApiRequest request)
        {
            problemDetails.ShouldSatisfyChatNotFound(
                r => r.ParticipantOneId,
                r => r.ParticipantTwoId,
                request);
        }

        public void ShouldSatisfyChatNotFound(
            DeleteChatMessageApiRequest request)
        {
            problemDetails.ShouldSatisfyChatNotFound(
                r => r.ParticipantOneId,
                r => r.ParticipantTwoId,
                request);
        }

        public void ShouldSatisfyChatNotFound(
            GetChatMessageByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyChatNotFound(
                r => r.CurrentUserId,
                r => r.ParticipantTwoId,
                request);
        }

        public void ShouldSatisfyChatNotFound(
            GetAllChatMessagesApiRequest request)
        {
            problemDetails.ShouldSatisfyChatNotFound(
                r => r.CurrentUserId,
                r => r.ParticipantTwoId,
                request);
        }

        public void ShouldSatisfyChatMessageNotFound(
            UpdateChatMessageApiRequest request)
        {
            problemDetails.ShouldSatisfyChatMessageNotFound(
                r => r.ParticipantOneId,
                r => r.ParticipantTwoId,
                r => r.MessageId,
                request);
        }

        public void ShouldSatisfyChatMessageNotFound(
            DeleteChatMessageApiRequest request)
        {
            problemDetails.ShouldSatisfyChatMessageNotFound(
                r => r.ParticipantOneId,
                r => r.ParticipantTwoId,
                r => r.MessageId,
                request);
        }

        public void ShouldSatisfyChatMessageNotFound(
            GetChatMessageByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyChatMessageNotFound(
                r => r.CurrentUserId,
                r => r.ParticipantTwoId,
                r => r.MessageId,
                request);
        }

        public void ShouldSatisfyChatMessageForbidden(
            DeleteChatMessageApiRequest request)
        {
            problemDetails.ShouldSatisfyChatMessageForbidden(
                r => r.ParticipantOneId,
                r => r.ParticipantTwoId,
                r => r.MessageId,
                r => r.ParticipantOneId,
                request);
        }

        public void ShouldSatisfyChatMessageForbidden(
            UpdateChatMessageApiRequest request)
        {
            problemDetails.ShouldSatisfyChatMessageForbidden(
                r => r.ParticipantOneId,
                r => r.ParticipantTwoId,
                r => r.MessageId,
                r => r.ParticipantOneId,
                request);
        }

        internal void ShouldSatisfyChatMessageNotFound<TRequest>(
            Func<TRequest, string> participantOneIdPropertyExpression,
            Func<TRequest, string> participantTwoIdPropertyExpression,
            Func<TRequest, string> messageIdPropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyNotFound(ChatMessageExceptionErrorMessages.GetNotFoundMessage(new(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request))), messageIdPropertyExpression(request))));
        }

        internal void ShouldSatisfyChatMessageForbidden<TRequest>(
            Func<TRequest, string> participantOneIdPropertyExpression,
            Func<TRequest, string> participantTwoIdPropertyExpression,
            Func<TRequest, string> messageIdPropertyExpression,
            Func<TRequest, string> senderIdPropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyForbidden(ChatMessageExceptionErrorMessages.GetForbiddenMessage(new(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request))), messageIdPropertyExpression(request)), new(senderIdPropertyExpression(request))));
        }
    }
}
