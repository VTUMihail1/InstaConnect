using InstaConnect.Identity.Business.Features.Users.Models;

namespace InstaConnect.Identity.Business.Features.Users.Abstractions;
public interface IForgotPasswordTokenPublisher
{
    Task PublishForgotPasswordTokenAsync(CreateForgotPasswordTokenModel createForgotPasswordTokenModel, CancellationToken cancellationToken);
}
