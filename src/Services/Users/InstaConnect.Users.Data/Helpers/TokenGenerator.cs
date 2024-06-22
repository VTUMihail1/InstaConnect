﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InstaConnect.Shared.Data.Models.Options;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction;
using InstaConnect.Users.Data.Models;
using InstaConnect.Users.Data.Models.Entities;
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

    public Token GenerateAccessToken(CreateAccessTokenModel createAccessTokenModel)
    {
        var value = GetToken(
            _tokenOptions.AccessTokenSecurityKey,
            _tokenOptions.AccessTokenLifetimeSeconds,
            createAccessTokenModel.Claims);

        var token = _tokenFactory.GetTokenToken(
            createAccessTokenModel.UserId,
            value,
            ACCESS_TOKEN_TYPE,
            _tokenOptions.AccessTokenLifetimeSeconds);

        return token;
    }

    public Token GenerateEmailConfirmationToken(CreateAccountTokenModel createAccountTokenModel)
    {
        var value = GetToken(
            _tokenOptions.AccountTokenSecurityKey,
            _tokenOptions.AccountTokenLifetimeSeconds);

        var token = _tokenFactory.GetTokenToken(
            createAccountTokenModel.UserId,
            value,
            EMAIL_CONFIRMATION_TOKEN_TYPE,
            _tokenOptions.AccountTokenLifetimeSeconds);

        return token;
    }

    public Token GeneratePasswordResetToken(CreateAccountTokenModel createAccountTokenModel)
    {
        var value = GetToken(
            _tokenOptions.AccountTokenSecurityKey,
            _tokenOptions.AccountTokenLifetimeSeconds);

        var token = _tokenFactory.GetTokenToken(
            createAccountTokenModel.UserId,
            value,
            PASSWORD_RESET_TOKEN_TYPE,
            _tokenOptions.AccountTokenLifetimeSeconds);

        return token;
    }

    private string GetToken(string securityKey, int lifeTime, IEnumerable<Claim>? claims = null)
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
        var token = tokenHandler.WriteToken(securityToken);

        return token;
    }
}
