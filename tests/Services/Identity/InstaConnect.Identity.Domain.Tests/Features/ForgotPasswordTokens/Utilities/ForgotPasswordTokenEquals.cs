using InstaConnect.Identity.Domain.Features.Common.Helpers;
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

	extension(User user)
	{
		public bool Matches(VerifyForgotPasswordTokenCommand command, IPasswordHasher passwordHasher)
		{
			return passwordHasher.IsMatch(command.Password, user.PasswordHash);
		}

		public void ShouldSatisfy(VerifyForgotPasswordTokenCommand command, IPasswordHasher passwordHasher)
		{
			user.ShouldSatisfy(p => p.Matches(command, passwordHasher));
		}
	}

	extension(ForgotPasswordToken entity)
	{
		public bool Matches(AddForgotPasswordTokenCommand command)
		{
			return entity.User != null && entity.User.Name.Matches(command.Name);
		}
	}

	extension(ForgotPasswordTokenAddedEventRequest request)
	{
		public bool Matches(AddForgotPasswordTokenCommand command, ForgotPasswordToken entity)
		{
			return entity.Matches(request.ForgotPasswordToken) && entity.Matches(command);
		}
	}
}
