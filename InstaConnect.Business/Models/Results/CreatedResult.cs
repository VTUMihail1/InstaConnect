using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Business.Models.Results
{
    public class CreatedResult<T> : IResult<T>
    {
        public CreatedResult(T data)
        {
            Data = data;
        }

        public InstaConnectStatusCode StatusCode => InstaConnectStatusCode.Created;

        public IEnumerable<string> ErrorMessages => Enumerable.Empty<string>();

        public T Data { get; }
    }
}
