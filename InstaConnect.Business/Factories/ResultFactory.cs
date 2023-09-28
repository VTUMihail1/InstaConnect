using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Factories
{
    public class ResultFactory : IResultFactory
    {
        public IResult<T> GetOkResult<T>(T data = default)
        {
            return new OkResult<T>(data);
        }

        public IResult<T> GetNotFoundResult<T>(params string[] errorMessages)
        {
            return new NotFoundResult<T>(errorMessages);
        }

        public IResult<T> GetNoContentResult<T>()
        {
            return new NoContentResult<T>();
        }

        public IResult<T> GetCreatedResult<T>(T data = default)
        {
            return new CreatedResult<T>(data);
        }

        public IResult<T> GetBadRequestResult<T>(params string[] errorMessages)
        {
            return new BadRequestResult<T>(errorMessages);
        }

        public IResult<T> GetUnauthorizedResult<T>(params string[] errorMessages)
        {
            return new UnauthorizedResult<T>(errorMessages);
        }

        public IResult<T> GetForbiddenResult<T>(params string[] errorMessages)
        {
            return new ForbiddenResult<T>(errorMessages);
        }
    }
}
