using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Business.Models.Results
{
    public class OkResult<T> : IResult<T>
    {
        public OkResult(T data)
        {
            Data = data;
        }

        public InstaConnectStatusCode StatusCode => InstaConnectStatusCode.OK;

        public IEnumerable<string> ErrorMessages => Enumerable.Empty<string>();

        public T Data { get; }
    }
}
