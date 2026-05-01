using InstaConnect.Identity.Domain.Features.Common.Helpers;
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
}
