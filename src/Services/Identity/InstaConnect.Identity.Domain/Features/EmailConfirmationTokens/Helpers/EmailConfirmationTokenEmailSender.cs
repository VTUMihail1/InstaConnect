using InstaConnect.Common.Domain.Features.Emails.Abstractions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenEmailSender : IEmailConfirmationTokenEmailSender
{
    private readonly IEmailSender _emailSender;
    private readonly IEmailConfirmationTokenSendEmailRequestFactory _emailConfirmationTokenSendEmailRequestFactory;

    public EmailConfirmationTokenEmailSender(
        IEmailSender emailSender,
        IEmailConfirmationTokenSendEmailRequestFactory emailConfirmationTokenSendEmailRequestFactory)
    {
        _emailSender = emailSender;
        _emailConfirmationTokenSendEmailRequestFactory = emailConfirmationTokenSendEmailRequestFactory;
    }

    public async Task SendAsync(EmailConfirmationToken emailConfirmationToken, CancellationToken cancellationToken)
    {
        var request = _emailConfirmationTokenSendEmailRequestFactory.Get(emailConfirmationToken);

        await _emailSender.SendAsync(request, cancellationToken);
    }
}
