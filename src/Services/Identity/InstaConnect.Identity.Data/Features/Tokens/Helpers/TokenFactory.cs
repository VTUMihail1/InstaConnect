using InstaConnect.Identity.Data.Features.Tokens.Abstractions;
using InstaConnect.Identity.Data.Features.Tokens.Models.Entitites;

namespace InstaConnect.Identity.Data.Features.Tokens.Helpers;

internal class TokenFactory : ITokenFactory
{
    public Token GetTokenToken(string userId, string value, string type, int validUntil)
    {
        return new Token(value, type, DateTime.Now.AddSeconds(validUntil), userId);
    }
}
