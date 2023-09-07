using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    public interface IAccountService
    {
        Task<IResult<AccountResultDTO>> ConfirmEmailAsync(string userId, string token);

        Task<IResult<AccountEmailRequestDTO>> GenerateConfirmEmailTokenAsync(string email);

        Task<IResult<AccountEmailRequestDTO>> GenerateResetPasswordTokenAsync(string email);

        Task<IResult<AccountResultDTO>> LoginAsync(AccountLoginDTO accountLoginDTO);

        Task<IResult<AccountResultDTO>> ResetPasswordAsync(string userId, string token, AccountResetPasswordDTO accountResetPasswordDTO);

        Task<IResult<AccountResultDTO>> SignUpAsync(AccountRegistrationDTO accountRegistrationDTO);
    }
}