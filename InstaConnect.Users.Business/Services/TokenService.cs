using AutoMapper;
using EGames.Business.Models.DTOs.Token;
using EGames.Business.Services.Abstract;
using EGames.Common.Exceptions.Token;
using EGames.Data.Helpers.Abstract;
using EGames.Data.Repositories.Abstract;

namespace EGames.Business.Services
{
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

        public async Task<TokenResultDTO> GenerateAccessTokenAsync(string userId)
        {
            var token = _tokenGenerator.GenerateAccessToken(userId);

            await _tokenRepository.AddAsync(token);
            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);

            return tokenResultDTO;
        }

        public async Task<TokenResultDTO> GenerateEmailConfirmationTokenAsync(string userId)
        {
            var token = _tokenGenerator.GenerateEmailConfirmationToken(userId);

            await _tokenRepository.AddAsync(token);
            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);

            return tokenResultDTO;
        }

        public async Task<TokenResultDTO> GetByValueAsync(string value)
        {
            var token = await _tokenRepository.GetByValueAsync(value);

            if (token == null)
            {
                throw new TokenNotFoundException();
            }

            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);

            return tokenResultDTO;
        }

        public async Task DeleteAsync(string value)
        {
            var token = await _tokenRepository.GetByValueAsync(value);

            if (token == null)
            {
                throw new TokenNotFoundException();
            }

            await _tokenRepository.DeleteAsync(token);
        }
    }
}
