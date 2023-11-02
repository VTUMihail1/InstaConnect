using InstaConnect.Business.Models.DTOs.Email;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    public interface IEmailService
    {
        Task<IResult<EmailResultDTO>> SendEmailConfirmationAsync(string email, string userId, string token);

        Task<IResult<EmailResultDTO>> SendPasswordResetAsync(string email, string userId, string token);
    }
}