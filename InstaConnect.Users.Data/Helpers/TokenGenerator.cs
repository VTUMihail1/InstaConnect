using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InstaConnect.Users.Data.Abstraction.Factories;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Models.Entities;
using InstaConnect.Users.Data.Models.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Users.Data.Helpers;

internal class TokenGenerator : ITokenGenerator
{
    private const string ACCESS_TOKEN_TYPE = "Bearer ";
    private const string EMAIL_CONFIRMATION_TOKEN_TYPE = "Email Confirmation";
    private const string PASSWORD_RESET_TOKEN_TYPE = "Password Reset";

    private readonly TokenOptions _tokenOptions;
    private readonly ITokenFactory _tokenFactory;

    public TokenGenerator(
        IOptions<TokenOptions> options,
        ITokenFactory tokenFactory)
    {
        _tokenOptions = options.Value;
        _tokenFactory = tokenFactory;
    }

    public Token GenerateAccessToken(string userId)
    {
        var claims = GetClaims(userId);
        var value = GetToken(
            claims,
            _tokenOptions.AccessTokenSecurityKey,
            _tokenOptions.AccessTokenLifetimeSeconds,
            ACCESS_TOKEN_TYPE);

        var token = _tokenFactory.GetTokenToken(
            userId,
            value,
            ACCESS_TOKEN_TYPE,
            _tokenOptions.AccessTokenLifetimeSeconds);

        return token;
    }

    public Token GenerateEmailConfirmationToken(string userId)
    {
        var claims = GetClaims(userId);
        var value = GetToken(
            claims,
            _tokenOptions.AccountTokenSecurityKey,
            _tokenOptions.AccountTokenLifetimeSeconds);

        var token = _tokenFactory.GetTokenToken(
            userId,
            value,
            EMAIL_CONFIRMATION_TOKEN_TYPE,
            _tokenOptions.AccountTokenLifetimeSeconds);

        return token;
    }

    public Token GeneratePasswordResetToken(string userId)
    {
        var claims = GetClaims(userId);
        var value = GetToken(
            claims,
            _tokenOptions.AccountTokenSecurityKey,
            _tokenOptions.AccountTokenLifetimeSeconds);

        var token = _tokenFactory.GetTokenToken(
            userId,
            value,
            PASSWORD_RESET_TOKEN_TYPE,
            _tokenOptions.AccountTokenLifetimeSeconds);

        return token;
    }

    private string GetToken(IEnumerable<Claim> claims, string securityKey, int lifeTime, string prefix = "")
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
            Expires = DateTime.Now.AddSeconds(lifeTime)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = prefix + tokenHandler.WriteToken(securityToken);

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
