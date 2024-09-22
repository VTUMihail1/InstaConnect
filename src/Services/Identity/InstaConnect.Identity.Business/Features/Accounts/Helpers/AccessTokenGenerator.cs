using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using InstaConnect.Identity.Business.Features.Accounts.Abstractions;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Shared.Data.Models.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Identity.Business.Features.Accounts.Helpers;

internal class AccessTokenGenerator : IAccessTokenGenerator
{
    private readonly AccessTokenOptions _accessTokenOptions;

    public AccessTokenGenerator(IOptions<AccessTokenOptions> options)
    {
        _accessTokenOptions = options.Value;
    }

    public AccessTokenResult GenerateAccessToken(CreateAccessTokenModel createAccessTokenModel)
    {
        var result = GetToken(createAccessTokenModel.Claims);

        return result;
    }

    private AccessTokenResult GetToken(IEnumerable<Claim>? claims = null)
    {
        var validUntil = DateTime.Now.AddSeconds(_accessTokenOptions.LifetimeSeconds);
        var signingKey = new SymmetricSecurityKey(_accessTokenOptions.SecurityKeyByteArray);
        var claimsIdentity = new ClaimsIdentity(claims);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha512Signature),
            Issuer = _accessTokenOptions.Issuer,
            Audience = _accessTokenOptions.Audience,
            Expires = validUntil
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(securityToken);

        return new AccessTokenResult(token, validUntil);
    }
}
