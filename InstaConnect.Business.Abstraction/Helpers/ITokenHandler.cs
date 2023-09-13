using InstaConnect.Business.Models.DTOs.Token;

namespace InstaConnect.Business.Abstraction.Helpers
{
    /// <summary>
    /// Represents an interface for handling token-related operations such as generating access tokens, email confirmation tokens, and forgot password tokens.
    /// </summary>
    public interface ITokenHandler
    {
        /// <summary>
        /// Generates an access token for the specified user.
        /// </summary>
        /// <param name="userId">The user's unique identifier.</param>
        /// <returns>An instance of <see cref="TokenAddDTO"/> representing the generated access token.</returns>
        TokenAddDTO GenerateAccessToken(string userId);

        /// <summary>
        /// Generates an email confirmation token based on the provided <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value for the email confirmation token.</param>
        /// <returns>An instance of <see cref="TokenAddDTO"/> representing the generated email confirmation token.</returns>
        TokenAddDTO GenerateEmailConfirmationToken(string value);

        /// <summary>
        /// Generates a forgot password token based on the provided <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value for the forgot password token.</param>
        /// <returns>An instance of <see cref="TokenAddDTO"/> representing the generated forgot password token.</returns>
        TokenAddDTO GenerateForgotPasswordToken(string value);
    }
}