using InstaConnect.Chats.Presentation.Tests.Features.Users.Assertions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Assertions;

public static class ChatProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyParticipantOneNotFound(
		AddChatApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.ParticipantOneId,
				request);
		}

		public void ShouldSatisfyParticipantOneNotFound(
		GetAllChatsApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.CurrentUserId,
				request);
		}

		public void ShouldSatisfyParticipantTwoNotFound(
		AddChatApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.Body.ParticipantTwoId,
				request);
		}

		public void ShouldSatisfyChatNotFound(
			GetChatByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyChatNotFound(
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				request);
		}

		public void ShouldSatisfyChatAlreadyExists(
			AddChatApiRequest request)
		{
			problemDetails.ShouldSatisfyChatAlreadyExists(
				r => r.ParticipantOneId,
				r => r.Body.ParticipantTwoId,
				request);
		}

		internal void ShouldSatisfyChatNotFound<TRequest>(
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyNotFound(
				ChatExceptionErrorMessages.GetNotFoundMessage(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request)))));
		}

		internal void ShouldSatisfyChatAlreadyExists<TRequest>(
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyNotFound(
				ChatExceptionErrorMessages.GetAlreadyExistsMessage(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request)))));
		}
	}
}
