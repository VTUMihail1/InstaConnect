using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenEquals
{
	extension(ForgotPasswordTokenId response)
	{
		public bool Matches(AddForgotPasswordTokenCommand command, ForgotPasswordToken forgotPasswordToken)
		{
			return response.Matches(forgotPasswordToken.Id);
		}
	}

	extension(User user)
	{
		public bool Matches(VerifyForgotPasswordTokenCommand command, IPasswordHasher passwordHasher)
		{
			return passwordHasher.IsMatch(command.Password, user.PasswordHash);
		}
	}

	extension(User? entity)
	{
		public bool Matches(AddForgotPasswordTokenCommand command, UserEventRequest request)
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

		public bool Matches(VerifyForgotPasswordTokenCommand command, UserEventRequest request)
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

	extension(UserInclude p)
	{
		public bool Matches(VerifyForgotPasswordTokenCommand command, UserInclude include)
		{
			return p.Matches(include);
		}
	}

	extension(ForgotPasswordTokenAddedEventRequest request)
	{
		public bool Matches(AddForgotPasswordTokenCommand command, ForgotPasswordToken entity)
		{
			return entity.Id.Matches(request.ForgotPasswordToken.Id, request.ForgotPasswordToken.Value) &&
				   entity.User.Matches(command, request.ForgotPasswordToken.User) &&
				   entity.ExpiresAtUtc == request.ForgotPasswordToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == request.ForgotPasswordToken.CreatedAtUtc;
		}
	}

	extension(ICollection<ForgotPasswordTokenAddedEventRequest> requests)
	{
		public bool Matches(AddForgotPasswordTokenCommand command, ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return requests.MatchesCollection(forgotPasswordTokens,
											  r => new(new(r.ForgotPasswordToken.Id), r.ForgotPasswordToken.Value),
											  f => f.Id,
											  (request, entity) => request.Matches(command, entity));
		}
	}

	extension(ForgotPasswordTokenDeletedEventRequest request)
	{
		public bool Matches(VerifyForgotPasswordTokenCommand command, ForgotPasswordToken entity)
		{
			return entity.Id.Matches(command.Id) &&
				   entity.User.Matches(command, request.ForgotPasswordToken.User) &&
				   entity.ExpiresAtUtc == request.ForgotPasswordToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == request.ForgotPasswordToken.CreatedAtUtc;
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> requests)
	{
		public bool Matches(VerifyForgotPasswordTokenCommand command, ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return requests.MatchesCollection(forgotPasswordTokens,
											  r => new(new(r.ForgotPasswordToken.Id), r.ForgotPasswordToken.Value),
											  f => f.Id,
											  (request, entity) => request.Matches(command, entity));
		}
	}
}
