using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Models.Options;
using InstaConnect.Data.Models.Utilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InstaConnect.Data.Helpers
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly TokenOptions _tokenOptions;

        public TokenGenerator(IOptions<TokenOptions> options)
        {
            _tokenOptions = options.Value;
        }

        public string GenerateAccessTokenValue(string userId)
        {
            var claims = GetClaims(userId);
            var accessTokenValue = GetToken(claims, _tokenOptions.SecurityKey);

            var value = InstaConnectConstants.AccessTokenPrefix + accessTokenValue;

            return value;
        }

        public string GenerateEmailConfirmationTokenValue(string userId)
        {
            var claims = GetClaims(userId);
            var accessTokenValue = GetToken(claims, string.Empty);

            var value = accessTokenValue;

            return value;
        }

        public string GeneratePasswordResetToken(string userId)
        {
            var claims = GetClaims(userId);
            var accessTokenValue = GetToken(claims, string.Empty);

            var value = accessTokenValue;

            return value;
        }

        private string GetToken(IEnumerable<Claim> claims, string securityKey)
        {
            var securityKeyAsBytes = Encoding.UTF8.GetBytes(securityKey);
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
