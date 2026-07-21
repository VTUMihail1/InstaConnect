using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;


public static class EmailConfirmationTokenEquals
{
	extension(AddEmailConfirmationTokenCommandRequest command)
	{
		public bool Matches(AddEmailConfirmationTokenApiRequest request)
		{
			return command.Name == request.Name;
		}
	}

	extension(VerifyEmailConfirmationTokenCommandRequest command)
	{
		public bool Matches(VerifyEmailConfirmationTokenApiRequest request)
		{
			return command.Id == request.Id &&
				   command.Value == request.Value;
		}
	}

	extension(EmailConfirmationToken emailConfirmationToken)
	{
		public bool Matches(AddEmailConfirmationTokenApiRequest request)
		{
			return emailConfirmationToken.User!.Name.Matches(request.Name);
		}

		public bool Matches(VerifyEmailConfirmationTokenApiRequest request)
		{
			return emailConfirmationToken.Id.Matches(request.Id, request.Value);
		}
	}

	extension(User user)
	{
		public bool Matches(VerifyEmailConfirmationTokenApiRequest request)
		{
			return user.IsEmailConfirmed;
		}
	}

	extension(User? entity)
	{
		public bool Matches(AddEmailConfirmationTokenApiRequest request, UserEventRequest r)
		{
			return entity != null &&
				   entity.Id.Matches(r.Id) &&
				   request.Name == r.Name &&
				   entity.Email.Matches(r.Email) &&
				   entity.FirstName == r.FirstName &&
				   entity.LastName == r.LastName &&
				   entity.ProfileImage.Matches(r.ProfileImageUrl) &&
				   entity.CreatedAtUtc == r.CreatedAtUtc &&
				   entity.UpdatedAtUtc == r.UpdatedAtUtc;
		}

		public bool Matches(VerifyEmailConfirmationTokenApiRequest request, UserEventRequest r)
		{
			return entity != null &&
				   request.Id == r.Id &&
				   entity.Name.Matches(r.Name) &&
				   entity.Email.Matches(r.Email) &&
				   entity.FirstName == r.FirstName &&
				   entity.LastName == r.LastName &&
				   entity.ProfileImage.Matches(r.ProfileImageUrl) &&
				   entity.CreatedAtUtc == r.CreatedAtUtc &&
				   entity.UpdatedAtUtc == r.UpdatedAtUtc;
		}
	}

	extension(EmailConfirmationTokenAddedEventRequest r)
	{
		public bool Matches(AddEmailConfirmationTokenApiRequest request, EmailConfirmationToken entity)
		{
			return entity.Id.Matches(r.EmailConfirmationToken.Id, r.EmailConfirmationToken.Value) &&
				   entity.User.Matches(request, r.EmailConfirmationToken.User) &&
				   entity.ExpiresAtUtc == r.EmailConfirmationToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == r.EmailConfirmationToken.CreatedAtUtc;
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public bool Matches(AddEmailConfirmationTokenApiRequest request, ICollection<EmailConfirmationToken> emailConfirmationTokens)
		{
			return r.MatchesCollection(emailConfirmationTokens,
											  r => new(new(r.EmailConfirmationToken.Id), r.EmailConfirmationToken.Value),
											  f => f.Id,
											  (r, entity) => r.Matches(request, entity));
		}
	}

	extension(EmailConfirmationTokenDeletedEventRequest r)
	{
		public bool Matches(VerifyEmailConfirmationTokenApiRequest request, EmailConfirmationToken entity)
		{
			return entity.Id.Matches(r.EmailConfirmationToken.Id, r.EmailConfirmationToken.Value) &&
				   entity.User.Matches(request, r.EmailConfirmationToken.User) &&
				   entity.ExpiresAtUtc == r.EmailConfirmationToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == r.EmailConfirmationToken.CreatedAtUtc;
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public bool Matches(VerifyEmailConfirmationTokenApiRequest request, ICollection<EmailConfirmationToken> emailConfirmationTokens)
		{
			return r.MatchesCollection(emailConfirmationTokens,
											  r => new(new(r.EmailConfirmationToken.Id), r.EmailConfirmationToken.Value),
											  f => f.Id,
											  (r, entity) => r.Matches(request, entity));
		}
	}
}
