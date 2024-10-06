using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using InstaConnect.Identity.Business.Features.Users.Abstractions;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Shared.Data.Models.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Identity.Business.Features.Users.Helpers;

internal class AccessTokenGenerator : IAccessTokenGenerator
{
    private readonly AccessTokenOptions _accessTokenOptions;

    public AccessTokenGenerator(IOptions<AccessTokenOptions> options)
    {
        _accessTokenOptions = options.Value;
    }

    public AccessTokenResult GenerateAccessToken(CreateAccessTokenModel createAccessTokenModel)
    {
        var validUntil = DateTime.Now.AddSeconds(_accessTokenOptions.LifetimeSeconds);
        var signingKey = new SymmetricSecurityKey(_accessTokenOptions.SecurityKeyByteArray);
        var claimsIdentity = new ClaimsIdentity(
            [new(ClaimTypes.NameIdentifier, createAccessTokenModel.UserId),
             new(ClaimTypes.Email, createAccessTokenModel.Email),
             new(ClaimTypes.GivenName, createAccessTokenModel.FirstName),
             new(ClaimTypes.Surname, createAccessTokenModel.LastName),
             new(ClaimTypes.Name, createAccessTokenModel.UserName),
             ..createAccessTokenModel.UserClaims.Select(uc => new Claim(uc.Claim, uc.Value))]);

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
