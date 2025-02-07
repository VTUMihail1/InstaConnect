using InstaConnect.Identity.Application.Features.Users.Models;

namespace InstaConnect.Identity.Application.Features.Users.Abstractions;
public interface IEmailConfirmationTokenPublisher
{
    Task PublishEmailConfirmationTokenAsync(CreateEmailConfirmationTokenModel createEmailConfirmationTokenModel, CancellationToken cancellationToken);
}
