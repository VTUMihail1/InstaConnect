using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenEquals
{
	extension(EmailConfirmationTokenId response)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command, EmailConfirmationToken emailConfirmationToken)
		{
			return response.Matches(emailConfirmationToken.Id);
		}
	}

	extension(UserInclude p)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommand command, UserInclude include)
		{
			return p.Matches(include);
		}
	}

	extension(User user)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommand command)
		{
			return user.IsEmailConfirmed;
		}
	}

	extension(User? entity)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command, UserEventRequest request)
		{
			return entity != null &&
				   entity.Id.Matches(request.Id) &&
				   command.Name.Matches(request.Name) &&
				   entity.Email.Matches(request.Email) &&
				   entity.FirstName == request.FirstName &&
				   entity.LastName == request.LastName &&
				   entity.ProfileImage.Matches(request.ProfileImageUrl) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.UpdatedAtUtc;
		}

		public bool Matches(VerifyEmailConfirmationTokenCommand command, UserEventRequest request)
		{
			return entity != null &&
				   command.Id.Id.Matches(request.Id) &&
				   entity.Name.Matches(request.Name) &&
				   entity.Email.Matches(request.Email) &&
				   entity.FirstName == request.FirstName &&
				   entity.LastName == request.LastName &&
				   entity.ProfileImage.Matches(request.ProfileImageUrl) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.UpdatedAtUtc;
		}
	}

	extension(EmailConfirmationTokenAddedEventRequest request)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command, EmailConfirmationToken entity)
		{
			return entity.Id.Matches(request.EmailConfirmationToken.Id, request.EmailConfirmationToken.Value) &&
				   entity.User.Matches(command, request.EmailConfirmationToken.User) &&
				   entity.ExpiresAtUtc == request.EmailConfirmationToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == request.EmailConfirmationToken.CreatedAtUtc;
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> requests)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command, ICollection<EmailConfirmationToken> emailConfirmationTokens)
		{
			return requests.MatchesCollection(emailConfirmationTokens,
											  r => new(new(r.EmailConfirmationToken.Id), r.EmailConfirmationToken.Value),
											  f => f.Id,
											  (request, entity) => request.Matches(command, entity));
		}
	}

	extension(EmailConfirmationTokenDeletedEventRequest request)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommand command, EmailConfirmationToken entity)
		{
			return entity.Id.Matches(request.EmailConfirmationToken.Id, request.EmailConfirmationToken.Value) &&
				   entity.User.Matches(command, request.EmailConfirmationToken.User) &&
				   entity.ExpiresAtUtc == request.EmailConfirmationToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == request.EmailConfirmationToken.CreatedAtUtc;
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> requests)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommand command, ICollection<EmailConfirmationToken> emailConfirmationTokens)
		{
			return requests.MatchesCollection(emailConfirmationTokens,
											  r => new(new(r.EmailConfirmationToken.Id), r.EmailConfirmationToken.Value),
											  f => f.Id,
											  (request, entity) => request.Matches(command, entity));
		}
	}
}
