using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Abstraction.Helpers
{
    /// <summary>
    /// Represents a token manager responsible for generating and managing tokens.
    /// </summary>
    public interface ITokenManager
    {
        /// <summary>
        /// Generates an access token for the specified user ID.
        /// </summary>
        /// <param name="userId">The user ID for which the access token is generated.</param>
        /// <returns>The generated access token as a string.</returns>
        string GenerateAccessToken(string userId);

        /// <summary>
        /// Asynchronously adds an access token for the specified user ID and value.
        /// </summary>
        /// <param name="userId">The user ID associated with the access token.</param>
        /// <param name="value">The value of the access token to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAccessTokenAsync(string userId, string value);

        /// <summary>
        /// Asynchronously adds an email confirmation token for the specified user ID and value.
        /// </summary>
        /// <param name="userId">The user ID associated with the email confirmation token.</param>
        /// <param name="value">The value of the email confirmation token to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddEmailConfirmationTokenAsync(string userId, string value);

        /// <summary>
        /// Asynchronously adds a forgot password token for the specified user ID and value.
        /// </summary>
        /// <param name="userId">The user ID associated with the forgot password token.</param>
        /// <param name="value">The value of the forgot password token to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddForgotPasswordTokenAsync(string userId, string value);

        /// <summary>
        /// Asynchronously retrieves a token by its associated token value.
        /// </summary>
        /// <param name="value">The token value for which to retrieve the token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the token if found; otherwise, it's null.
        /// </returns>
        Task<Token> GetByValueAsync(string value);

        /// <summary>
        /// Asynchronously removes a token by its value.
        /// </summary>
        /// <param name="value">The value of the token to remove.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task RemoveAsync(string value);
    }
}