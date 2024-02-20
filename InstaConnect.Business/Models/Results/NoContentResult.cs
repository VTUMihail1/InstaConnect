using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Business.Models.Results
{
    public class NoContentResult<T> : IResult<T>
    {
        public InstaConnectStatusCode StatusCode => InstaConnectStatusCode.NoContent;

        public IEnumerable<string> ErrorMessages => Enumerable.Empty<string>();

        public T Data { get; }
    }
}
