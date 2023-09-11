namespace InstaConnect.Business.Abstraction.Helpers
{
    public interface IEmailHandler
    {
        Task SendEmailConfirmationAsync(string email, string userId, string token);
        Task SendPasswordResetAsync(string email, string userId, string token);
    }
}