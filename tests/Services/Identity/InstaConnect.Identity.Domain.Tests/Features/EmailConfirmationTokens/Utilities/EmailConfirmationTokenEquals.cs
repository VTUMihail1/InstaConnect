using InstaConnect.Common.Domain.Features.Common.Extensions;
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

	extension(EmailConfirmationTokenEventRequest request)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command, EmailConfirmationToken? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   request.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   request.User.Matches(command, entity.User) &&
				   request.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(VerifyEmailConfirmationTokenCommand command, EmailConfirmationToken? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   request.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   request.User.Matches(command, entity.User) &&
				   request.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserEventRequest request)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(entity.Id.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(command.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImage?.Url &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(VerifyEmailConfirmationTokenCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImage?.Url &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(EmailConfirmationTokenAddedEventRequest request)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command, EmailConfirmationToken entity)
		{
			return request.EmailConfirmationToken.Matches(command, entity);
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
			return request.EmailConfirmationToken.Matches(command, entity);
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
