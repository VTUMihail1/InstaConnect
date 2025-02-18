using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Shared.Infrastructure.Abstractions;
using InstaConnect.Shared.Infrastructure.Models.Options;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers;

internal class AccessTokenGenerator : IAccessTokenGenerator
{
    private readonly IEncoder _encoder;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly AccessTokenOptions _accessTokenOptions;

    public AccessTokenGenerator(
        IEncoder encoder,
        IDateTimeProvider dateTimeProvider,
        IOptions<AccessTokenOptions> options)
    {
        _encoder = encoder;
        _dateTimeProvider = dateTimeProvider;
        _accessTokenOptions = options.Value;
    }

    public AccessTokenResult GenerateAccessToken(CreateAccessTokenModel createAccessTokenModel)
    {
        var securityKeyByteArray = _encoder.GetBytesUTF8(_accessTokenOptions.SecurityKey);
        var validUntil = _dateTimeProvider.GetCurrentUtc(_accessTokenOptions.LifetimeSeconds);
        var signingKey = new SymmetricSecurityKey(securityKeyByteArray);

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
