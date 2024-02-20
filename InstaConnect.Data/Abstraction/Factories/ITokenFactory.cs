using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Abstraction.Factories
{
    /// <summary>
    /// Represents a factory for generating various types of tokens.
    /// </summary>
    public interface ITokenFactory
    {
        /// <summary>
        /// Generates an access token for the specified user ID and value.
        /// </summary>
        /// <param name="userId">The user ID for which the access token is generated.</param>
        /// <param name="value">The value associated with the access token.</param>
        /// <returns>The generated access token.</returns>
        Token GetAccessToken(string userId, string value);

        /// <summary>
        /// Generates a confirmation email token for the specified user ID and value.
        /// </summary>
        /// <param name="userId">The user ID for which the confirmation email token is generated.</param>
        /// <param name="value">The value associated with the confirmation email token.</param>
        /// <returns>The generated confirmation email token.</returns>
        Token GetConfirmEmailToken(string userId, string value);

        /// <summary>
        /// Generates a forgot password token for the specified user ID and value.
        /// </summary>
        /// <param name="userId">The user ID for which the forgot password token is generated.</param>
        /// <param name="value">The value associated with the forgot password token.</param>
        /// <returns>The generated forgot password token.</returns>
        Token GetForgotPasswordToken(string userId, string value);
    }
}