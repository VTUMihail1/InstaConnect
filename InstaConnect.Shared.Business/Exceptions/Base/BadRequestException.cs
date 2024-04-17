using InstaConnect.Shared.Business.Enum;

namespace InstaConnect.Shared.Business.Exceptions.Base
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message, InstaConnectStatusCode.BadRequest)
        {
        }

        public BadRequestException(string message, Exception exception) : base(message, exception, InstaConnectStatusCode.BadRequest)
        {
        }
    }
}
