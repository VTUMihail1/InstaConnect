using InstaConnect.Data.Abstraction.Factories;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Helpers
{
    public class TokenManager : ITokenManager
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly ITokenGenerator _tokenHandler;
        private readonly ITokenFactory _tokenFactory;

        public TokenManager(
            ITokenRepository tokenRepository,
            ITokenGenerator tokenHandler,
            ITokenFactory tokenFactory)
        {
            _tokenRepository = tokenRepository;
            _tokenHandler = tokenHandler;
            _tokenFactory = tokenFactory;
        }

        public string GenerateAccessToken(string userId)
        {
            var value = _tokenHandler.GenerateAccessToken(userId);

            return value;
        }

        public async Task AddAccessTokenAsync(string userId, string value)
        {
            var token = _tokenFactory.GetAccessToken(userId, value);

            await _tokenRepository.AddAsync(token);
        }

        public async Task AddEmailConfirmationTokenAsync(string userId, string value)
        {
            var token = _tokenFactory.GetConfirmEmailToken(userId, value);

            await _tokenRepository.AddAsync(token);
        }

        public async Task AddForgotPasswordTokenAsync(string userId, string value)
        {
            var token = _tokenFactory.GetForgotPasswordToken(userId, value);

            await _tokenRepository.AddAsync(token);
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
