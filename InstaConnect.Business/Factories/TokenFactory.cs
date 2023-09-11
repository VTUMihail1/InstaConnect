using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Models.DTOs.Token;

namespace InstaConnect.Business.Factories
{
    public class TokenFactory : ITokenFactory
    {
        public TokenAddDTO GetTokenAddDTO(string value, string type, int lifetimeSeconds)
        {
            return new TokenAddDTO()
            {
                Value = value,
                Type = type,
                ValidUntil = DateTime.Now.AddSeconds(lifetimeSeconds)
            };
        }
    }
}
