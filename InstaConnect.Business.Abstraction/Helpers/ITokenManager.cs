using InstaConnect.Business.Models.DTOs.Token;

namespace InstaConnect.Data.Abstraction.Helpers
{
    /// <summary>
    /// Provides methods for managing tokens related to user authentication and authorization.
    /// </summary>
    public interface ITokenManager
    {
        /// <summary>
        /// Generates an access token for the specified user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is a TokenResultDTO containing the generated access token.</returns>
        Task<TokenResultDTO> GenerateAccessToken(string userId);

        /// <summary>
        /// Generates a confirmation token for email verification for the specified user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is a TokenResultDTO containing the generated email confirmation token.</returns>
        Task<TokenResultDTO> GenerateEmailConfirmationTokenAsync(string userId);

        /// <summary>
        /// Generates a token for resetting a user's password.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is a TokenResultDTO containing the generated password reset token.</returns>
        Task<TokenResultDTO> GeneratePasswordResetToken(string userId);

        /// <summary>
        /// Retrieves a token by its value asynchronously.
        /// </summary>
        /// <param name="value">The value of the token to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is a TokenResultDTO containing the retrieved token or null if the token is not found.</returns>
        Task<TokenResultDTO> GetByValueAsync(string value);

        /// <summary>
        /// Removes a token asynchronously based on its value.
        /// </summary>
        /// <param name="value">The value of the token to remove.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the removal was successful (true) or not (false).</returns>
        Task<bool> RemoveAsync(string value);
    }
}