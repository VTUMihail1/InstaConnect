using InstaConnect.Common.Domain.Features.Common.Extensions;
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

	extension(EmailConfirmationTokenEventRequest r)
	{
		public bool Matches(AddEmailConfirmationTokenApiRequest request, EmailConfirmationToken? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   r.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   r.User.Matches(request, entity.User) &&
				   r.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(VerifyEmailConfirmationTokenApiRequest request, EmailConfirmationToken? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.Value.EqualsOrdinalIgnoreCase(request.Value) &&
				   r.User.Matches(request, entity.User) &&
				   r.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserEventRequest r)
	{
		public bool Matches(AddEmailConfirmationTokenApiRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id) &&
				   r.Name.EqualsOrdinalIgnoreCase(request.Name) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   (entity.ProfileImage == null || r.ProfileImageUrl == entity.ProfileImage.Url) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(VerifyEmailConfirmationTokenApiRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   (entity.ProfileImage == null || r.ProfileImageUrl == entity.ProfileImage.Url) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(EmailConfirmationTokenAddedEventRequest r)
	{
		public bool Matches(AddEmailConfirmationTokenApiRequest request, EmailConfirmationToken entity)
		{
			return r.EmailConfirmationToken.Matches(request, entity);
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
			return r.EmailConfirmationToken.Matches(request, entity);
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
