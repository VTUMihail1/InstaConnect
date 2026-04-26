using InstaConnect.Common.Domain.Features.Emails.Models;

namespace InstaConnect.Common.Domain.Features.Emails.Abstractions;

public interface IEmailSender
{
    Task SendAsync(SendEmailRequest request, CancellationToken cancellationToken);
}
