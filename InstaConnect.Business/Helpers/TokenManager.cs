using AutoMapper;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Models.DTOs.Token;
using InstaConnect.Data.Abstraction.Factories;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;

namespace InstaConnect.Business.Helpers
{
    public class TokenManager : ITokenManager
    {
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ITokenFactory _tokenFactory;

        public TokenManager(
            IMapper mapper,
            ITokenRepository tokenRepository,
            ITokenGenerator tokenGenerator,
            ITokenFactory tokenFactory)
        {
            _mapper = mapper;
            _tokenRepository = tokenRepository;
            _tokenGenerator = tokenGenerator;
            _tokenFactory = tokenFactory;
        }

        public async Task<TokenResultDTO> GenerateAccessToken(string userId)
        {
            var value = _tokenGenerator.GenerateAccessTokenValue(userId);
            var token = _tokenFactory.GetAccessToken(userId, value);

            await _tokenRepository.AddAsync(token);
            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);

            return tokenResultDTO;
        }

        public async Task<TokenResultDTO> GenerateEmailConfirmationTokenAsync(string userId)
        {
            var value = _tokenGenerator.GenerateEmailConfirmationTokenValue(userId);
            var token = _tokenFactory.GetConfirmEmailToken(userId, value);

            await _tokenRepository.AddAsync(token);
            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);

            return tokenResultDTO;
        }

        public async Task<TokenResultDTO> GeneratePasswordResetToken(string userId)
        {
            var value = _tokenGenerator.GenerateEmailConfirmationTokenValue(userId);
            var token = _tokenFactory.GetConfirmEmailToken(userId, value);

            await _tokenRepository.AddAsync(token);
            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);

            return tokenResultDTO;
        }

        public async Task<TokenResultDTO> GetByValueAsync(string value)
        {
            var token = await _tokenRepository.FindEntityAsync(t => t.Value == value);
            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);

            return tokenResultDTO;
        }

        public async Task<bool> RemoveAsync(string value)
        {
            var token = await _tokenRepository.FindEntityAsync(t => t.Value == value);

            if (token == null)
            {
                return false;
            }

            await _tokenRepository.DeleteAsync(token);

            return true;
        }
    }
}
