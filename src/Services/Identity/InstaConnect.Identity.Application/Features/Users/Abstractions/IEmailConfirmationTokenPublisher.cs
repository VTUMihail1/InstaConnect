using InstaConnect.Identity.Business.Features.Users.Models;

namespace InstaConnect.Identity.Business.Features.Users.Abstractions;
public interface IEmailConfirmationTokenPublisher
{
    Task PublishEmailConfirmationTokenAsync(CreateEmailConfirmationTokenModel createEmailConfirmationTokenModel, CancellationToken cancellationToken);
}
