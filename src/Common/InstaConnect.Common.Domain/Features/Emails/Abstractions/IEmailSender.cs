using InstaConnect.Common.Domain.Features.Emails.Models;

namespace InstaConnect.Common.Domain.Features.Emails.Abstractions;

public interface IEmailSender
{
	public Task SendAsync(SendEmailRequest request, CancellationToken cancellationToken);
}
