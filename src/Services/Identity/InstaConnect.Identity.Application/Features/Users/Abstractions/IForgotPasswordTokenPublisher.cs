using InstaConnect.Identity.Application.Features.Users.Models;

namespace InstaConnect.Identity.Application.Features.Users.Abstractions;
public interface IForgotPasswordTokenPublisher
{
    Task PublishForgotPasswordTokenAsync(CreateForgotPasswordTokenModel createForgotPasswordTokenModel, CancellationToken cancellationToken);
}
