using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Tokens.Utilities;
using InstaConnect.Common.Infrastructure.Features.Tokens.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Tokens.Models;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers;

internal class AccessTokenGenerator : IAccessTokenGenerator
{
    private readonly IEncoder _encoder;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly AccessTokenOptions _sessionTokenOptions;

    public AccessTokenGenerator(
        IEncoder encoder,
        IDateTimeProvider dateTimeProvider,
        IOptions<AccessTokenOptions> options)
    {
        _encoder = encoder;
        _dateTimeProvider = dateTimeProvider;
        _sessionTokenOptions = options.Value;
    }

    public AccessToken Generate(User user)
    {
        var claimsIdentity = new ClaimsIdentity(
            [new(DefaultClaims.Id, user.Id.Id),
             new(DefaultClaims.Email, user.Email.Value),
             new(DefaultClaims.FirstName, user.FirstName),
             new(DefaultClaims.LastName, user.LastName),
             new(DefaultClaims.Name, user.Name.Value),
             ..user.UserClaims.Select(uc => new Claim(uc.Id.Claim.GetName(), uc.Id.Claim.GetName()))]);

        var expiresAtUtc = _dateTimeProvider.GetUtcNow(_sessionTokenOptions.LifetimeSeconds);
        var signingKey = new SymmetricSecurityKey(_encoder.GetBytesUTF8(_sessionTokenOptions.SecurityKey));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha512Signature),
            Issuer = _sessionTokenOptions.Issuer,
            Audience = _sessionTokenOptions.Audience,
            Expires = _dateTimeProvider.GetUtcNow(_sessionTokenOptions.LifetimeSeconds)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var value = tokenHandler.WriteToken(securityToken);

        return new(value, expiresAtUtc);
    }
}
