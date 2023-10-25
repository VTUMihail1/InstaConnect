using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Abstraction.Helpers
{
    public interface ITokenManager
    {
        Task<Token> GenerateAccessToken(string userId);

        Task<Token> GenerateEmailConfirmationToken(string userId);

        Task<Token> GeneratePasswordResetToken(string userId);

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