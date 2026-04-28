using InstaConnect.Common.Domain.Features.Emails.Abstractions;
using InstaConnect.Common.Domain.Features.Emails.Models;
using InstaConnect.Common.Infrastructure.Features.Emails.Models;

using Microsoft.Extensions.Options;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace InstaConnect.Common.Infrastructure.Features.Emails.Helpers;

internal class EmailSender : IEmailSender
{
    private readonly SendGridOptions _sendGridOptions;
    private readonly ISendGridClient _sendGridClient;

    public EmailSender(IOptions<SendGridOptions> sendGridOptions, ISendGridClient sendGridClient)
    {
        _sendGridOptions = sendGridOptions.Value;
        _sendGridClient = sendGridClient;
    }

    public async Task SendAsync(SendEmailRequest request, CancellationToken cancellationToken)
    {
        var message = MailHelper.CreateSingleEmail(
            new EmailAddress(_sendGridOptions.Sender),
            new EmailAddress(request.Receiver),
            request.Subject,
            plainTextContent: null,
            request.Template);

        await _sendGridClient.SendEmailAsync(message, cancellationToken);
    }
}
