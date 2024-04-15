using EGames.Common.Exceptions.Token.Base;
using InstaConnect.Shared.Models.Enum;

namespace EGames.Common.Exceptions.Token
{
    public class TokenNotFoundException : TokenException
    {
        private const string ERROR_MESSAGE = "Test does not exist";

        public TokenNotFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}
