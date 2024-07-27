using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Models.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Identity.Data.Helpers;

internal class TokenGenerator : ITokenGenerator
{
    private const string ACCESS_TOKEN_TYPE = "Bearer ";
    private const string EMAIL_CONFIRMATION_TOKEN_TYPE = "Email Confirmation";
    private const string PASSWORD_RESET_TOKEN_TYPE = "Password Reset";

    private readonly TokenOptions _tokenOptions;
    private readonly ITokenFactory _tokenFactory;
    private readonly ITokenWriteRepository _tokenWriteRepository;

    public TokenGenerator(
        IOptions<TokenOptions> options,
        ITokenFactory tokenFactory,
        ITokenWriteRepository tokenWriteRepository)
    {
        _tokenOptions = options.Value;
        _tokenFactory = tokenFactory;
        _tokenWriteRepository = tokenWriteRepository;
    }

    public Token GenerateAccessToken(CreateAccessTokenModel createAccessTokenModel)
    {
        var value = GetToken(
            _tokenOptions.AccessTokenSecurityKeyByteArray,
            _tokenOptions.AccessTokenLifetimeSeconds,
            createAccessTokenModel.Claims);

        var token = _tokenFactory.GetTokenToken(
            createAccessTokenModel.UserId,
            value,
            ACCESS_TOKEN_TYPE,
            _tokenOptions.AccessTokenLifetimeSeconds);

        _tokenWriteRepository.Add(token);

        return token;
    }

    public Token GenerateEmailConfirmationToken(CreateAccountTokenModel createAccountTokenModel)
    {
        var value = GetToken(
            _tokenOptions.AccountTokenSecurityKeyByteArray,
            _tokenOptions.AccountTokenLifetimeSeconds);

        var token = _tokenFactory.GetTokenToken(
            createAccountTokenModel.UserId,
            value,
            EMAIL_CONFIRMATION_TOKEN_TYPE,
            _tokenOptions.AccountTokenLifetimeSeconds);

        _tokenWriteRepository.Add(token);

        return token;
    }

    public Token GeneratePasswordResetToken(CreateAccountTokenModel createAccountTokenModel)
    {
        var value = GetToken(
            _tokenOptions.AccessTokenSecurityKeyByteArray,
            _tokenOptions.AccountTokenLifetimeSeconds);

        var token = _tokenFactory.GetTokenToken(
            createAccountTokenModel.UserId,
            value,
            PASSWORD_RESET_TOKEN_TYPE,
            _tokenOptions.AccountTokenLifetimeSeconds);

        _tokenWriteRepository.Add(token);

        return token;
    }

    private string GetToken(byte[] securityKey, int lifeTime, IEnumerable<Claim>? claims = null)
    {
        var signingKey = new SymmetricSecurityKey(securityKey);
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
        var token = tokenHandler.WriteToken(securityToken);

        return token;
    }
}
