using InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenEquals
{
	extension(AddForgotPasswordTokenCommand command)
	{
		public bool Matches(AddForgotPasswordTokenCommandRequest request)
		{
			return command.Name.Matches(request.Name);
		}
	}

	extension(VerifyForgotPasswordTokenCommand command)
	{
		public bool Matches(VerifyForgotPasswordTokenCommandRequest request)
		{
			return command.Id.Matches(request.Id, request.Value) &&
				   command.Password == request.Password &&
				   command.ConfirmPassword == request.ConfirmPassword;
		}
	}

	extension(ForgotPasswordToken forgotPasswordToken)
	{
		public bool Matches(AddForgotPasswordTokenCommandRequest request)
		{
			return forgotPasswordToken.User!.Name.Matches(request.Name);
		}

		public bool Matches(VerifyForgotPasswordTokenCommandRequest request, IPasswordHasher passwordHasher)
		{
			return forgotPasswordToken.Id.Matches(request.Id, request.Value) &&
				   passwordHasher.IsMatch(request.Password, forgotPasswordToken.User!.PasswordHash) &&
				   request.Password == request.ConfirmPassword;
		}
	}

	extension(User user)
	{
		public bool Matches(VerifyForgotPasswordTokenCommandRequest request, IPasswordHasher passwordHasher)
		{
			return passwordHasher.IsMatch(request.Password, user.PasswordHash);
		}
	}

	extension(User? entity)
	{
		public bool Matches(AddForgotPasswordTokenCommandRequest request, UserEventRequest r)
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

		public bool Matches(VerifyForgotPasswordTokenCommandRequest request, UserEventRequest r)
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
		public bool Matches(AddForgotPasswordTokenCommandRequest request, ForgotPasswordToken entity)
		{
			return entity.Id.Matches(r.ForgotPasswordToken.Id, r.ForgotPasswordToken.Value) &&
				   entity.User.Matches(request, r.ForgotPasswordToken.User) &&
				   entity.ExpiresAtUtc == r.ForgotPasswordToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == r.ForgotPasswordToken.CreatedAtUtc;
		}
	}

	extension(ICollection<ForgotPasswordTokenAddedEventRequest> r)
	{
		public bool Matches(AddForgotPasswordTokenCommandRequest request, ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return r.MatchesCollection(forgotPasswordTokens,
											  r => new(new(r.ForgotPasswordToken.Id), r.ForgotPasswordToken.Value),
											  f => f.Id,
											  (r, entity) => r.Matches(request, entity));
		}
	}

	extension(ForgotPasswordTokenDeletedEventRequest r)
	{
		public bool Matches(VerifyForgotPasswordTokenCommandRequest request, ForgotPasswordToken entity)
		{
			return entity.Id.Matches(request.Id, request.Value) &&
				   entity.User.Matches(request, r.ForgotPasswordToken.User) &&
				   entity.ExpiresAtUtc == r.ForgotPasswordToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == r.ForgotPasswordToken.CreatedAtUtc;
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> r)
	{
		public bool Matches(VerifyForgotPasswordTokenCommandRequest request, ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return r.MatchesCollection(forgotPasswordTokens,
											  r => new(new(r.ForgotPasswordToken.Id), r.ForgotPasswordToken.Value),
											  f => f.Id,
											  (r, entity) => r.Matches(request, entity));
		}
	}
}
