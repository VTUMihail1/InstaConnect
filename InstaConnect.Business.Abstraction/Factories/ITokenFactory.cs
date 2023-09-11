using InstaConnect.Business.Models.DTOs.Token;

namespace InstaConnect.Business.Abstraction.Factories
{
    public interface ITokenFactory
    {
        TokenAddDTO GetTokenAddDTO(string value, string type, int lifetimeSeconds);
    }
}