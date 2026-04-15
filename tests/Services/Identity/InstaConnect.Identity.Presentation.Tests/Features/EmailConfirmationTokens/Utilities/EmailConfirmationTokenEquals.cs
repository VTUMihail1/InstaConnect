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
}
