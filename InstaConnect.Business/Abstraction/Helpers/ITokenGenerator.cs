namespace InstaConnect.Business.Abstraction.Helpers
{
    /// <summary>
    /// Represents an interface for generating token values for various purposes.
    /// </summary>
    public interface ITokenGenerator
    {
        /// <summary>
        /// Generates an access token value for the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the access token value is generated.</param>
        /// <returns>A string containing the generated access token value.</returns>
        string GenerateAccessTokenValue(string userId);

        /// <summary>
        /// Generates an email confirmation token value for the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the email confirmation token value is generated.</param>
        /// <returns>A string containing the generated email confirmation token value.</returns>
        string GenerateEmailConfirmationTokenValue(string userId);

        /// <summary>
        /// Generates a password reset token value for the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the password reset token value is generated.</param>
        /// <returns>A string containing the generated password reset token value.</returns>
        string GeneratePasswordResetToken(string userId);
    }
}