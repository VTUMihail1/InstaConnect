using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Models.DTOs.Token;
using InstaConnect.Business.Models.Utilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenOptions = InstaConnect.Data.Models.Models.Options.TokenOptions;

namespace InstaConnect.Business.Helpers
{
    public class TokenHandler : ITokenHandler
    {
        private readonly ITokenFactory _tokenFactory;
        private readonly TokenOptions _tokenOptions;

        public TokenHandler(ITokenFactory tokenFactory, TokenOptions tokenOptions)
        {
            _tokenFactory = tokenFactory;
            _tokenOptions = tokenOptions;
        }

        public TokenAddDTO GenerateForgotPasswordToken(string value)
        {
            var forgotPasswordToken = _tokenFactory.GetTokenAddDTO(value, InstaConnectBusinessConstants.AccountForgotPasswordTokenType, _tokenOptions.UserTokenLifetimeSeconds);

            return forgotPasswordToken;
        }

        public TokenAddDTO GenerateEmailConfirmationToken(string value)
        {
            var emailConfirmationToken = _tokenFactory.GetTokenAddDTO(value, InstaConnectBusinessConstants.AccountConfirmEmailTokenType, _tokenOptions.UserTokenLifetimeSeconds);

            return emailConfirmationToken;
        }

        public TokenAddDTO GenerateAccessToken(string userId)
        {
            var claims = GetClaims(userId);
            var accessTokenValue = GetAccessToken(claims);

            var value = InstaConnectBusinessConstants.AccessTokenPrefix + accessTokenValue;

            var accessToken = _tokenFactory.GetTokenAddDTO(value, InstaConnectBusinessConstants.AccessTokenType, _tokenOptions.AccessTokenLifetimeSeconds);

            return accessToken;
        }

        private string GetAccessToken(IEnumerable<Claim> claims)
        {
            var securityKeyAsBytes = Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey);
            var signingKey = new SymmetricSecurityKey(securityKeyAsBytes);

            var claimsIdentity = new ClaimsIdentity(claims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha512Signature),
                Issuer = _tokenOptions.Issuer,
                Audience = _tokenOptions.Audience,
                Expires = DateTime.Now.AddSeconds(_tokenOptions.AccessTokenLifetimeSeconds)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        private IEnumerable<Claim> GetClaims(string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())
            };

            return claims;
        }
    }
}
