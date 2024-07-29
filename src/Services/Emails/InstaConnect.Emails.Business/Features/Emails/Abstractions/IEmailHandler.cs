using InstaConnect.Emails.Business.Features.Emails.Models.Emails;

namespace InstaConnect.Emails.Business.Features.Emails.Abstractions;
public interface IEmailHandler
{
    Task SendEmailConfirmationAsync(SendConfirmEmailModel sendConfirmEmailModel, CancellationToken cancellationToken);
    Task SendForgotPasswordAsync(SendForgotPasswordModel sendForgotPasswordModel, CancellationToken cancellationToken);
}
