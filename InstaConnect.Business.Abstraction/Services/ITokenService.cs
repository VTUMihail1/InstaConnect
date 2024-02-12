using InstaConnect.Business.Models.DTOs.Token;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents an interface for managing and generating tokens for various purposes.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Asynchronously generates an access token for the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the access token is generated.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="TokenResultDTO"/> with the generated access token.</returns>
        Task<IResult<TokenResultDTO>> GenerateAccessTokenAsync(string userId);

        /// <summary>
        /// Asynchronously generates an email confirmation token for the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the email confirmation token is generated.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="TokenResultDTO"/> with the generated email confirmation token.</returns>
        Task<IResult<TokenResultDTO>> GenerateEmailConfirmationTokenAsync(string userId);

        /// <summary>
        /// Asynchronously generates a password reset token for the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the password reset token is generated.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="TokenResultDTO"/> with the generated password reset token.</returns>
        Task<IResult<TokenResultDTO>> GeneratePasswordResetTokenAsync(string userId);

        /// <summary>
        /// Asynchronously retrieves a token by its value.
        /// </summary>
        /// <param name="value">The value of the token to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="TokenResultDTO"/> with the token details.</returns>
        Task<IResult<TokenResultDTO>> GetByValueAsync(string value);

        /// <summary>
        /// Asynchronously deletes a token by its value.
        /// </summary>
        /// <param name="value">The value of the token to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="TokenResultDTO"/> with the result of the token deletion.</returns>
        Task<IResult<TokenResultDTO>> DeleteAsync(string value);
    }
}