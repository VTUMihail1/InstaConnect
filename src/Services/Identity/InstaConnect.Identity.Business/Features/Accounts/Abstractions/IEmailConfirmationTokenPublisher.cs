using InstaConnect.Identity.Business.Features.Accounts.Models;

namespace InstaConnect.Identity.Business.Features.Accounts.Abstractions;
public interface IEmailConfirmationTokenPublisher
{
    Task PublishEmailConfirmationTokenAsync(CreateEmailConfirmationTokenModel createEmailConfirmationTokenModel, CancellationToken cancellationToken);
}
