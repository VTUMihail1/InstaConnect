using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.Token
{
    public class TokenNotFoundException : NotFoundException
    {
        private const string ERROR_MESSAGE = "Test does not exist";

        public TokenNotFoundException() : base(ERROR_MESSAGE)
        {
        }
    }
}
