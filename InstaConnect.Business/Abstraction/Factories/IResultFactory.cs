using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Factories
{
    /// <summary>
    /// Represents a factory for creating various types of results.
    /// </summary>
    public interface IResultFactory
    {
        /// <summary>
        /// Gets a "Not Found" result with optional error messages.
        /// </summary>
        /// <typeparam name="T">The type of data associated with the result.</typeparam>
        /// <param name="errorMessages">Optional error messages.</param>
        /// <returns>An <see cref="IResult{T}"/> representing a "Not Found" result.</returns>
        IResult<T> GetNotFoundResult<T>(params string[] errorMessages);

        /// <summary>
        /// Gets a "No Content" result.
        /// </summary>
        /// <typeparam name="T">The type of data associated with the result.</typeparam>
        /// <returns>An <see cref="IResult{T}"/> representing a "No Content" result.</returns>
        IResult<T> GetNoContentResult<T>();

        /// <summary>
        /// Gets an "OK" result with optional data.
        /// </summary>
        /// <typeparam name="T">The type of data associated with the result.</typeparam>
        /// <param name="data">Optional data to include in the result.</param>
        /// <returns>An <see cref="IResult{T}"/> representing an "OK" result.</returns>
        IResult<T> GetOkResult<T>(T data = default);

        /// <summary>
        /// Gets a "Created" result with optional data.
        /// </summary>
        /// <typeparam name="T">The type of data associated with the result.</typeparam>
        /// <param name="data">Optional data to include in the result.</param>
        /// <returns>An <see cref="IResult{T}"/> representing a "Created" result.</returns>
        IResult<T> GetCreatedResult<T>(T data = default);

        /// <summary>
        /// Gets a "Bad Request" result with optional error messages.
        /// </summary>
        /// <typeparam name="T">The type of data associated with the result.</typeparam>
        /// <param name="errorMessages">Optional error messages.</param>
        /// <returns>An <see cref="IResult{T}"/> representing a "Bad Request" result.</returns>
        IResult<T> GetBadRequestResult<T>(params string[] errorMessages);

        /// <summary>
        /// Gets an "Unauthorized" result with optional error messages.
        /// </summary>
        /// <typeparam name="T">The type of data associated with the result.</typeparam>
        /// <param name="errorMessages">Optional error messages.</param>
        /// <returns>An <see cref="IResult{T}"/> representing an "Unauthorized" result.</returns>
        IResult<T> GetUnauthorizedResult<T>(params string[] errorMessages);

        /// <summary>
        /// Gets a "Forbidden" result with optional error messages.
        /// </summary>
        /// <typeparam name="T">The type of data associated with the result.</typeparam>
        /// <param name="errorMessages">Optional error messages.</param>
        /// <returns>An <see cref="IResult{T}"/> representing a "Forbidden" result.</returns>
        IResult<T> GetForbiddenResult<T>(params string[] errorMessages);
    }
}
