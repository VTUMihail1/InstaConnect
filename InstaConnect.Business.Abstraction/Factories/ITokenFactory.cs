using InstaConnect.Business.Models.DTOs.Token;

namespace InstaConnect.Business.Abstraction.Factories
{
    /// <summary>
    /// Represents an interface for creating data transfer objects (DTOs) for tokens.
    /// </summary>
    public interface ITokenFactory
    {
        /// <summary>
        /// Creates a data transfer object (DTO) for adding a token.
        /// </summary>
        /// <param name="value">The value of the token.</param>
        /// <param name="type">The type or purpose of the token.</param>
        /// <param name="lifetimeSeconds">The lifetime of the token in seconds.</param>
        /// <returns>An instance of <see cref="TokenAddDTO"/> containing token information.</returns>
        TokenAddDTO GetTokenAddDTO(string value, string type, int lifetimeSeconds);
    }
}