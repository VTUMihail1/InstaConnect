using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMatchAssertions
{
    extension(ICollection<EmailConfirmationToken> emailConfirmationTokens)
    {
        public void ShouldSatisfy(ICollection<EmailConfirmationToken> e)
        {
            emailConfirmationTokens.ShouldSatisfy(p => p.Matches(e));
        }
    }
}
