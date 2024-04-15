using InstaConnect.Business.Models.Exceptions.Base;
using InstaConnect.Shared.Models.Enum;

namespace EGames.Common.Exceptions.EntityOrder.Base
{
    public class EntityOrderException : BaseException
    {
        public EntityOrderException(string message, InstaConnectStatusCode statusCode) : base(message, statusCode)
        {

        }

        public EntityOrderException(string message, Exception exception, InstaConnectStatusCode statusCode)
            : base(message, exception, statusCode)
        {
        }
    }
}
