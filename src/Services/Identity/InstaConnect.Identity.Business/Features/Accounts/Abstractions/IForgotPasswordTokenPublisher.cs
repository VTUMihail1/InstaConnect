using InstaConnect.Identity.Business.Features.Accounts.Models;

namespace InstaConnect.Identity.Business.Features.Accounts.Abstractions;
public interface IForgotPasswordTokenPublisher
{
    Task PublishForgotPasswordTokenAsync(CreateForgotPasswordTokenModel createForgotPasswordTokenModel, CancellationToken cancellationToken);
}
