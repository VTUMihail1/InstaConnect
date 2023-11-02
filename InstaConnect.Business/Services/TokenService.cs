using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Token;
using InstaConnect.Business.Models.Results;
using InstaConnect.Data.Abstraction.Factories;
using InstaConnect.Data.Abstraction.Repositories;

namespace InstaConnect.Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly ITokenFactory _tokenFactory;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ITokenRepository _tokenRepository;

        public TokenService(
            IMapper mapper,
            IResultFactory resultFactory,
            ITokenRepository tokenRepository,
            ITokenGenerator tokenGenerator,
            ITokenFactory tokenFactory)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _tokenRepository = tokenRepository;
            _tokenGenerator = tokenGenerator;
            _tokenFactory = tokenFactory;
        }

        public async Task<IResult<TokenResultDTO>> GenerateAccessTokenAsync(string userId)
        {
            var value = _tokenGenerator.GenerateAccessTokenValue(userId);
            var token = _tokenFactory.GetAccessToken(userId, value);

            await _tokenRepository.AddAsync(token);
            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);

            var okResult = _resultFactory.GetOkResult(tokenResultDTO);

            return okResult;
        }

        public async Task<IResult<TokenResultDTO>> GenerateEmailConfirmationTokenAsync(string userId)
        {
            var value = _tokenGenerator.GenerateEmailConfirmationTokenValue(userId);
            var token = _tokenFactory.GetConfirmEmailToken(userId, value);

            await _tokenRepository.AddAsync(token);

            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);
            var okResult = _resultFactory.GetOkResult(tokenResultDTO);

            return okResult;
        }

        public async Task<IResult<TokenResultDTO>> GeneratePasswordResetTokenAsync(string userId)
        {
            var value = _tokenGenerator.GenerateEmailConfirmationTokenValue(userId);
            var token = _tokenFactory.GetConfirmEmailToken(userId, value);

            await _tokenRepository.AddAsync(token);

            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);
            var okResult = _resultFactory.GetOkResult(tokenResultDTO);

            return okResult;
        }

        public async Task<IResult<TokenResultDTO>> GetByValueAsync(string value)
        {
            var token = await _tokenRepository.FindEntityAsync(t => t.Value == value);

            if(token == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<TokenResultDTO>();

                return notFoundResult;
            }

            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);
            var okResult = _resultFactory.GetOkResult(tokenResultDTO);

            return okResult;
        }

        public async Task<IResult<TokenResultDTO>> DeleteAsync(string value)
        {
            var token = await _tokenRepository.FindEntityAsync(t => t.Value == value);

            if (token == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<TokenResultDTO>();

                return notFoundResult;
            }

            await _tokenRepository.DeleteAsync(token);

            var noContentResult = _resultFactory.GetNoContentResult<TokenResultDTO>();

            return noContentResult;
        }
    }
}
