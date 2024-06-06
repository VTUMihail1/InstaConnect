using AutoMapper;
using InstaConnect.Shared.Business.Exceptions.Token;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Services;

public class TokenService : ITokenService
{
    private readonly IMapper _mapper;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly ITokenRepository _tokenRepository;

    public TokenService(
        IMapper mapper,
        ITokenGenerator tokenGenerator,
        ITokenRepository tokenRepository)
    {
        _mapper = mapper;
        _tokenGenerator = tokenGenerator;
        _tokenRepository = tokenRepository;
    }

    public async Task<TokenViewDTO> GenerateAccessTokenAsync(string userId, CancellationToken cancellationToken)
    {
        var token = _tokenGenerator.GenerateAccessToken(userId);

        await _tokenRepository.AddAsync(token, cancellationToken);
        var tokenViewModel = _mapper.Map<TokenViewDTO>(token);

        return tokenViewModel;
    }

    public async Task<TokenViewDTO> GenerateEmailConfirmationTokenAsync(string userId, CancellationToken cancellationToken)
    {
        var token = _tokenGenerator.GenerateEmailConfirmationToken(userId);

        await _tokenRepository.AddAsync(token, cancellationToken);
        var tokenViewModel = _mapper.Map<TokenViewDTO>(token);

        return tokenViewModel;
    }

    public async Task<TokenViewDTO> GeneratePasswordResetTokenAsync(string userId, CancellationToken cancellationToken)
    {
        var token = _tokenGenerator.GeneratePasswordResetToken(userId);

        await _tokenRepository.AddAsync(token, cancellationToken);
        var tokenViewModel = _mapper.Map<TokenViewDTO>(token);

        return tokenViewModel;
    }

    public async Task<TokenViewDTO> GetByValueAsync(string value, CancellationToken cancellationToken)
    {
        var token = await _tokenRepository.GetByValueAsync(value, cancellationToken);

        if (token == null)
        {
            throw new TokenNotFoundException();
        }

        var tokenViewModel = _mapper.Map<TokenViewDTO>(token);

        return tokenViewModel;
    }

    public async Task DeleteAsync(string value, CancellationToken cancellationToken)
    {
        var token = await _tokenRepository.GetByValueAsync(value, cancellationToken);

        if (token == null)
        {
            throw new TokenNotFoundException();
        }

        await _tokenRepository.DeleteAsync(token, cancellationToken);
    }
}
