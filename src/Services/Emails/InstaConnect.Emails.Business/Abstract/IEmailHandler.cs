using InstaConnect.Emails.Business.Models.Emails;

namespace InstaConnect.Emails.Business.Abstract;
public interface IEmailHandler
{
    Task SendEmailConfirmationAsync(SendConfirmEmailModel sendConfirmEmailModel, CancellationToken cancellationToken);
    Task SendForgotPasswordAsync(SendForgotPasswordModel sendForgotPasswordModel, CancellationToken cancellationToken);
}
