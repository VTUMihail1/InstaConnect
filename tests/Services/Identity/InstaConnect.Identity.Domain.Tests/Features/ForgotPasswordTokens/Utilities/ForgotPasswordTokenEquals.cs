using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenEquals
{
	extension(ForgotPasswordTokenId response)
	{
		public bool Matches(ForgotPasswordToken forgotPasswordToken, AddForgotPasswordTokenCommand command)
		{
			return response.Matches(forgotPasswordToken.Id);
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> requests)
	{
		public bool Matches(User user)
		{
			return requests.MatchesCollection(user.ForgotPasswordTokens,
											  r => new(new(r.ForgotPasswordToken.Id), r.ForgotPasswordToken.Value),
											  f => f.Id,
											  (request, entity) => request.Matches(entity));
		}
	}
}
