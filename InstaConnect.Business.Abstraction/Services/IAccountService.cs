using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    public interface IAccountService
    {
        Task<IResult<string>> ConfirmEmailAsync(string userId, string token);

        Task<IResult<string>> SendAccountConfirmEmailTokenAsync(string email);

        Task<IResult<string>> SendAccountResetPasswordTokenAsync(string email);

        Task<IResult<AccountResultDTO>> LoginAsync(AccountLoginDTO accountLoginDTO);

        Task<IResult<string>> ResetPasswordAsync(string userId, string token, AccountResetPasswordDTO accountResetPasswordDTO);

        Task<IResult<AccountResultDTO>> SignUpAsync(AccountRegistrationDTO accountRegistrationDTO);
    }
}