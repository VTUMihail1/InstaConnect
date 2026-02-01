using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using InstaConnect.Common.Infrastructure.Models.Options;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers;

internal class SessionTokenGenerator : ISessionTokenGenerator
{
    private readonly IEncoder _encoder;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly SessionTokenOptions _sessionTokenOptions;

    public SessionTokenGenerator(
        IEncoder encoder,
        IDateTimeProvider dateTimeProvider,
        IOptions<SessionTokenOptions> options)
    {
        _encoder = encoder;
        _dateTimeProvider = dateTimeProvider;
        _sessionTokenOptions = options.Value;
    }

    public SessionToken Generate(RefreshToken refreshToken)
    {
        var claimsIdentity = new ClaimsIdentity(
            [new(ClaimTypes.NameIdentifier, refreshToken.User!.Id.Id),
             new(ClaimTypes.Email, refreshToken.User.Email.Value),
             new(ClaimTypes.GivenName, refreshToken.User.FirstName),
             new(ClaimTypes.Surname, refreshToken.User.LastName),
             new(ClaimTypes.Name, refreshToken.User.Name.Value),
             ..refreshToken.User.UserClaims.Select(uc => new Claim(uc.Id.Claim, uc.Id.Claim))]);

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

        return new(refreshToken.Id, new(value, expiresAtUtc), refreshToken.ExpiresAtUtc);
    }
}
