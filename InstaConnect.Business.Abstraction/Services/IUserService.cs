using InstaConnect.Business.Models.DTOs.User;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a user service interface.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves all users with pagination support based on first name and last name filters.
        /// </summary>
        /// <param name="firstName">The first name filter.</param>
        /// <param name="lastName">The last name filter.</param>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="amount">The number of users to retrieve per page.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a collection of <see cref="UserResultDTO"/>.</returns>
        Task<IResult<ICollection<UserResultDTO>>> GetAllAsync(string firstName, string lastName, int page, int amount);

        /// <summary>
        /// Retrieves a user by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a <see cref="UserResultDTO"/>.</returns>
        Task<IResult<UserResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Gets a user by their username asynchronously.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result contains a user DTO.</returns>
        Task<IResult<UserResultDTO>> GetByUsernameAsync(string username);

        /// <summary>
        /// Gets personal information of a user by their ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user whose personal information is to be retrieved.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result contains a user's personal information DTO.</returns>
        Task<IResult<UserPersonalResultDTO>> GetPersonalByIdAsync(string id);
    }
}