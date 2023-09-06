using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Factories
{
    /// <summary>
    /// Represents a factory for creating different types of results.
    /// </summary>
    public interface IResultFactory
    {
        /// <summary>
        /// Gets a NotFound result with error messages.
        /// </summary>
        /// <typeparam name="T">The type of data to be returned in the result.</typeparam>
        /// <param name="errorMessages">An optional array of error messages associated with the NotFound result.</param>
        /// <returns>A result representing a NotFound status with the specified error messages.</returns>
        IResult<T> GetNotFoundResult<T>(params string[] errorMessages);

        /// <summary>
        /// Gets a NoContent result with no data.
        /// </summary>
        /// <typeparam name="T">The type of data to be returned in the result.</typeparam>
        /// <returns>A result representing a NoContent status with no data.</returns>
        IResult<T> GetNoContentResult<T>();

        /// <summary>
        /// Gets an Ok result with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of data to be returned in the result.</typeparam>
        /// <param name="data">The data to be included in the Ok result.</param>
        /// <returns>A result representing an Ok status with the specified data.</returns>
        IResult<T> GetOkResult<T>(T data = default);

        /// <summary>
        /// Gets a Created result with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of data to be returned in the result.</typeparam>
        /// <param name="data">The data to be included in the Created result.</param>
        /// <returns>A result representing a Created status with the specified data.</returns>
        IResult<T> GetCreatedResult<T>(T data = default);

        /// <summary>
        /// Gets a BadRequest result with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of data to be returned in the result.</typeparam>
        /// <param name="errorMessages">An optional array of error messages associated with the BadRequest result.</param>
        /// <returns>A result representing a BadRequest status with the specified error messages.</returns>
        IResult<T> GetBadRequestResult<T>(params string[] errorMessages);

        /// <summary>
        /// Gets a Unauthorized result with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of data to be returned in the result.</typeparam>
        /// <param name="errorMessages">An optional array of error messages associated with the Unauthorized result.</param>
        /// <returns>A result representing a Unauthorized status with the specified error messages.</returns>
        IResult<T> GetUnauthorizedResult<T>(params string[] errorMessages);
    }
}
