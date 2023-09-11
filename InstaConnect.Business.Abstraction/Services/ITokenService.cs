using InstaConnect.Business.Models.DTOs.Token;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents an interface for managing tokens, including email confirmation tokens, access tokens, and password reset tokens.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Adds an email confirmation token asynchronously with the provided <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value for the email confirmation token.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the result of adding the email confirmation token.</returns>
        Task<IResult<TokenResultDTO>> AddEmailConfirmationTokenAsync(string value);

        /// <summary>
        /// Adds an access token asynchronously for the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The user's unique identifier.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the result of adding the access token.</returns>
        Task<IResult<TokenResultDTO>> AddAccessTokenAsync(string userId);

        /// <summary>
        /// Adds a password reset token asynchronously with the provided <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value for the password reset token.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the result of adding the password reset token.</returns>
        Task<IResult<TokenResultDTO>> AddPasswordResetTokenAsync(string value);

        /// <summary>
        /// Retrieves a token by its value asynchronously.
        /// </summary>
        /// <param name="value">The value of the token to retrieve.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the token information if found.</returns>
        Task<IResult<TokenResultDTO>> GetByValueAsync(string value);

        /// <summary>
        /// Removes a token with the specified <paramref name="value"/> asynchronously.
        /// </summary>
        /// <param name="value">The value of the token to remove.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the result of removing the token.</returns>
        Task<IResult<TokenResultDTO>> RemoveAsync(string value);
    }
}