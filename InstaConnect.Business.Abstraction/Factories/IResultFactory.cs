using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Factories
{
    /// <summary>
    /// Represents a factory for creating different types of results.
    /// </summary>
    public interface IResultFactory
    {
        IResult<T> GetNotFoundResult<T>(params string[] errorMessages);
        IResult<T> GetNoContentResult<T>();
        IResult<T> GetOkResult<T>(T data = default);
        IResult<T> GetCreatedResult<T>(T data = default);
        IResult<T> GetBadRequestResult<T>(params string[] errorMessages);
        IResult<T> GetUnauthorizedResult<T>(params string[] errorMessages);
        IResult<T> GetForbiddenResult<T>(params string[] errorMessages);
    }
}
