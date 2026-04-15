namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMapper
{
    extension(EmailConfirmationToken emailConfirmationToken)
    {
        internal EmailConfirmationTokenId ToIdResponse()
        {
            return emailConfirmationToken.Id;
        }

        public EmailConfirmationTokenId ToResponse(
            AddEmailConfirmationTokenCommandRequest request)
        {
            return emailConfirmationToken.ToIdResponse();
        }
    }
}
