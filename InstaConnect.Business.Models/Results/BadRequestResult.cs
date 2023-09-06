using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Business.Models.Results
{
    public class BadRequestResult<T> : IResult<T>
    {
        public BadRequestResult(params string[] errorMessages)
        {
            ErrorMessages = errorMessages ?? Enumerable.Empty<string>();
        }

        public InstaConnectStatusCode StatusCode => InstaConnectStatusCode.BadRequest;

        public IEnumerable<string> ErrorMessages { get; set; }
        public T Data { get; }
    }
}
