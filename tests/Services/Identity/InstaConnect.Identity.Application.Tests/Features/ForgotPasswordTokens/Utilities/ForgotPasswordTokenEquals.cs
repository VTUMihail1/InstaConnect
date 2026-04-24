using InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Domain.Features.Common.Helpers;

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
}
