using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenEquals
{
	extension(EmailConfirmationTokenId response)
	{
		public bool Matches(EmailConfirmationToken emailConfirmationToken, AddEmailConfirmationTokenCommand command)
		{
			return response.Matches(emailConfirmationToken.Id);
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> requests)
	{
		public bool Matches(User user)
		{
			return requests.MatchesCollection(user.EmailConfirmationTokens,
											  r => new(new(r.EmailConfirmationToken.Id), r.EmailConfirmationToken.Value),
											  f => f.Id,
											  (request, entity) => request.Matches(entity));
		}
	}

	extension(User user)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommand command)
		{
			return user.IsEmailConfirmed;
		}

		public void ShouldSatisfy(VerifyEmailConfirmationTokenCommand command)
		{
			user.ShouldSatisfy(p => p.Matches(command));
		}
	}

	extension(EmailConfirmationToken entity)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command)
		{
			return entity.User != null && entity.User.Name.Matches(command.Name);
		}
	}

	extension(EmailConfirmationTokenAddedEventRequest request)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command, EmailConfirmationToken entity)
		{
			return entity.Matches(request.EmailConfirmationToken) && entity.Matches(command);
		}
	}
}
