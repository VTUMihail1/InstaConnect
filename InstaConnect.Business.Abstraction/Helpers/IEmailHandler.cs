namespace InstaConnect.Business.Abstraction.Helpers
{
    public interface IEmailHandler
    {
        Task SendEmailVerification(string email, string userId, string token);
        Task SendPasswordResetAsync(string email, string userId, string token);
    }
}