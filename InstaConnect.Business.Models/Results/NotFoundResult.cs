using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Business.Models.Results
{
    public class NotFoundResult<T> : IResult<T>
    {
        public NotFoundResult(params string[] errorMessages)
        {
            ErrorMessages = errorMessages ?? Enumerable.Empty<string>();
        }

        public InstaConnectStatusCode StatusCode => InstaConnectStatusCode.NotFound;

        public IEnumerable<string> ErrorMessages { get; set; }
        public T Data { get; }
    }
}
