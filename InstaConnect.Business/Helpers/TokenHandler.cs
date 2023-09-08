using DocConnect.Business.Models.DTOs.Token;
using TokenOptions = DocConnect.Business.Models.Options.TokenOptions;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DocConnect.Business.Helpers
{
    public class TokenHandler : ITokenHandler
    {
        private readonly TokenOptions _tokenOptions;

        public TokenHandler(TokenOptions tokenOptions)
        {
            _tokenOptions = tokenOptions;
        }

        public TokenAddDTO GenerateForgotPasswordToken(TokenGenerateDTO tokenGenerateDTO)
        {
            var emailConfirmationToken = new TokenAddDTO()
            {
                UserId = tokenGenerateDTO.UserId,
                Value = tokenGenerateDTO.Token,
                Type = InstaConnectConstants.AccountForgotPasswordTokenType,
                ValidUntil = DateTime.UtcNow.AddSeconds(_tokenOptions.AccessTokenLifetimeSeconds),
            };

            return emailConfirmationToken;
        }

        public TokenAddDTO GenerateEmailConfirmationToken(TokenGenerateDTO tokenGenerateDTO)
        {
            var emailConfirmationToken = new TokenAddDTO()
            {
                UserId = tokenGenerateDTO.UserId,
                Value = tokenGenerateDTO.Token,
                Type = InstaConnectConstants.AccountConfirmEmailTokenType,
                ValidUntil = DateTime.UtcNow.AddSeconds(_tokenOptions.AccessTokenLifetimeSeconds),
            };

            return emailConfirmationToken;
        }

        public TokenAddDTO GenerateAccessToken(TokenGenerateDTO tokenGenerateDTO)
        {
            var claims = GetClaims(tokenGenerateDTO);
            var accessTokenValue = GetAccessToken(claims);

            var value = InstaConnectConstants.AccessTokenPrefix + accessTokenValue;

            var accessToken = new TokenAddDTO()
            {
                UserId = tokenGenerateDTO.UserId,
                Value = value,
                Type = InstaConnectConstants.AccessTokenType,
                ValidUntil = DateTime.UtcNow.AddSeconds(_tokenOptions.AccessTokenLifetimeSeconds),
            };

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
                Expires = DateTime.UtcNow.AddSeconds(_tokenOptions.AccessTokenLifetimeSeconds)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        private IEnumerable<Claim> GetClaims(TokenGenerateDTO tokenGenerateDTO)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, tokenGenerateDTO.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
            };

            return claims;
        }
    }
}
