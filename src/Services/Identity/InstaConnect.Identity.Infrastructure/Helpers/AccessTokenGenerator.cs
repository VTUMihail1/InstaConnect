using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Models.Options;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Identity.Infrastructure.Helpers;

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

    public AccessToken Generate(User user, ICollection<UserClaim> claims)
    {
        var securityKeyByteArray = _encoder.GetBytesUTF8(_accessTokenOptions.SecurityKey);
        var expiresAt = _dateTimeProvider.GetOffsetUtcNow(_accessTokenOptions.LifetimeSeconds);
        var signingKey = new SymmetricSecurityKey(securityKeyByteArray);

        var claimsIdentity = new ClaimsIdentity(
            [new(ClaimTypes.NameIdentifier, user.Id),
             new(ClaimTypes.Email, user.Email),
             new(ClaimTypes.GivenName, user.FirstName),
             new(ClaimTypes.Surname, user.LastName),
             new(ClaimTypes.Name, user.Name),
             ..claims.Select(uc => new Claim(uc.Claim, uc.Value))]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha512Signature),
            Issuer = _accessTokenOptions.Issuer,
            Audience = _accessTokenOptions.Audience,
            Expires = expiresAt.UtcDateTime,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var value = tokenHandler.WriteToken(securityToken);

        return new AccessToken(user.Id, value, expiresAt);
    }
}
