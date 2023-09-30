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
		/// Retrieves a collection of users with pagination based on first name, last name, and paging criteria.
		/// </summary>
		/// <param name="firstName">The first name of the users to search for.</param>
		/// <param name="lastName">The last name of the users to search for.</param>
		/// <param name="page">The page number for pagination.</param>
		/// <param name="amount">The number of users to retrieve per page.</param>
		/// <returns>An <see cref="Task"/> representing the asynchronous operation, containing a collection of <see cref="UserResultDTO"/>.</returns>
		Task<ICollection<UserResultDTO>> GetAllAsync(string firstName, string lastName, int page, int amount);

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

        /// <summary>
        /// Gets personal information of a user by their ID asynchronously.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <param name="id">The ID of the user whose personal information is to be retrieved.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result contains a user's personal information DTO.</returns>
        Task<IResult<UserPersonalResultDTO>> GetPersonalByIdAsync(string currentUserId, string id);
    }
}