using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenEquals
{
    extension(AddEmailConfirmationTokenCommand command)
    {
        public bool Matches(AddEmailConfirmationTokenCommandRequest request)
        {
            return command.Name.Matches(request.Name);
        }
    }

    extension(VerifyEmailConfirmationTokenCommand command)
    {
        public bool Matches(VerifyEmailConfirmationTokenCommandRequest request)
        {
            return command.Id.Matches(request.Id, request.Value);
        }
    }

    extension(EmailConfirmationToken emailConfirmationToken)
    {
        public bool Matches(AddEmailConfirmationTokenCommandRequest request)
        {
            return emailConfirmationToken.User!.Name.Matches(request.Name);
        }

        public bool Matches(VerifyEmailConfirmationTokenCommandRequest request)
        {
            return emailConfirmationToken.Id.Matches(request.Id, request.Value);
        }
    }
}
