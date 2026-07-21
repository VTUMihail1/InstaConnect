using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;


public static class ForgotPasswordTokenEquals
{
	extension(AddForgotPasswordTokenCommandRequest command)
	{
		public bool Matches(AddForgotPasswordTokenApiRequest request)
		{
			return command.Name == request.Name;
		}
	}

	extension(VerifyForgotPasswordTokenCommandRequest command)
	{
		public bool Matches(VerifyForgotPasswordTokenApiRequest request)
		{
			return command.Id == request.Id &&
				   command.Value == request.Value &&
				   command.Password == request.Body.Password &&
				   command.ConfirmPassword == request.Body.ConfirmPassword;
		}
	}

	extension(ForgotPasswordToken forgotPasswordToken)
	{
		public bool Matches(AddForgotPasswordTokenApiRequest request)
		{
			return forgotPasswordToken.User!.Name.Matches(request.Name);
		}

		public bool Matches(VerifyForgotPasswordTokenApiRequest request, IPasswordHasher passwordHasher)
		{
			return forgotPasswordToken.Id.Matches(request.Id, request.Value) &&
				   passwordHasher.IsMatch(request.Body.Password, forgotPasswordToken.User!.PasswordHash) &&
				   request.Body.Password == request.Body.ConfirmPassword;
		}

		public bool MatchesFilter(UpdateCurrentUserApiRequest request)
		{
			return forgotPasswordToken.Id.Id.Matches(request.Id);
		}
	}

	extension(User user)
	{
		public bool Matches(VerifyForgotPasswordTokenApiRequest request, IPasswordHasher passwordHasher)
		{
			return passwordHasher.IsMatch(request.Body.Password, user.PasswordHash);
		}
	}

	extension(User? entity)
	{
		public bool Matches(AddForgotPasswordTokenApiRequest request, UserEventRequest r)
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

		public bool Matches(VerifyForgotPasswordTokenApiRequest request, UserEventRequest r)
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

	extension(ForgotPasswordTokenAddedEventRequest r)
	{
		public bool Matches(AddForgotPasswordTokenApiRequest request, ForgotPasswordToken entity)
		{
			return entity.Id.Matches(r.ForgotPasswordToken.Id, r.ForgotPasswordToken.Value) &&
				   entity.User.Matches(request, r.ForgotPasswordToken.User) &&
				   entity.ExpiresAtUtc == r.ForgotPasswordToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == r.ForgotPasswordToken.CreatedAtUtc;
		}
	}

	extension(ICollection<ForgotPasswordTokenAddedEventRequest> r)
	{
		public bool Matches(AddForgotPasswordTokenApiRequest request, ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return r.MatchesCollection(forgotPasswordTokens,
											  r => new(new(r.ForgotPasswordToken.Id), r.ForgotPasswordToken.Value),
											  f => f.Id,
											  (r, entity) => r.Matches(request, entity));
		}
	}

	extension(ForgotPasswordTokenDeletedEventRequest r)
	{
		public bool Matches(VerifyForgotPasswordTokenApiRequest request, ForgotPasswordToken entity)
		{
			return entity.Id.Matches(request.Id, request.Value) &&
				   entity.User.Matches(request, r.ForgotPasswordToken.User) &&
				   entity.ExpiresAtUtc == r.ForgotPasswordToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == r.ForgotPasswordToken.CreatedAtUtc;
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> r)
	{
		public bool Matches(VerifyForgotPasswordTokenApiRequest request, ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return r.MatchesCollection(forgotPasswordTokens,
											  r => new(new(r.ForgotPasswordToken.Id), r.ForgotPasswordToken.Value),
											  f => f.Id,
											  (r, entity) => r.Matches(request, entity));
		}
	}
}
