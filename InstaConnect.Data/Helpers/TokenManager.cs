using InstaConnect.Data.Abstraction.Factories;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Helpers
{
    public class TokenManager : ITokenManager
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ITokenFactory _tokenFactory;

        public TokenManager(
            ITokenRepository tokenRepository,
            ITokenGenerator tokenGenerator,
            ITokenFactory tokenFactory)
        {
            _tokenRepository = tokenRepository;
            _tokenGenerator = tokenGenerator;
            _tokenFactory = tokenFactory;
        }

        public async Task<Token> GenerateAccessToken(string userId)
        {
            var value = _tokenGenerator.GenerateAccessTokenValue(userId);
            var token = _tokenFactory.GetAccessToken(userId, value);

            await _tokenRepository.AddAsync(token);

            return token;
        }

        public async Task<Token> GenerateEmailConfirmationToken(string userId)
        {
            var value = _tokenGenerator.GenerateEmailConfirmationTokenValue(userId);
            var token = _tokenFactory.GetConfirmEmailToken(userId, value);

            await _tokenRepository.AddAsync(token);

            return token;
        }

        public async Task<Token> GeneratePasswordResetToken(string userId)
        {
            var value = _tokenGenerator.GenerateEmailConfirmationTokenValue(userId);
            var token = _tokenFactory.GetConfirmEmailToken(userId, value);
            await _tokenRepository.AddAsync(token);

            return token;
        }

        public async Task<Token> GetByValueAsync(string value)
        {
            var token = await _tokenRepository.FindEntityAsync(t => t.Value == value);

            return token;
        }

        public async Task RemoveAsync(string value)
        {
            var token = await _tokenRepository.FindEntityAsync(t => t.Value == value);

            await _tokenRepository.DeleteAsync(token);
        }
    }
}
