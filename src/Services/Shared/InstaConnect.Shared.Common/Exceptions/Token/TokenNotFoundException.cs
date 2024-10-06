using InstaConnect.Shared.Common.Exceptions.Base;

namespace InstaConnect.Shared.Common.Exceptions.Token;

public class TokenNotFoundException : NotFoundException
{
    private const string ERROR_MESSAGE = "Test does not exist";

    public TokenNotFoundException() : base(ERROR_MESSAGE)
    {
    }
}
