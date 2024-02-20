using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Business.Models.Results
{
    public class UnauthorizedResult<T> : IResult<T>
    {
        public UnauthorizedResult(params string[] errorMessages)
        {
            ErrorMessages = errorMessages ?? Enumerable.Empty<string>();
        }

        public InstaConnectStatusCode StatusCode => InstaConnectStatusCode.Unauthorized;

        public IEnumerable<string> ErrorMessages { get; set; }

        public T Data { get; }
    }
}
