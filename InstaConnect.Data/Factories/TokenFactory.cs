using InstaConnect.Data.Abstraction.Factories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Models.Options;
using InstaConnect.Data.Models.Utilities;

namespace InstaConnect.Data.Factories
{
    public class TokenFactory : ITokenFactory
    {
        private readonly TokenOptions _tokenOptions;

        public TokenFactory(TokenOptions tokenOptions)
        {
            _tokenOptions = tokenOptions;
        }

        public Token GetAccessToken(string userId, string value)
        {
            return new Token()
            {
                UserId = userId,
                Value = value,
                Type = InstaConnectConstants.AccessTokenType,
                ValidUntil = DateTime.Now.AddSeconds(_tokenOptions.AccessTokenLifetimeSeconds)
            };
        }

        public Token GetConfirmEmailToken(string userId, string value)
        {
            return new Token()
            {
                UserId = userId,
                Value = value,
                Type = InstaConnectConstants.AccountConfirmEmailTokenType,
                ValidUntil = DateTime.Now.AddSeconds(_tokenOptions.UserTokenLifetimeSeconds)
            };
        }

        public Token GetForgotPasswordToken(string userId, string value)
        {
            return new Token()
            {
                UserId = userId,
                Value = value,
                Type = InstaConnectConstants.AccountForgotPasswordTokenType,
                ValidUntil = DateTime.Now.AddSeconds(_tokenOptions.AccessTokenLifetimeSeconds)
            };
        }
    }
}
