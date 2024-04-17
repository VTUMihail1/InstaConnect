using InstaConnect.Users.Data.Models.Entities;

namespace InstaConnect.Users.Data.Abstraction.Helpers
{
    /// <summary>
    /// Represents an interface for generating tokens, including access tokens and email confirmation tokens.
    /// </summary>
    public interface ITokenGenerator
    {
        /// <summary>
        /// Generates an access token for the specified user ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A <see cref="Token"/> object representing the generated access token.</returns>
        Token GenerateAccessToken(string userId);

        /// <summary>
        /// Generates an email confirmation token for the specified user ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A <see cref="Token"/> object representing the generated email confirmation token.</returns>
        Token GenerateEmailConfirmationToken(string userId);

        Token GeneratePasswordResetToken(string userId);
    }
}