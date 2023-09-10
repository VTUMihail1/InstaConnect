﻿using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.DTOs.Token;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    public interface ITokenService
    {
        Task<IResult<TokenResultDTO>> AddEmailConfirmationTokenAsync(string value);

        Task<IResult<TokenResultDTO>> AddAccessTokenAsync(AccountResultDTO accountResultDTO);

        Task<IResult<TokenResultDTO>> AddPasswordResetTokenAsync(string value);

        Task<IResult<TokenResultDTO>> GetByValueAsync(string value);

        Task<IResult<TokenResultDTO>> RemoveAsync(string value);
    }
}