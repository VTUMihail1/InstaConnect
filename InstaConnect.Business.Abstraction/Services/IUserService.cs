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
        /// Gets a collection of users asynchronously based on their first and last names.
        /// </summary>
        /// <param name="firstName">The first name of the users to retrieve.</param>
        /// <param name="lastName">The last name of the users to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result contains a collection of user DTOs.</returns>
        Task<ICollection<UserResultDTO>> GetAllAsync(string firstName, string lastName);

        /// <summary>
        /// Gets a user by their username asynchronously.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result contains a user DTO.</returns>
        Task<IResult<UserResultDTO>> GetByIdAsync(string username);

        /// <summary>
        /// Gets a user by their username asynchronously.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result contains a user DTO.</returns>
        Task<IResult<UserResultDTO>> GetByUsernameAsync(string username);
    }
}