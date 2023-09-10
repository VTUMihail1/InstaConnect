using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.DTOs.Token;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;
        private readonly ITokenHandler _tokenHandler;
        private readonly IResultFactory _resultFactory;

        public TokenService(
            IMapper mapper,
            ITokenRepository tokenRepository,
            ITokenHandler tokenHandler,
            IResultFactory resultFactory)
        {
            _mapper = mapper;
            _tokenRepository = tokenRepository;
            _tokenHandler = tokenHandler;
            _resultFactory = resultFactory;
        }

        public async Task<IResult<TokenResultDTO>> AddAccessTokenAsync(AccountResultDTO accountResultDTO)
        {
            var tokenGenerateDTO = _mapper.Map<TokenGenerateDTO>(accountResultDTO);
            var tokenAddDTO = _tokenHandler.GenerateAccessToken(tokenGenerateDTO);

            var token = _mapper.Map<Token>(tokenAddDTO);
            await _tokenRepository.AddAsync(token);

            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);
            var okResult = _resultFactory.GetOkResult(tokenResultDTO);

            return okResult;
        }

        public async Task<IResult<TokenResultDTO>> AddEmailConfirmationTokenAsync(string value)
        {
            var tokenAddDTO = _tokenHandler.GenerateEmailConfirmationToken(value);

            var token = _mapper.Map<Token>(tokenAddDTO);
            await _tokenRepository.AddAsync(token);

            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);
            var okResult = _resultFactory.GetOkResult(tokenResultDTO);

            return okResult;
        }

        public async Task<IResult<TokenResultDTO>> AddPasswordResetTokenAsync(string value)
        {
            var tokenAddDTO = _tokenHandler.GenerateForgotPasswordToken(value);

            var token = _mapper.Map<Token>(tokenAddDTO);
            await _tokenRepository.AddAsync(token);

            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);
            var okResult = _resultFactory.GetOkResult(tokenResultDTO);

            return okResult;
        }

        public async Task<IResult<TokenResultDTO>> GetByValueAsync(string value)
        {
            if (value == null)
            {
                var unauthorizedResult = _resultFactory.GetUnauthorizedResult<TokenResultDTO>(InstaConnectErrorMessages.AccountAccessTokenNotInHeader);

                return unauthorizedResult;
            }

            var token = await _tokenRepository.FindEntityAsync(t => t.Value == value);

            if (token == null)
            {
                var unauthorizedResult = _resultFactory.GetUnauthorizedResult<TokenResultDTO>(InstaConnectErrorMessages.AccountAccessTokenNotFound);

                return unauthorizedResult;
            }

            var tokenResultDTO = _mapper.Map<TokenResultDTO>(token);
            var okResult = _resultFactory.GetOkResult(tokenResultDTO);

            return okResult;
        }

        public async Task<IResult<TokenResultDTO>> RemoveAsync(string value)
        {
            if (value == null)
            {
                var unauthorizedResult = _resultFactory.GetUnauthorizedResult<TokenResultDTO>(InstaConnectErrorMessages.AccountAccessTokenNotInHeader);

                return unauthorizedResult;
            }

            var token = await _tokenRepository.FindEntityAsync(t => t.Value == value);

            if (token == null)
            {
                var unauthorizedResult = _resultFactory.GetUnauthorizedResult<TokenResultDTO>(InstaConnectErrorMessages.AccountAccessTokenNotFound);

                return unauthorizedResult;
            }

            await _tokenRepository.DeleteAsync(token);

            var noContentResult = _resultFactory.GetNoContentResult<TokenResultDTO>();

            return noContentResult;
        }
    }
}
