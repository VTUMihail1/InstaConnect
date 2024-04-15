using InstaConnect.Data.Abstraction.Factories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Models.Options;
using InstaConnect.Data.Models.Utilities;
using Microsoft.Extensions.Options;

namespace InstaConnect.Data.Factories
{
    internal class TokenFactory : ITokenFactory
    {
        public Token GetTokenToken(string userId, string value, string type, int validUntil)
        {
            return new Token()
            {
                UserId = userId,
                Value = value,
                Type = type,
                ValidUntil = DateTime.Now.AddSeconds(validUntil)
            };
        }
    }
}
