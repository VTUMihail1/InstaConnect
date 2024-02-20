using InstaConnect.Business.Models.DTOs.User;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents an interface for managing and retrieving user information.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Asynchronously retrieves a collection of users based on their first name and last name, with pagination support.
        /// </summary>
        /// <param name="firstName">The first name of the users to filter by (can be empty or null to skip this filter).</param>
        /// <param name="lastName">The last name of the users to filter by (can be empty or null to skip this filter).</param>
        /// <param name="page">The page number for paginating results.</param>
        /// <param name="amount">The number of users to retrieve per page.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="ICollection{UserResultDTO}"/> with the filtered users.</returns>
        Task<IResult<ICollection<UserResultDTO>>> GetAllAsync(string firstName, string lastName, int page, int amount);

        /// <summary>
        /// Asynchronously retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="UserResultDTO"/> with the user details.</returns>
        Task<IResult<UserResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Asynchronously retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="UserResultDTO"/> with the user details.</returns>
        Task<IResult<UserResultDTO>> GetByUsernameAsync(string username);

        /// <summary>
        /// Asynchronously retrieves personal information about a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to retrieve personal information for.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="UserPersonalResultDTO"/> with the user's personal information.</returns>
        Task<IResult<UserPersonalResultDTO>> GetPersonalByIdAsync(string id);
    }
}