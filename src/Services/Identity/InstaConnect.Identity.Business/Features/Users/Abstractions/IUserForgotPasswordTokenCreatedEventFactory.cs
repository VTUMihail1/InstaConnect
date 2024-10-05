using InstaConnect.Shared.Business.Contracts.Emails;

namespace InstaConnect.Identity.Business.Features.Users.Abstractions;
public interface IUserForgotPasswordTokenCreatedEventFactory
{
    UserForgotPasswordTokenCreatedEvent GetUserForgotPasswordTokenCreatedEvent(string userId, string email, string token);
}
