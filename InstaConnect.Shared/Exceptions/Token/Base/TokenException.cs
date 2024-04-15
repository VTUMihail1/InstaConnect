using InstaConnect.Shared.Exceptions.Base;
using InstaConnect.Shared.Models.Enum;

namespace EGames.Common.Exceptions.Token.Base
{
    public class TokenException : BaseException
    {
        public TokenException(string message, InstaConnectStatusCode statusCode) : base(message, statusCode)
        {
        }

        public TokenException(string message, Exception exception, InstaConnectStatusCode statusCode)
            : base(message, exception, statusCode)
        {
        }
    }
}
