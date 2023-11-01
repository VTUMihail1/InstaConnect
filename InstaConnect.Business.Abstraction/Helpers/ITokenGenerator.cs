namespace InstaConnect.Data.Abstraction.Helpers
{
    public interface ITokenGenerator
    {
        string GenerateAccessTokenValue(string userId);

        string GenerateEmailConfirmationTokenValue(string userId);

        string GeneratePasswordResetToken(string userId);
    }
}