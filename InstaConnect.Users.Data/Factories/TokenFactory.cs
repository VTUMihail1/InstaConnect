using InstaConnect.Users.Data.Abstraction.Factories;
using InstaConnect.Users.Data.Models.Entities;

namespace InstaConnect.Users.Data.Factories
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
